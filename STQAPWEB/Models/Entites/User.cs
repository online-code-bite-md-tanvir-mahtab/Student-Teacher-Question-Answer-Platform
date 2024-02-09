namespace STQAPWEB.Models.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string InstitueName { get; set; }
        public int InstitueId { get; set; }
        public string Password { get; set; }
        public bool isStudent { get; set; }
        public bool isTeacher {  get; set; }
    }
}
