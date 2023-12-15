using System.Net;
using System.Text.Json;
using Azure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using lab3.Database.Entities;
using lab3.Services;

namespace CdvAzure.Functions
{
    public class PeopleFn
    {
        private readonly ILogger _logger;
        private readonly DatabasePeopleService peopleService;

        public PeopleFn(ILoggerFactory loggerFactory, DatabasePeopleService peopleService)
        {
            _logger = loggerFactory.CreateLogger<PeopleFn>();
            this.peopleService = peopleService;
        }

        [Function("PeopleFn")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", "delete", "put")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            switch (req.Method){
                case "POST":
                    StreamReader reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var json = reader.ReadToEnd();
                    var person = JsonSerializer.Deserialize<Person>(json);
                    var res = peopleService.AddPerson(person);
                    response.WriteAsJsonAsync(res);
                    break;
                case "PUT":
                    StreamReader put_reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var put_json = put_reader.ReadToEnd();
                    var put_person = JsonSerializer.Deserialize<Person>(put_json);
                    //var put_res = peopleService.Update(put_person.Id, put_person.FirstName, put_person.LastName);
                    //response.WriteAsJsonAsync(put_res);
                    break;
                case "GET":
                    var people = peopleService.GetPeople();
                    response.WriteAsJsonAsync(people);
                    break;
                case "DELETE":
                    StreamReader delete_reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var delete_json = delete_reader.ReadToEnd();
                    var delete_person = JsonSerializer.Deserialize<Person>(delete_json);
                    //peopleService.Delete(delete_person.Id);
                    break;
            }

            //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            //response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
