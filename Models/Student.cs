using System.Diagnostics.Metrics;

namespace GraphQLBasic.Models
{
    public class Student
    {
        public string? Name { get; set; }

        public int StudentId { get; set; }
        
        public int Roll { get; set; }

        public string? Grade { get; set; }

        public List<Course>? courses { get; set; }
    }
}
