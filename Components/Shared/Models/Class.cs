namespace StudentPortal.Components.Shared.Models
{
    public class Class
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public int credits { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public Dictionary<DayOfWeek, TimeOnly>? classSchedule;
        public string description { get; set; } = "";
        public string instructor { get; set; } = "";
        public List<string> prerequisiteClasses { get; set; }


        public Class() { }

        public Class(string name, string code, int credits, DateOnly startDate, DateOnly endDate,
        Dictionary<DayOfWeek, TimeOnly> schedule, string description, string instructor,
        List<string> prerequisiteClasses)
        {
            this.name = name;
            this.code = code;
            this.credits = credits;
            this.startDate = startDate;
            this.endDate = endDate;
            classSchedule = schedule;
            this.description = description;
            this.instructor = instructor;
            this.prerequisiteClasses = [];
        }
    }
}






