using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        public SchoolContext()
            : base()
        {
        }

        public SchoolContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
