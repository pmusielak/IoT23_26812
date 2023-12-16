namespace lab3.Database.Entities
{
    public class Person
    {
        public int Id{get;set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public Address address{get; set;}
        public int AddressId {get; set;}
        
    }
}