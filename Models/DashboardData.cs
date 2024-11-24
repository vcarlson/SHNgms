namespace SHNgms.Models
{
    public class DashboardData
    {
        public List<GrantSummary> Grants { get; set; }
        public KeyIndicators KeyIndicators { get; set; }
        public Notifications Notifications { get; set; }
        public ChartData Charts { get; set; }
        public List<ReportDTO> Reports { get; set; }  // Updated to ReportDTO
    }

    public class GrantSummary
    {
        public string Title { get; set; }
        public decimal RequestedAmount { get; set; }
        public string Status { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class KeyIndicators
    {
        public int ActiveGrants { get; set; }
        public decimal TotalFundsAllocated { get; set; }
        public decimal TotalFundsSpent { get; set; }
        public int UpcomingDeadlines { get; set; }
    }

    public class Notifications
    {
        public int UpcomingDeadlines { get; set; }
        public int PendingReviews { get; set; }
    }

    public class ChartData
    {
        public ChartDataSet FundDistribution { get; set; }
        public ChartDataSet SpendingTrends { get; set; }
    }

    public class ChartDataSet
    {
        public List<string> Labels { get; set; }
        public List<decimal> Values { get; set; }
    }

    // Correct location for ReportDTO class
    public class ReportDTO
    {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
