using _111.Schemas;
using Microsoft.EntityFrameworkCore;

namespace MySQLApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Coal> Coal { get; set; }
        public DbSet<Coals> Coals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }

        public DbSet<Verifications> Verifications { get; set; }

        public DbSet<Coal_names> Coal_names { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;database=coaldelivery;",
                new MySqlServerVersion(new Version(10, 1, 38))
            );
        }
    }
}