using Microsoft.EntityFrameworkCore;
using STQAPWEB.Models.Entites;

namespace STQAPWEB.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { 
        }
        public DbSet<User> Users { get; set; }

        public DbSet<UserQuestions> UsersQuestions { get; set; }

        public DbSet<Question> QuestionQuestions { get; set; }
        public DbSet<Answer> Answers {  get; set; }    

    }

    
}
