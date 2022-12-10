using Domain.Models;

namespace Application.Interfaces;

public interface IPersonRepostory
{
    Task<IEnumerable<Person?>?> GetPersons();
    Task<Person?> GetPersonById(string id);
    Task CreatePerson(Person person);
    Task<Person> UpdatePerson(string id, Person person);
    Task DeletePerson(string id);
}
