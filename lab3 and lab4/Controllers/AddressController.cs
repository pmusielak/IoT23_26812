using Microsoft.AspNetCore.Mvc;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using Microsoft.Extensions.Logging;
using lab3.Database.Entities;

namespace lab3.AddressesFn
{
    [ApiController]
    [Route("address")]
    public class AddressControlller : ControllerBase
    {
        private readonly ILogger<AddressControlller> logger;
        private readonly IAddressesServices addressesServices;
        public AddressControlller(ILogger<AddressControlller> logger, IAddressesServices addressesServices){
            this.logger = logger;
            this.addressesServices = addressesServices;
        }
        [HttpGet]
        public IEnumerable<Address> GetAddresses(){
            return addressesServices.GetAddresses();
        }
        [HttpPost]
        public Address AddAddress([FromBody] Address address){
            return addressesServices.AddAddress(address);
        }
        [HttpGet("{id}")]
        public Address FindAddress([FromRoute] int id){
            return addressesServices.FindAddress(id);
        }
    }

}