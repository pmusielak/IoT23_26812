namespace CdvAzure.Functions
{
    public class PeopleService
    {
        private List<PersonServiceEntity> people {get;} = new List<PersonServiceEntity>();
        public PersonServiceEntity Add(string firstName, string lastName)
        {
            var person = new PersonServiceEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Id = people.Count + 1
            };
            people.Add(person);
            return person;
        }

        public PersonServiceEntity Update(int id, string firstName, string lastName)
        {
            var person = people.First(w => w.Id == id);
            person.FirstName = firstName;
            person.LastName = lastName;

            return person;
        }

        public void Delete(int id)
        {
            var person = people.First(w => w.Id ==id);
            people.Remove(person);
        }

        public PersonServiceEntity Find(int id)
        {
            return people.First(w => w.Id == id);
        }

        public IEnumerable<PersonServiceEntity> Get()
        {
            return people;
        }
    }
    public class PersonServiceEntity
    {
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }
}