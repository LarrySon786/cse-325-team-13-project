namespace StudentPortal.Components.Shared.Models;

//currently unused
public class Degree
{
    //properties
    public string code { get; set; } = "";
    public string name { get; set; } = "";
    public int creditsRequired { get; set; }
    public List<Class> classesRequired = [];

    //constructor
    public Degree(string code, string name, int creditsRequired, List<Class> classesRequirement)
    {
        this.code = code;
        this.name = name;
        this.creditsRequired = creditsRequired;
        classesRequired = classesRequirement;
    }



}








