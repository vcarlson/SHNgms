using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHNgms.Models;
using SHNgms.Data;

namespace SHNgms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrantsController : ControllerBase
    {
        private readonly SHNgmsContext _context;

        public GrantsController(SHNgmsContext context)
        {
            _context = context;
        }

        // Other GET, POST, PUT, DELETE methods...

        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardData>> GetDashboardData()
        {
            // Fetch all grants (could optimize this query)
            var grants = await _context.Grants.ToListAsync();

            // Key Indicators
            var activeGrants = grants.Count(g => g.Status == "Active");
            var totalFundsAllocated = grants.Sum(g => g.TotalFundsAllocated);
            var totalFundsSpent = grants.Sum(g => g.FundsSpent);
            var upcomingDeadlines = grants.Count(g => g.CompletionDate > DateTime.Now); // Assuming CompletionDate is the deadline field

            // Notifications
            var grantsPendingReview = grants.Count(g => g.Status == "Pending Review");

            // Return the dashboard data
            var dashboardData = new DashboardData
            {
                Grants = grants.Select(g => new GrantSummary
                {
                    Title = g.Title,
                    RequestedAmount = g.TotalFundsAllocated,
                    Status = g.Status,
                    Deadline = g.CompletionDate
                }).ToList(),
                KeyIndicators = new KeyIndicators
                {
                    ActiveGrants = activeGrants,
                    TotalFundsAllocated = totalFundsAllocated,
                    TotalFundsSpent = totalFundsSpent,
                    UpcomingDeadlines = upcomingDeadlines
                },
                Notifications = new Notifications
                {
                    UpcomingDeadlines = upcomingDeadlines,
                    PendingReviews = grantsPendingReview
                },
                Charts = new ChartData
                {
                    FundDistribution = new ChartDataSet
                    {
                        Labels = new List<string> { "Allocated", "Spent", "Remaining" },
                        Values = new List<decimal> { totalFundsAllocated, totalFundsSpent, totalFundsAllocated - totalFundsSpent }
                    },
                    SpendingTrends = new ChartDataSet
                    {
                        Labels = new List<string> { "Q1", "Q2", "Q3", "Q4" },
                        Values = new List<decimal> { 50000m, 60000m, 45000m, 70000m }
                    }
                },
                Reports = grants.Select(g => new ReportDTO
                {
                    Title = g.Title,
                    Link = "/reports/grant/" + g.Id
                }).ToList()
            };

            return Ok(dashboardData);
        }
    }
}
