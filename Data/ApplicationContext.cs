
using Microsoft.EntityFrameworkCore;
using StockApplication_UserDomain.Models;

namespace StockApplication_UserDomain.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=tradexclouduserdomainpostgresdb.cfg860mwu3jf.ap-south-1.rds.amazonaws.com; Database=postgres; Username=TradeXCloudAdmin; password=tradexcloud123");
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<AccountInfo> AccountInfo { get; set; }
        public DbSet<StockInfo> StockInfo { get; set; }
    }
}
