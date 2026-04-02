using StudentPortal.Components.Shared.Models;

namespace StudentPortal.Components.Shared.Services
{
    public class StudentSchedule
    {
        public int studentAccountNumber { get; set; } = 000000000;
        public List<Class> classes { get; set; } = new List<Class>();





        public StudentSchedule()
        {
            // SAMPLE SCHEDULE
            Class newClass = new Class(".Net Software", "CSE325", 3);
            classes.Add(newClass);
        }

        // Return the student's current classes
        public List<Class> getSchedule()
        {
            return classes;
        }

        // Remove a class
        public void dropClass(string code)
        {
            var classToRemove = classes.FirstOrDefault(c => c.code == code);

            if (classToRemove != null)
            {
                classes.Remove(classToRemove);
            }
        }

        // Add a class
        public void registerClass(Class newClass)
        {
            classes.Add(newClass);
        }
    }
}