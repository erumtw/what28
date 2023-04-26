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

    }
}
