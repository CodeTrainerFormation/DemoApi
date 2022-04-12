using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    // DTO (Data Transfer Object)
    // POCO (Plain Old CLR Object)
    [Table("Person")]
    public class Person
    {
        //[Key]
        public int PersonId { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
