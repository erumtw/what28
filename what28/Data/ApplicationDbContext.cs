using Microsoft.EntityFrameworkCore;
using what28.Models;

namespace what28.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<DeliverPost> DeliverPosts { get; set; }
        public DbSet<EaterPost> EaterPosts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Account Entity Configuration
            modelBuilder.Entity<Account>()
                .HasMany(a => a.DeliverPosts)
                .WithOne(dp => dp.Poster)
                .HasForeignKey(dp => dp.PosterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.EaterPosts)
                .WithOne(ep => ep.Poster)
                .HasForeignKey(ep => ep.PosterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Orders)
                .WithOne(o => o.Orderer)
                .HasForeignKey(o => o.OrdererId)
                .OnDelete(DeleteBehavior.Cascade);

            // DeliverPost Entity Configuration
            modelBuilder.Entity<DeliverPost>()
                .HasMany(dp => dp.Orderers)
                .WithOne(o => o.DeliverPost)
                .HasForeignKey(o => o.DeliverPostId)
                .OnDelete(DeleteBehavior.Cascade);

            // EaterPost Entity Configuration
            modelBuilder.Entity<EaterPost>()
                .HasOne(ep => ep.Buyer)
                .WithMany()
                .HasForeignKey(ep => ep.BuyerId)
                .OnDelete(DeleteBehavior.SetNull);

            // Order Entity Configuration
            modelBuilder.Entity<Order>()
                .HasKey(o => new { o.Id });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.DeliverPost)
                .WithMany(dp => dp.Orderers)
                .HasForeignKey(o => o.DeliverPostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Orderer)
                .WithMany()
                .HasForeignKey(o => o.OrdererId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
