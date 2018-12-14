namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    //The Grade property is an enum. The question mark after the Grade type declaration indicates that the Grade property is nullable. A grade that's null is different from a zero grade -- null means a grade isn't known or hasn't been assigned yet.

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        //The EnrollmentID property is the primary key.
        //This entity uses the classnameID pattern instead of ID like the Student entity.
        //Typically developers choose one pattern and use it throughout the data model.
        //In a later tutorial, using ID without classname is shown to make it easier to implement inheritance in the data model.

        public int CourseID { get; set; }
        //The CourseID property is a foreign key, and the corresponding navigation property is Course.An Enrollment entity is associated with one Course entity.

        public int StudentID { get; set; }
        //The StudentID property is a foreign key, and the corresponding navigation property is Student. 
        //An Enrollment entity is associated with one Student entity, so the property contains a single Student entity. 
        //The Student entity differs from the Student.Enrollments navigation property(IN THE STUDENTS CLASS), which contains multiple Enrollment entities.

        public Grade? Grade { get; set; }

        //NAVIGATION PROPERTIES
        public Course Course { get; set; }
        public Student Student { get; set; }
    }

    /*
     * 
EF Core interprets a property as a foreign key if it's named <navigation property name><primary key property name>. 
For example,StudentID for the Student navigation property, since the Student entity's primary key is ID. 

Foreign key properties can also be named <primary key property name>. 
For example, CourseID since the Course entity's primary key is CourseID.
     * 
     */
}