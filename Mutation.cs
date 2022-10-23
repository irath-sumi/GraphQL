using GraphQLBasic.Database;
using GraphQLBasic.Models;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLBasic
{
    public class Mutation
    {
        [UseDbContext(typeof(SchoolContext))]
        public async Task<AddStudent> AddStudentAsync(
            AddStudentInput input,
            [ScopedService]SchoolContext context,
            [Service]ITopicEventSender eventSender,//calls the subscription event/method
            CancellationToken cancellationToken)// cancel async method calls if they are hanging or something like that
        {
            var student = new Student
            {
                Name = input.name,
                Grade = input.grade,
                Roll = input.roll,

            };
            context.Students.Add(student);
            await context.SaveChangesAsync();
            // notify anybody listening on the other end

            //await eventSender.SendAsync(nameof(Subscription.OnStudentAdded), student, cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.OnStudentAdded), student);

            return new AddStudent(student);
        }

        [UseDbContext(typeof(SchoolContext))]
        public async  Task<string> DeleteStudentAsync(DeleteStudentInput input, [ScopedService]SchoolContext context)
        {
            var student = new Student
            {
                StudentId = input.studentID                                                                                                               

            };
            if (context.Students.Contains(student))
            {
                context.Students.Remove(student);

                await context.SaveChangesAsync();
            }
            else
            {
                return "Student not present";
            }

            return "Student Removed from db";
           
        }
    }
}
