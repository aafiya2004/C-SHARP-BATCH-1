using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;
using StudentInformationSystem;
namespace StudentInformationSystem.Main
{
    internal class SIS_MAIN
    {
        static void Main(string[] args)
        {

            SIS sis = new SIS();

           
            Student student = new Student(101, "Jane", "Johnson", new DateTime(2002, 5, 10), "jane.johnson@email.com", "9998887770");
            Teachers teacher = new Teachers(201, "Alice", "Smith", "alice.smith@email.com");
            Courses course1 = new Courses(301, "English Literature", "ENG101", "Dr. Brown");
            Courses course2 = new Courses(302, "Computer Science 101", "CS101", "Dr. Allen");
            Courses course3 = new Courses(303, "Mathematics", "MATH101", "Prof. Baker");
            // Enroll null student
try
{
    sis.AddEnrollment(null, course1, 1, new DateTime(2023, 3, 15));
}
catch (Exception ex)
{
    Console.WriteLine("Exception: " + ex.Message);
}

//  Assign same course twice to same teacher
try
{
    sis.AssignCourseToTeacher(course1, teacher);
    sis.AssignCourseToTeacher(course2, teacher);
    sis.AssignCourseToTeacher(course1, teacher);
}
catch (Exception ex)
{
    Console.WriteLine("Exception: " + ex.Message);
}

//  Add invalid payment
try
{
    sis.AddPayment(student, 0, new DateTime(2023, 4, 10)); 
}
catch (Exception ex)
{
    Console.WriteLine("Exception: " + ex.Message);
}

// Duplicate enrollment
try
{
    Student student1 = new Student(1, "Aarav", "Sharma", new DateTime(2000, 1, 15), "aarav@example.com", "9998887770");
    Courses math = new Courses(101, "Mathematics", "Basic Algebra", "Dr. Nair");

    student1.EnrollInCourse(math, 5001);
    student1.EnrollInCourse(math, 5002); 
}
catch (DuplicateEnrollmentException ex)
{
    Console.WriteLine("DuplicateEnrollmentException caught: " + ex.Message);
}

//  Null course enrollment
try
{
    student.EnrollInCourse(null, 5003);
}
catch (CourseNotFoundException ex)
{
    Console.WriteLine("CourseNotFoundException caught: " + ex.Message);
}

// Invalid payment amount
try
{
    student.MakePayment(-1000, DateTime.Now);
}
catch (PaymentValidationException ex)
{
    Console.WriteLine("PaymentValidationException caught (amount): " + ex.Message);
}

//  Future payment date
try
{
    student.MakePayment(2000, DateTime.Now.AddDays(3));
}
catch (PaymentValidationException ex)
{
    Console.WriteLine("PaymentValidationException caught (future date): " + ex.Message);
}

//  Invalid student update
try
{
    student.UpdateStudentInfo("", "Sharma", DateTime.Now, "", "9999999999");
}
catch (InvalidStudentDataException ex)
{
    Console.WriteLine("InvalidStudentDataException caught: " + ex.Message);
}


student.DisplayStudentInfo();
student.GetEnrolledCourses();
student.GetPaymentHistory();
        }
    }
}
