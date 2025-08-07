using Microsoft.EntityFrameworkCore;

namespace InternetProgrammingProject.Models
{
    public class DbResourceContext : DbContext
    {
        public DbResourceContext(DbContextOptions<DbResourceContext> options)
            : base(options) 
        { }

        public DbSet<Resource> Resources { get; set; }
    }
}
