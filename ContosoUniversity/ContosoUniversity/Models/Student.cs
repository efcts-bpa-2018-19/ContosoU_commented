using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Student
    {
//      public int ID { get; set; }
        public int StudentID { get; set; }

        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        //The Enrollments property is a navigation property. Navigation properties link to other entities that are related to this entity. 
        //In this case, the Enrollments property of a Student entity holds all of the Enrollment entities that are related to that Student. 
        //For example, if a Student row in the DB has two related Enrollment rows, the Enrollments navigation property contains those two Enrollment entities. 
        //A related Enrollment row is a row that contains that student's primary key value in the StudentID column. 
        //For example, suppose the student with ID=1 has two rows in the Enrollment table. The Enrollment table has two rows with StudentID = 1. 
        //StudentID is a foreign key in the Enrollment table that specifies the student in the Student table.
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}