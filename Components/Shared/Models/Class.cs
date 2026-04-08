namespace StudentPortal.Components.Shared.Models
{
    public class Class
    {

        public int Id { get; set; }
//         public string Code { get; set; } = "";
//         public string Name { get; set; } = "";
//         public int Credits { get; set; }

//         // Optional future fields
//         public string Instructor { get; set; } = "";
//         public string Description { get; set; } = "";
//         public string StartDate { get; set; } = "";

        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public int Credits { get; set; } = 0;
        public string StartDate { get; set; } = "";
        public string EndDate { get; set; } = "";
        public Dictionary<DayOfWeek, TimeOnly>? ClassSchedule = new();
        public string Description { get; set; } = "";
        public string Instructor { get; set; } = "";
        public List<string>? PrerequisiteClasses { get; set; }


        public Class() { }

        public Class(string name, string code, int credits, string startDate, string endDate,
        Dictionary<DayOfWeek, TimeOnly> schedule, string description, string instructor,
        List<string> prerequisiteClasses)
        {

//             this.Name = name;
//             this.Code = code;
//             this.Credits = credits;
            this.Name = name;
            this.Code = code;
            this.Credits = credits;
            this.StartDate = startDate;
            this.EndDate = endDate;
            ClassSchedule = schedule;
            this.Description = description;
            this.Instructor = instructor;
            this.PrerequisiteClasses = [];
        }
    }
}






