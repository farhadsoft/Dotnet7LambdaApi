namespace Domain.Models;

public class Person
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;
    public string? Country { get; set; }
    public string? Phone { get; set; }

}
