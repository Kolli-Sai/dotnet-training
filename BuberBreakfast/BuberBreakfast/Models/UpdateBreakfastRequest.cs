namespace BuberBreakfast;

public class UpdateBreakfastRequest
{
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get; }

    public UpdateBreakfastRequest(string name, string description, DateTime startDateTime, DateTime endDateTime, List<string> savory, List<string> sweet)
    {

        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;

        Savory = savory;
        Sweet = sweet;
    }
}
