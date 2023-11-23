

using CdvAzure.Functions;
using lab3.Database;

namespace lab3.Services
{
    public class DatabasePeopleService: IPeopleService
    {
        private readonly PeopleDb db;

        public DatabasePeopleService(PeopleDb db)
        {
            this.db = db;
        }
        public IEnumerable<Person> GetPeople()
        {
            var peopleList = db.People.Select(s=>new Person{
                FirstName = s.FirstName,
                Id = s.Id,
                LastName = s.LastName
            });
        }
    }
}