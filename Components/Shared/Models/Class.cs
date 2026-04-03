namespace StudentPortal.Components.Shared.Models
{
    public class Class
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public int credits { get; set; }

        // Optional future fields
        public string instructor { get; set; } = "";
        public string description { get; set; } = "";
        public DateTime startDate { get; set; }


        

        public Class() { }

        public Class(string name, string code, int credits)
        {
            this.name = name;
            this.code = code;
            this.credits = credits;
        }
    }
}






