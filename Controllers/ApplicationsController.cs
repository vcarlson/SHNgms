using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHNgms.Models;
using SHNgms.Data;

namespace SHNgms.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly SHNgmsContext _context;

        public ApplicationsController(SHNgmsContext context)
        {
            _context = context;
        }

        // GET: /Applications/Index
        [HttpGet]
        public IActionResult Index()
        {
            // Add any logic needed for the dashboard here
            return View();
        }

        // Example API endpoints, if needed
        [HttpGet("api/dashboard")]
        public async Task<ActionResult<DashboardData>> GetDashboardData()
        {
            var applications = await _context.Applications.ToListAsync();

            var activeGrants = applications.Count(a => a.Status == ApplicationStatus.Approved);
            var totalFundsAllocated = applications.Sum(a => a.FundingRequested);
            var totalFundsSpent = applications.Sum(a => a.FundsSpent);
            var upcomingDeadlines = applications.Count(a => a.Deadline > DateTime.Now);

            var dashboardData = new DashboardData
            {
                Grants = applications.Select(a => new GrantSummary
                {
                    Title = a.Title,
                    RequestedAmount = a.FundingRequested,
                    Status = a.Status.ToString(),
                    Deadline = a.Deadline
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
                    PendingReviews = applications.Count(a => a.Status == ApplicationStatus.Pending)
                }
            };

            return Ok(dashboardData);
        }

        // Additional CRUD methods can be added here
    }
}
