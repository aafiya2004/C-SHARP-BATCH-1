using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;

namespace StudentInformationSystem.Main
{
    internal class STUDENT_MAIN
    {
        
            static void Main(string[] args)
            {
              
                Student student = new Student(1, "Maria", "Justin", new DateTime(2000, 1, 1), "justin@example.com", "1234567890");

          
                Courses course = new Courses(101, "Physics", "PHYS101", "Priya");

          
                try
                {
                    student.EnrollInCourse(null, 1);
                }
                catch (CourseNotFoundException ex)
                {
                    Console.WriteLine($"Caught CourseNotFoundException: {ex.Message}");
                }

        
                student.EnrollInCourse(course, 2);

         
                try
                {
                    student.EnrollInCourse(course, 3);
                }
                catch (DuplicateEnrollmentException ex)
                {
                    Console.WriteLine($"Caught DuplicateEnrollmentException: {ex.Message}");
                }

        
                try
                {
                    student.MakePayment(-1000, DateTime.Now);
                }
                catch (PaymentValidationException ex)
                {
                    Console.WriteLine($"Caught PaymentValidationException (negative): {ex.Message}");
                }

       
                try
                {
                    student.MakePayment(1500, DateTime.Now.AddDays(5));
                }
                catch (PaymentValidationException ex)
                {
                    Console.WriteLine($"Caught PaymentValidationException (future date): {ex.Message}");
                }

     
                try
                {
                    student.UpdateStudentInfo("", "Kumar", DateTime.Now, "invalidemail@example.com", "0000000000");
                }
                catch (InvalidStudentDataException ex)
                {
                    Console.WriteLine($"Caught InvalidStudentDataException: {ex.Message}");
                }

         
                student.DisplayStudentInfo();

        
                student.GetEnrolledCourses();

            
                student.GetPaymentHistory();
            }
        }
    }


