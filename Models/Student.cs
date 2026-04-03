namespace StudentPortal.Models
{
    public class Student
    {
        public int Id { get; set; }       // Primary key
        public string Name { get; set; } = "";  // User's name
        public string Email { get; set; } = ""; // User's email
    }
}