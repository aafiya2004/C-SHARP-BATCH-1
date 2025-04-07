using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;

namespace StudentInformationSystem
{
    internal class Teachers
    {
        
            public int TeacherID;
            public string FirstName;
            public string LastName;
            public string Email;
        

        //constructor
        public Teachers(int teacherID, string firstName,
            string lastName, string email)
            {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
              string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new InvalidTeacherDataException("Invalid Teacher details provided.");
            }

                this.TeacherID = teacherID;
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Email = email;

            //initializing collection
                AssignedCourses = new List<Courses>();

        }
      
        public List<Courses> AssignedCourses;
       

        /*UpdateTeacherInfo(name: string, email: string, expertise: string): Updates teacher information.*/
        public void UpdateTeacherInfo(string firstName, string lastName, Courses courseName, string email)
            {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Console.WriteLine("The information has been updated successfully");

        }
            /*DisplayTeacherInfo(): Displays detailed information about the teacher. */
            public void DisplayTeacherInfo()
            {
            Console.WriteLine("\n--- Teacher Information ---");
            Console.WriteLine($"ID: {TeacherID}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Email: {Email}");
        }

        public void AssignCourse(Courses course)
        {
            if (course == null)
            {
                throw new CourseNotFoundException("This course is not found");
            }
            if (!AssignedCourses.Contains(course))
            {
                AssignedCourses.Add(course);
            }
        }
        /*GetAssignedCourses() : Retrieves a list of courses assigned to the teacher.*/
        public void GetAssignedCourses()
            {
            if (AssignedCourses.Count == 0)
            {
                Console.WriteLine("No courses assigned.");
                return;
            }

            foreach (Courses course in AssignedCourses)
            {
                Console.WriteLine($"- {course.CourseName} ({course.CourseCode})");
            }

        }
        }
    }

