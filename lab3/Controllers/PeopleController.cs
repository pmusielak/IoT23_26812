using Microsoft.AspNetCore.Mvc;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using Microsoft.Extensions.Logging;
using CdvAzure.Functions;
using lab3.Database.Entities;

namespace lab3.PeopleFn
{
    [ApiController]
    [Route("person")]
    public class PeopleControlller : ControllerBase
    {
        private readonly ILogger<PeopleControlller> logger;
        private readonly IPeopleService peopleService;
        public PeopleControlller(ILogger<PeopleControlller> logger, IPeopleService peopleService){
            this.logger = logger;
            this.peopleService = peopleService;
        }
        [HttpGet]
        public IEnumerable<Person> GetPeople(){
            return peopleService.GetPeople();
        }
        [HttpPost]
        public Person AddPerson([FromBody] Person person){
            return peopleService.AddPerson(person);
        }
        [HttpGet("{id}")]
        public Person FindPerson([FromRoute] int id){
            return peopleService.FindPerson(id);
        }
    }

}