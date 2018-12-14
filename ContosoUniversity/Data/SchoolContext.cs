using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Models
{
    //The main class that coordinates EF Core functionality for a given data model is the DB context class. 
    //The data context is derived from Microsoft.EntityFrameworkCore.DbContext. 
    //The data context specifies which entities are included in the data model. 
    //In this project, the class is named SchoolContext.
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Course> Course { get; set; }

        //The highlighted code creates a DbSet<TEntity> property for each entity set.
        //In EF Core terminology:

        //An entity set typically corresponds to a **DB table**.
        //An entity corresponds to a **ROW** in the table.
        //DbSet<Enrollment> and DbSet<Course> could be omitted. EF Core includes them implicitly because the Student entity references the Enrollment entity, 
        //and the Enrollment entity references the Course entity. 
        //For this tutorial, keep DbSet<Enrollment> and DbSet<Course> in the SchoolContext.
    }
}
