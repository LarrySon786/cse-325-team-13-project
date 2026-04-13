//provides a many-to-many relationship between classes and students to represent enrollments
public class ClassToStudent
{

  //properties
  public int Id { get; set; }
  public int ClassId { get; set; }
  public int StudentId { get; set; }
}