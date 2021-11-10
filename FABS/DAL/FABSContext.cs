using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Business_logic.Model;

namespace DAL
{
    public class FABSContext : DbContext
    {
        public FABSContext(DbContextOptions<FABSContext> options) : base(options) { }

        public virtual DbSet<Person> People { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FABSContext>
    {
        public FABSContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyCookingMaster.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<FABSContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectionString);
            return new FABSContext(builder.Options);
        }
    }
}