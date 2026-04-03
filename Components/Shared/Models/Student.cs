namespace StudentPortal.Components.Shared.Models;


public class Student
{
    public string studentFirstName { get; set; } = "";
    public string studentLastName { get; set; } = "";
    public string email { get; set; } = "";
    public string phone { get; set; } = "";
    public string studentBio { get; set; } = "";
    public int studentAccountNumber { get; set; } = 000000000;

    public Student(string firstName, string lastName, string emails, string phones, string studentBios)
    {

        studentFirstName = firstName;
        studentLastName = lastName;
        email = emails;
        phone = phones;
        studentBio = studentBios;
    }


}