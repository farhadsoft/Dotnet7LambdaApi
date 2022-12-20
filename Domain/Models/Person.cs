namespace Domain.Models;

public class Person
{
    public string Id { get; set; } = $"person:{Guid.NewGuid()}";
    public string Name { get; set; } = null!;
    public string? Country { get; set; }
    public string? Phone { get; set; }

}
