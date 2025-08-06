using Microsoft.EntityFrameworkCore;

namespace InternetProgrammingProject.Models
{
    public class DbSignupContext : DbContext
    {
        public DbSignupContext(DbContextOptions<DbSignupContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
