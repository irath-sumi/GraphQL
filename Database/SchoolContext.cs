using GraphQLBasic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions;
using System.Data;


namespace GraphQLBasic.Database
{
    public class SchoolContext : DbContext
    {
        //private readonly IConfiguration Configuration;
       
        public SchoolContext(DbContextOptions options) : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    IConfigurationRoot configuration = new ConfigurationBuilder()

        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        //}

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

   

    }
}
