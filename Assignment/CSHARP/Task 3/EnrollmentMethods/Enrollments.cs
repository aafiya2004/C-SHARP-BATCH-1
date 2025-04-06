using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;


namespace StudentInformationSystem
{
    internal class Enrollments
    {
      
           public int EnrollmentID;
           public Student Student;
           public Courses Course;
           public DateTime EnrollmentDate;


            //constructor
            public Enrollments(int enrollmentID, Student student, 
                Courses course, DateTime enrollmentDate)
            {
            if (student == null || course == null)
            {
                throw new InvalidEnrollmentDataException("Invalid Teacher details provided.");
            }
            this.EnrollmentID = enrollmentID;
                this.Student = student;
                this.Course = course;
                this.EnrollmentDate = enrollmentDate;
            }




            /*GetStudent(): Retrieves the student associated with the enrollment.*/
            public Student GetStudent()
            {
              return Student;
            }

            /*GetCourse(): Retrieves the course associated with the enrollment.*/
            public Courses GetCourse()
            {
             return Course;
            }

        }

    }

