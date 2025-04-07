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
           public Courses course;
           public DateTime EnrollmentDate;


            //constructor
            public Enrollments(int enrollmentID, Student student, 
                Courses course, DateTime enrollmentDate)
            {
            if (student == null )
            {
                throw new InvalidEnrollmentDataException("Invalid details provided.");
            }
                this.EnrollmentID = enrollmentID;
                this.Student = student;
                this.course = course;
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
             return course;
            }

        }

    }

