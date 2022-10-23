using GraphQLBasic.Database;


namespace GraphQLBasic.Models
{

    public class QueryType //: ObjectType<Student>
    {
        public QueryType()
        {

        }
        // EF to query only the entered field in the Banana Cake Pop and not all fields.
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Student> GetStudents([Service] SchoolContext schoolContext)
            => schoolContext.Students;
      
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> GetCourses([Service] SchoolContext schoolContext)
            => schoolContext.Courses;

        //public IQueryable<Student> GetStudents([Service] ISchoolService schoolService)
        //{
        //    var x =  schoolService.GetStudentsFromDb();
        //    return null;
        //}
    }
}
