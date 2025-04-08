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
   
            sis.AddEnrollment(student, course1, 1, new DateTime(2023, 3, 15));
            sis.AssignCourseToTeacher(course1, teacher);
            sis.AssignCourseToTeacher(course2, teacher);
            sis.AddPayment(student, 1000, new DateTime(2023, 4, 10)); 
            sis.GetEnrollmentsForStudent(student);
            sis.GetCoursesForTeacher(teacher);

        }
    }
}
