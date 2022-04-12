namespace DomainModel
{
    public class Teacher : Person
    {
        public string Discipline { get; set; }
        public int Salary { get; set; }

        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}
