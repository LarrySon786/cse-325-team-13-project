namespace StudentPortal.Components.Shared.Models;

public class Degree
{
    // Class Variables
    public string code { get; set; } = "";
    public string name { get; set; } = "";
    public int creditsRequired { get; set; }
    public List<Class> classesRequired = [];

    // Class Constructor
    public Degree(string code, string name, int creditsRequired, List<Class> classesRequirement)
    {
        this.code = code;
        this.name = name;
        this.creditsRequired = creditsRequired;
        classesRequired = classesRequirement;
    }



}








