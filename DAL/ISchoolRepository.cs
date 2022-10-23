using GraphQLBasic.Models;
using GraphQLBasic.Service;

namespace GraphQLBasic.DAL
{
    public interface ISchoolRepository
    {

        public List<Student> GetStudentsFromDb();
      //  public List<Student> GetStudents();

       // public List<Course>  FetchCourses();
    }
}
