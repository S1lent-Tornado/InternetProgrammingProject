using Microsoft.EntityFrameworkCore;
namespace InternetProgrammingProject.Models
{
    public class DbTasksContext : DbContext
    {
        public DbTasksContext(DbContextOptions<DbTasksContext> options)
            : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }
}
