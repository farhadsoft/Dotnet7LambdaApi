using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repostories
{
    public class PersonRepostory : IPersonRepostory
    {
        private readonly AppDbContext context;

        public PersonRepostory(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Person> CreatPerson(Person person)
        {
            context.Add(person);
            await context.SaveChangesAsync();
            return person;
        }

        public async Task DeletePerson(string id)
        {
            var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            if (person is null) return;
            context.Remove(person);
            await context.SaveChangesAsync();
        }

        public async Task<Person> GetPersonById(string id)
        {
            return await context.Persons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Person>> GetPersons()
        {
            return await context.Persons.ToListAsync();
        }

        public async Task<Person> UpdatePerson(string id, Person oldPerson)
        {
            var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            person.Phone = oldPerson?.Phone;
            person.Country = oldPerson?.Country;
            await context.SaveChangesAsync();

            return person;
        }
    }
}
