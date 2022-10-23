using GraphQLBasic.Models;

namespace GraphQLBasic
{
    public class Subscription
    {
        [Subscribe]
      //  [Topic]
        public Student OnStudentAdded([EventMessage] Student student) => student;

        // Another way to write
        //public Student OnStudentAdded([EventMessage] Student student)
        //{
        //    return student;
        //}
    }
}
