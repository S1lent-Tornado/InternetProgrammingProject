using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.ObjectPool;

namespace InternetProgrammingProject.Models
{
    public class DbSignupContextFactory : IDesignTimeDbContextFactory<DbSignupContext>
    {
        public DbSignupContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<DbSignupContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
            return new DbSignupContext(optionsBuilder.Options);
        }
    }
}
