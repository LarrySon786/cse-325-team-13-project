using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Components.Shared.Models;

namespace StudentPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // define tables

        public DbSet<Student> Students { get; set; } 
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassToStudent> Enrollments { get; set; }

        public void AddClass(string code, string name, int credits, string instructor, string description, string startDate)
        {
            Classes.Add(new Class{ Code = code, Name = name, Credits = credits, Instructor = instructor, Description = description, StartDate = startDate });
        }
        public void AddClasses(params (string code, string name, int credits, string instructor, string description, string startDate)[] classes)
        {
            foreach ((string code, string name, int credits, string instructor, string description, string startDate) in classes)
            {
                AddClass(code, name, credits, instructor, description, startDate);
            }
        }

        public string HashPassword(string password)
        {
            return password; //todo - hash password
        }
        

        public void AddStudent(string firstName, string lastName, string email, string phone, string bio, string password)
        {
            string hashedPassword = HashPassword(password);

            Students.Add(new Student{ FirstName = firstName, LastName = lastName, Email = email, Phone = phone, Bio = bio, HashedPassword = hashedPassword });
            SaveChanges();

        }
        

        public void AddStudents(params (string firstName, string lastName, string email, string phone, string bio, string password)[] students)
        {
            foreach ((string firstName, string lastName, string email, string phone, string bio, string password) in students)
            {
                AddStudent(firstName, lastName, email, phone, bio, password);
            }
        }


        public Student? GetStudent(string email, string hashedPassword)
        {
            var result = Students.Where(s => s.Email == email && s.HashedPassword == hashedPassword);
            if (result == null)
                return null;
            var resultList = result.ToList();
            if (resultList.Count == 0)
                return null;
            return resultList[0];
        }
        

        
        public void SetStudent(string email, string password, Student data, Student studentProfile)
        {
            var result = Students.Where(s => s.Email.Equals(email) && s.HashedPassword.Equals(password))?.ToList();
            if (result == null || result.Count == 0)
                return;
            var student = result.First();
            //database
            student.FirstName = data.FirstName;
            student.LastName = data.LastName;
            student.Email = data.Email;
            student.Phone = data.Phone;
            student.Bio = data.Bio;
            student.HashedPassword = data.HashedPassword;

            //session
            studentProfile.FirstName = data.FirstName;
            studentProfile.LastName = data.LastName;
            studentProfile.Email = data.Email;
            studentProfile.Phone = data.Phone;
            studentProfile.Bio = data.Bio;
            studentProfile.HashedPassword = data.HashedPassword;
            SaveChanges();
        }

        public void RegisterClass(int studentId, int classId)
        {
            Enrollments.Add(new ClassToStudent{ StudentId = studentId, ClassId = classId });
            SaveChanges();
        }
        public void RegisterClasses(params (int studentId, int classId)[] enrollments)
        {
            foreach ((int studentId, int classId) in enrollments)
            {
                RegisterClass(studentId, classId);
            }
        }
        public void UnRegisterClass(int studentId, int classId)
        {
            Enrollments.Where(e => e.StudentId == studentId && e.ClassId == classId).ExecuteDelete();
            SaveChanges();
        }

        public List<Class> GetClassesEnrolled(int studentId)
        {
            var classIds = Enrollments.Where(e => e.StudentId == studentId).Select(e => e.ClassId).ToList();
            return Classes.Where(c => classIds.Contains(c.Id)).ToList();
        }
        public List<Class> GetClassesNotEnrolled(int studentId)
        {
            var classIds = Enrollments.Where(e => e.StudentId == studentId).Select(e => e.ClassId).ToList();
            return Classes.Where(c => !classIds.Contains(c.Id)).ToList();
        }
        
    }
}