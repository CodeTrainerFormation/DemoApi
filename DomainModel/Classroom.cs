using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table("Classroom")]
    public class Classroom
    {
        //propriétés scalaires
        public int ClassroomId { get; set; }
        public string Name { get; set; }
        [Range(0, 8)]
        public int Floor { get; set; }
        public string Corridor { get; set; }

        //propriétés de navigation
        public ICollection<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
    }
}
