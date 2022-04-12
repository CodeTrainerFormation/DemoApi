namespace DomainModel
{
    public class Student : Person
    {
        public double Average { get; set; }
        public bool IsClassDelegate { get; set; }

        public int? ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}
