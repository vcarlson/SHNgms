using Microsoft.EntityFrameworkCore;
using SHNgms.Models;

namespace SHNgms.Data
{
    public class SHNgmsContext : DbContext
    {
        public SHNgmsContext(DbContextOptions<SHNgmsContext> options) : base(options) {}

        // DbSets for your models
        public DbSet<Application> Applications { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Grant> Grants { get; set; }
        public DbSet<Milestone> Milestones { get; set; }

        // Configure relationships (foreign keys, etc.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Application - Review Relationship
            modelBuilder.Entity<Review>()
                .HasOne(r => r.GrantApplication)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.GrantApplicationId);

            // Application - Document Relationship
            modelBuilder.Entity<Document>()
                .HasOne(d => d.GrantApplication)
                .WithMany(a => a.Documents)
                .HasForeignKey(d => d.GrantApplicationId);

            // User - Review Relationship
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.ReviewerId);

            // User - Notification Relationship
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            // Transaction - Grant Relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Grant)
                .WithMany()
                .HasForeignKey(t => t.GrantId);

            // Report - Grant Relationship
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Grant)
                .WithMany()
                .HasForeignKey(r => r.GrantId);

            // Milestone - Grant Relationship
            modelBuilder.Entity<Milestone>()
                .HasOne(m => m.Grant)
                .WithMany(g => g.Milestones)
                .HasForeignKey(m => m.GrantId);
        }
    }
}
