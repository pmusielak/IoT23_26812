using CdvAzure.Functions;
using lab3.Database;
using lab3.Database.Entities;

namespace lab3.Services
{
    public class DatabasePeopleService: IPeopleService
    {
        private readonly PeopleDb db;

        public DatabasePeopleService(PeopleDb db)
        {
            this.db = db;
        }
        public Person AddPerson(Person person){
            var entity = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            db.People.Add(entity);
            db.SaveChanges();
            person.Id = entity.Id;
            return person;
        }
        public IEnumerable<Person> GetPeople()
        {
            var peopleList = db.People.Select(s => new Person
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName
            });

            return peopleList;
        }

        Person IPeopleService.FindPerson(int id)
        {
            var person = db.People.First(w=>w.Id == id);
            return MapToDTO(person);
        }
        public Person MapToDTO(Person entity){
            return new Person
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Id = entity.Id
            };
        }
    }
}