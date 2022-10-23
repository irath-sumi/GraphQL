using GraphQLBasic.Models;

namespace GraphQLBasic.IService
{
    public interface ISchoolService
    {
        // List<Student> GetStudents();
        //   Student GetStudentById(string id);
        public IQueryable<Course> GetCourses();
     

        Task<List<Student>> GetStudentsFromDb();
        //  Course GetCourseById(string id);   
        //  Course GetCourseByName(string courseName);

    }
}
