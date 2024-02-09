using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace STQAPWEB.Models.Entites
{
    public class UserQuestions
    {
        public int Id { get; set; }
        public int UserQuestionId { get; set; }

        public int StudentId { get; set; }
        public int QuestionId { get; set; }

    }
}
