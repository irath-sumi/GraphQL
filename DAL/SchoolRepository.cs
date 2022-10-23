using GraphQLBasic.Database;
using GraphQLBasic.Models;
//using GraphQLBasic.Service;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBasic.DAL
{
    public class SchoolRepository
    {
        private SchoolContext _context;
        private SchoolContext Context { get { return _context; } }
        public SchoolRepository(SchoolContext dbContext)
        {
            _context = dbContext;

        }
        //public SchoolRepository()
        //{
        //    _context = new SchoolContext();
        //}
        public async Task<List<Student>> GetStudentsFromDb()
        {
            //_context = new SchoolContext();
            List<Student> students;
            students = (from s in _context.Students select s).ToList();
            return students;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            List<Course> courses;
            courses = (from s in _context.Courses select s).ToList();
            return courses;
        }

      
        
    }
}
