using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;

namespace StudentInformationSystem.Main
{
    internal class COURSE_MAIN
    {
        static void Main(string[] args)
        {
          
            Courses course = new Courses(101, "Math101", "MATH101", "Khan");

         
            Student student = new Student(1, "Alice", "Walker", new DateTime(2002, 5, 15), "alice@example.com", "1234567890");

          
            Teachers teacher = new Teachers(10, "Sarah", "Rozario", "sarah@example.com");

          
            try
            {
                course.AssignTeacher(null);
            }
            catch (TeacherNotFoundException ex)
            {
                Console.WriteLine($"Caught TeacherNotFoundException: {ex.Message}");
            }

         
            course.AssignTeacher(teacher);

        
            try
            {
                course.AddStudent(null, 2001);
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Caught StudentNotFoundException: {ex.Message}");
            }

          
            course.AddStudent(student, 2002);

         
            try
            {
                course.AddStudent(student, 2003);
            }
            catch (DuplicateEnrollmentException ex)
            {
                Console.WriteLine($"Caught DuplicateEnrollmentException: {ex.Message}");
            }

         
            course.DisplayCourseInfo();

         
            course.GetEnrollments();

           
            course.GetTeacher();
        }
    }
}
    

