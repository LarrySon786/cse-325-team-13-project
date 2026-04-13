
using StudentPortal.Components.Shared.Models;

namespace StudentPortal.Components.Shared.Services;

public class StudentAccount
{
    public Student studentProfile { get; set; }
    public bool isLoggedIn = false;

    public StudentAccount() //shouldnt be used anywhere
    {
        // Temporary test data
        studentProfile = new Student{ Id = -1, FirstName = "", LastName = "", Email = "", Phone = "", Bio = "", HashedPassword = "" };
    }

    public Student? GetStudent()
    {
        return studentProfile;
    }

    public bool IsLoggedIn()
    {
        return isLoggedIn;
    }

    //set user data that came from the database
    public bool SetLoggedIn(Student data)
    {
        isLoggedIn = true;
        studentProfile.Id = data.Id;
        studentProfile.FirstName = data.FirstName;
        studentProfile.LastName = data.LastName;
        studentProfile.Email = data.Email;
        studentProfile.Phone = data.Phone;
        studentProfile.Bio = data.Bio;
        studentProfile.HashedPassword = data.HashedPassword;
        return IsLoggedIn();
    }

    //change all data to the default
    public void LogOut()
    {
        isLoggedIn = false;
        studentProfile.Id = -1;
        studentProfile.FirstName = "";
        studentProfile.LastName = "";
        studentProfile.Email = "";
        studentProfile.Phone = "";
        studentProfile.Bio = "";
        studentProfile.HashedPassword = "";
    }
}







