using Microsoft.EntityFrameworkCore;
using StudentPortalWeb.Models.Entites;

namespace StudentPortalWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
