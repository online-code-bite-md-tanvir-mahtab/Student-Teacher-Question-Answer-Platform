namespace STQAPWEB.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public int StudentId { get; set; }

        public string QuestionText { get; set; }

        public DateTime DateTimeAsked { get; set; }
    }
}
