using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STQAPWEB.Data;
using STQAPWEB.Models.Entites;

namespace STQAPWEB.Controllers.PostsFolder
{
    public class PostViewController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public PostViewController(ApplicationDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> Question(int sId)
        {
           var question = new Question { StudentId = sId };
            return View(question);
        }
        [HttpPost]
        public async Task<IActionResult> Question(Question viewModel)
        {
            var question = new Question
            {
                QuestionId = viewModel.QuestionId,
                StudentId = viewModel.StudentId,
                QuestionText = viewModel.QuestionText,
                DateTimeAsked = DateTime.Now,
            };
            await dbContext.QuestionQuestions.AddAsync(question);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List",new
            {
                sId= question.QuestionId,
            });
        }

        [HttpGet]
        public async Task<IActionResult> List(int sId)
        {
            // Assuming you have access to the current user's Id
            int currentUserId  = sId; // Replace this with your actual logic to get the current user's Id
            List<Question> user_quests = [];
            // Filter questions based on StudentId
            var questions = await dbContext.QuestionQuestions.ToListAsync();
            foreach (var item in questions)
            {
                if (item.StudentId.Equals(sId))
                {
                    user_quests.Add(item);
                }
            }
            return View(user_quests);
        }
        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var questions = await dbContext.QuestionQuestions.ToListAsync();
            return View(questions);
        }
        [HttpGet]
        public async Task<IActionResult> ListAllStudent()
        {
            var questions = await dbContext.QuestionQuestions.ToListAsync();
            return View(questions);
        }
        [HttpGet]
        public async Task<IActionResult> EditQuestion(int id)
        {
            var question = await dbContext.QuestionQuestions.FindAsync(id);
            return View(question);
        }
        [HttpPost]
        public async Task<IActionResult> EditQuestion(Question viewModel)
        {
            var user = await dbContext.QuestionQuestions.FindAsync(viewModel.QuestionId);
            if (user is not null)
            {
                user.QuestionId = viewModel.QuestionId;
                user.QuestionText = viewModel.QuestionText;
                user.StudentId = viewModel.StudentId;
                user.DateTimeAsked = viewModel.DateTimeAsked;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", new
            {
                id = viewModel.StudentId,
            });
        }
        [HttpGet]
        public async Task<IActionResult> AnswerQuestion(int qId)
        {
            var question = await dbContext.QuestionQuestions.FindAsync(qId);
            var answer = new Answer
            {
                QuestionId = question.QuestionId,
                StudentId = question.StudentId,
                QuestionText = question.QuestionText,
            };
            return View(answer);
        }
        [HttpPost]
        public async Task<IActionResult> AnswerQuestion(Answer answer)
        {
            var tanswer = new Answer
            {
                QuestionId= answer.QuestionId,
                AnswerText = answer.AnswerText,
                TeacherId = answer.TeacherId,
                StudentId= answer.StudentId,
                QuestionText= answer.QuestionText,
                DateTimeAnswered = DateTime.Now,
            };
            await dbContext.Answers.AddAsync(tanswer);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListAnswerd", new
            {
                tId = answer.TeacherId
            });
        }
        [HttpGet]
        public async Task<IActionResult> ListAnswerd(int tId)
        {
            // Assuming you have access to the current user's Id
            int currentUserId = tId; // Replace this with your actual logic to get the current user's Id
            List<Answer> user_quests = [];
            // Filter questions based on StudentId
            var questions = await dbContext.Answers.ToListAsync();
            foreach (var item in questions)
            {
                if (item.TeacherId.Equals(tId))
                {
                    user_quests.Add(item);
                }
            }
            return View(user_quests);
        }
        [HttpGet]
        public async Task<IActionResult> ListAnswerdStudent(int sId)
        {
            // Assuming you have access to the current user's Id
            int currentUserId = sId; // Replace this with your actual logic to get the current user's Id
            List<Answer> user_quests = [];
            // Filter questions based on StudentId
            var questions = await dbContext.Answers.ToListAsync();
            foreach (var item in questions)
            {
                if (item.StudentId.Equals(sId))
                {
                    user_quests.Add(item);
                }
            }
            return View(user_quests);
        }

        [HttpGet]
        public async Task<IActionResult> ListAllStudentForModerator()
        {
            var questions = await dbContext.QuestionQuestions.ToListAsync();
            return View(questions);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteQuestion(int qId)
        {
            var question = await dbContext.QuestionQuestions.FindAsync(qId);
            var answer = new Answer
            {
                QuestionId = question.QuestionId,
                StudentId = question.StudentId,
                QuestionText = question.QuestionText,
            };
            return View(answer);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(Answer answer)
        {
            var tanswer = new Answer
            {
                QuestionId = answer.QuestionId,
                AnswerText = answer.AnswerText,
                TeacherId = answer.TeacherId,
                StudentId = answer.StudentId,
                QuestionText = answer.QuestionText,
                DateTimeAnswered = DateTime.Now,
            };
            var question = await dbContext.QuestionQuestions.FindAsync(tanswer.QuestionId);
            if (question != null)
            {
                dbContext.QuestionQuestions.Remove(question);
                await dbContext.SaveChangesAsync();
            }
            
            return RedirectToAction("ListAllStudentForModerator");
        }
    }
}
