using Application.Interfaces;
using Domain.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace Infrastructure.Repostories
{
    public class PersonRedisRepo : IPersonRepostory
    {
        private readonly IDatabase _redis;

        public PersonRedisRepo(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }

        public async Task CreatePerson(Person person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            var result = JsonSerializer.Serialize(person);
            await _redis.StringSetAsync(person.Id, result);
            await _redis.SetAddAsync("Persons", result);
        }

        public Task DeletePerson(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> GetPersonById(string id)
        {
            var result = await _redis.StringGetAsync(id);
            if (!string.IsNullOrEmpty(result))
            {
                return JsonSerializer.Deserialize<Person>(result);
            }
            return null;
        }

        public async Task<IEnumerable<Person?>?> GetPersons()
        {
            var result = await _redis.SetMembersAsync("Persons");
            if (result.Length > 0)
            {
                return Array.ConvertAll(result, val => JsonSerializer.Deserialize<Person>(val)).ToList();
            }
            return null;
        }

        public Task<Person> UpdatePerson(string id, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
