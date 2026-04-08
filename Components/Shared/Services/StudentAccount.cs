
using StudentPortal.Components.Shared.Models;

namespace StudentPortal.Components.Shared.Services;

public class StudentAccount
{
    public Student studentProfile { get; set; }
    public bool isLoggedIn = false;

    public StudentAccount()
    {
        // Temporary test data
        studentProfile = new Student{ FirstName = "", LastName = "", Email = "", Phone = "", Bio = "", HashedPassword = "" };
    }

    public Student? GetStudent()
    {
        return studentProfile;
    }

    public bool IsLoggedIn()
    {
        return isLoggedIn;
    }

    public bool SetLoggedIn(Student data)
    {
        isLoggedIn = true;
        studentProfile.FirstName = data.FirstName;
        studentProfile.LastName = data.LastName;
        studentProfile.Email = data.Email;
        studentProfile.Phone = data.Phone;
        studentProfile.Bio = data.Bio;
        studentProfile.HashedPassword = data.HashedPassword;
        return IsLoggedIn();
    }

    public void UpdateStudent(Student updatedStudent)
    {
        if (!IsLoggedIn())
            return;
        studentProfile.FirstName = updatedStudent.FirstName;
        studentProfile.LastName = updatedStudent.LastName;
        studentProfile.Email = updatedStudent.Email;
        studentProfile.Phone = updatedStudent.Phone;
        studentProfile.Bio = updatedStudent.Bio;
        studentProfile.HashedPassword = updatedStudent.HashedPassword;
    }
    public void LogOut()
    {
        isLoggedIn = false;
        studentProfile.FirstName = "";
        studentProfile.LastName = "";
        studentProfile.Email = "";
        studentProfile.Phone = "";
        studentProfile.Bio = "";
        studentProfile.HashedPassword = "";
    }
}







