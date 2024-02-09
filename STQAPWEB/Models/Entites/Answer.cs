using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace STQAPWEB.Models.Entites
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        public int TeacherId { get; set; }
        public int StudentId { get; set; }

        public string QuestionText { get; set; }

        public string AnswerText { get; set; }

        public DateTime DateTimeAnswered { get; set; }
    }
}
