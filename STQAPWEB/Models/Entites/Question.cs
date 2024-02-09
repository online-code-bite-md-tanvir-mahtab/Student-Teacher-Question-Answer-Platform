using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace STQAPWEB.Models.Entites
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int StudentId { get; set; }

        public string QuestionText { get; set; }

        public DateTime DateTimeAsked { get; set; }
    }
}
