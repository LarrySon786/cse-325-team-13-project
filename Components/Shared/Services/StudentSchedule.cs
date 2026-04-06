using StudentPortal.Components.Shared.Models;

namespace StudentPortal.Components.Shared.Services
{
    public class StudentSchedule
    {
        public List<Class> classes { get; set; } = new List<Class>();
        public event Action? OnChange;



        public StudentSchedule()
        {
            // SAMPLE SCHEDULE
            Class newClass = new Class(
                ".Net Software",
                "CSE325",
                3,
                new DateOnly(2026, 1, 1),
                new DateOnly(2026, 2, 28),
                new Dictionary<DayOfWeek, TimeOnly>
                {
                    { DayOfWeek.Monday, new TimeOnly(9, 0) },
                    { DayOfWeek.Wednesday, new TimeOnly(9, 0) }
                },
                "Introduction to .NET development",
                "Dr. Smith",
                new List<string>()
            );
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
                OnChange?.Invoke();
            }
        }

        // Add a class
        public void registerClass(Class newClass)
        {
            classes.Add(newClass);
            OnChange?.Invoke();
        }
    }
}







