using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STQAPWEB.Data;
using STQAPWEB.Models;
using STQAPWEB.Models.Entites;
using System.Diagnostics;

namespace STQAPWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel viewModel)
        {
            var searchedUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == viewModel.Email);
            if (searchedUser == null)
            {
                return RedirectToAction("Registraction", "Home");
                
            }
            else
            {
                if (searchedUser.Password == viewModel.Password)
                {
                    var userView = new UserViewModel
                    {
                        Id = searchedUser.Id,
                        Name = searchedUser.Name,
                        Email = searchedUser.Email,
                        Password = searchedUser.Password,
                        InstitueId = searchedUser.InstitueId,
                        InstitueName = searchedUser.InstitueName,
                        isStudent = searchedUser.isStudent,
                        isTeacher = searchedUser.isTeacher,
                    };
                    return RedirectToAction("Profile", "StudentView", new
                    {
                        id = searchedUser.Id,
                    });
                }else
                {
                    return RedirectToAction("Registraction", "Home");
                }
                
                //return View(userView);
            }

        }

 
        [HttpGet]
        public IActionResult Registraction()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registraction(UserViewModel viewModel)
        {
            var newUser = new User
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                InstitueId = viewModel.InstitueId,
                InstitueName = viewModel.InstitueName,
                Password = viewModel.Password,
            };
            await dbContext.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
