using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Teacher")]
    public class Teacher : Person
    {
        //[Column("Cours")]
        public string Discipline { get; set; }
        public int Salary { get; set; }

        //[ForeignKey(nameof(Classroom))]
        public int? ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}
