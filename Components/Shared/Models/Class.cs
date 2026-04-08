namespace StudentPortal.Components.Shared.Models
{
    public class Class
    {

//         public int Id { get; set; }
//         public string Code { get; set; } = "";
//         public string Name { get; set; } = "";
//         public int Credits { get; set; }

//         // Optional future fields
//         public string Instructor { get; set; } = "";
//         public string Description { get; set; } = "";
//         public string StartDate { get; set; } = "";

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

//             this.Name = name;
//             this.Code = code;
//             this.Credits = credits;
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






