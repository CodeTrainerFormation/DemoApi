namespace DomainModel
{
    // DTO (Data Transfer Object)
    // POCO (Plain Old CLR Object)
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
