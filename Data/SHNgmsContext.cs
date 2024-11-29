using Microsoft.EntityFrameworkCore;

namespace SHNgms.Models
{
    public class SHNgmsContext : DbContext
    {
        public SHNgmsContext(DbContextOptions<SHNgmsContext> options)
            : base(options)
        { }

        // DbSet for the Expense model
        public required DbSet<Expense> Expenses { get; set; }

        // DbSet for the Grant model
        public required DbSet<Grant> Grants { get; set; }

        // DbSet for the Application model
        public required DbSet<Application> Applications { get; set; }


        // DbSet for the AuditLog model
        public required DbSet<AuditLog> AuditLogs { get; set; }

        // DbSet for the User model
        public required DbSet<User> Users { get; set; }

        // You can add more DbSets for other models if needed
    }
}
