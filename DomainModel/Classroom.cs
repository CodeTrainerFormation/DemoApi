using System.Collections.Generic;

namespace DomainModel
{
    public class Classroom
    {
        //propriétés scalaires
        public int ClassroomId { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string Corridor { get; set; }

        //propriétés de navigation
        public ICollection<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
    }
}
