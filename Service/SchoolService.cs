using GraphQLBasic.Models;
using Microsoft.AspNetCore.Authorization;
using HotChocolate;
using HotChocolate.Data;
using GraphQLBasic.Database;
using Microsoft.EntityFrameworkCore;
using GraphQLBasic.DAL;
using Wmhelp.XPath2.yyParser;

namespace GraphQLBasic.Service
{
   
    public class SchoolService //: ISchoolService
    {
        SchoolRepository _schoolRepository;

     
        List<Student> students = new List<Student>();
        List<Course> courses = new List<Course>();

        // Reading from the databse
        [UseDbContext(typeof(SchoolContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Student> GetStudents([ScopedService] SchoolContext context)
        {
            return context.Students;
        }

       


        [UseDbContext(typeof(SchoolContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> GetCourses([ScopedService] SchoolContext context)
        
        {
            return context.Courses;
        }


    }
}
