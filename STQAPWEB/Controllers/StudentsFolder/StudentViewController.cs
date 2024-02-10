using Microsoft.AspNetCore.Mvc;
using STQAPWEB.Data;
using STQAPWEB.Models;
using STQAPWEB.Models.Entites;

namespace STQAPWEB.Controllers.StudentsFolder
{
    public class StudentViewController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentViewController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public  async Task<IActionResult> Profile(int Id)
        {
            var user = await dbContext.Users.FindAsync(Id);
            var profile = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                InstitueName = user.InstitueName,
                InstitueId = user.InstitueId,
                Password = user.Password,
                isStudent = user.isStudent,
                isTeacher = user.isTeacher,
                isModerator = user.isModerator,
            };
            return View(profile);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User viewModel)
        {
            var user = await dbContext.Users.FindAsync(viewModel.Id);
            if (user is not null)
            {
                user.Name = viewModel.Name;
                user.Email = viewModel.Email;
                user.InstitueName = viewModel.InstitueName;
                user.InstitueId = viewModel.InstitueId;
                user.Password = viewModel.Password;
                user.isStudent = viewModel.isStudent;
                user.isTeacher = viewModel.isTeacher;
                user.isModerator = viewModel.isModerator;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Profile", "StudentView", new
            {
                id = viewModel.Id,
            });
        }
    }
}
