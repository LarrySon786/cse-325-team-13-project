namespace StudentPortal.Components.Shared.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public int Credits { get; set; }

        // Optional future fields
        public string Instructor { get; set; } = "";
        public string Description { get; set; } = "";
        public string StartDate { get; set; } = "";


        

        public Class() { }

        public Class(string name, string code, int credits)
        {
            this.Name = name;
            this.Code = code;
            this.Credits = credits;
        }
    }
}






