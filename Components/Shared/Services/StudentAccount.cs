
using StudentPortal.Components.Shared.Models;

namespace StudentPortal.Components.Shared.Services;

public class StudentAccount
{
    public Student studentProfile { get; set; }

    public StudentAccount()
    {
        // Temporary test data
        studentProfile = new Student("Henry", "Smith", "hen@gmail.com", "000-000-0000", "Henry is cool.");
    }

    public Student GetStudent()
    {
        return studentProfile;
    }

    public void UpdateStudent(Student updatedStudent)
    {
        studentProfile.studentFirstName = updatedStudent.studentFirstName;
        studentProfile.studentLastName = updatedStudent.studentLastName;
        studentProfile.email = updatedStudent.email;
        studentProfile.phone = updatedStudent.phone;
        studentProfile.studentBio = updatedStudent.studentBio;
    }
}







