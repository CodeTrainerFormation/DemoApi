using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Student")]
    public class Student : Person
    {
        public double Average { get; set; }
        public bool IsClassDelegate { get; set; }

        public int? ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}
