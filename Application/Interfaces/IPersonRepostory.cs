using Domain.Models;

namespace Application.Interfaces;

public interface IPersonRepostory
{
    Task<ICollection<Person>> GetPersons();
    Task<Person> GetPersonById(int id);
    Task<Person> CreatPerson(Person person);
    Task<Person> UpdatePerson(string id, Person person);
    Task DeletePerson(int id);
}
