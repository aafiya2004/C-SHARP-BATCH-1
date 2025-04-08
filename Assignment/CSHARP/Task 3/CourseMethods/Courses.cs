using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;


namespace StudentInformationSystem
{
    internal class Courses
    {
       
            public int CourseID;
            public string CourseName;
            public string CourseCode;
            public string InstructorName;
         

        //constructor
        public Courses(int courseID, string courseName,
            string courseCode, string instructorName)
        {
            if (courseID <= 0 || string.IsNullOrWhiteSpace(courseName) || courseCode == null)
            {
                throw new InvalidCourseDataException("Course ID, name, and credits must be valid.");
            }
            this.CourseID = courseID;
            this.CourseName = courseName;
            this.CourseCode = courseCode;
            this.InstructorName = instructorName;

            //initializing collection
               Enrollments = new List<Enrollments>();
            }
      
        public List<Enrollments> Enrollments { get; set; } = new List<Enrollments>();

        private Teachers assignedTeacher;

            /*AssignTeacher(teacher: Teacher): Assigns a teacher to the course. */
            public void AssignTeacher(Teachers teacher)
            {
            if (teacher == null)
            {
                throw new TeacherNotFoundException("Teacher not found to assign to course.");
            }

            assignedTeacher = teacher;
                Console.WriteLine($"Teacher {teacher.FirstName} {teacher.LastName} assigned to course {CourseName}.");
            }

            /*UpdateCourseInfo(courseCode: string, courseName: string, instructor: string): Updates course 
            information.*/
            public void UpdateCourseInfo(string courseId, string courseName, string instructorName)
            {
                CourseCode = courseId;
                CourseName = courseName;
                InstructorName = instructorName;
                Console.WriteLine("Course information updated successfully.");

            }

            /*DisplayCourseInfo(): Displays detailed information about the course. */
            public void DisplayCourseInfo()
            {
                Console.WriteLine($"\n--- Course Information ---");
                Console.WriteLine($"Course ID: {CourseID}");
                Console.WriteLine($"Course Code: {CourseCode}");
                Console.WriteLine($"Course Name: {CourseName}");
                Console.WriteLine($"Instructor Name: {InstructorName}");

            }
        public void AddStudent(Student student, int enrollmentId)
        {
            if (student == null)
            {
                throw new StudentNotFoundException("Student not found for enrollment.");
            }

            // Check if student is already enrolled in this course
            if (Enrollments.Any(e => e.Student.StudentId == student.StudentId))
            {
                throw new DuplicateEnrollmentException("Student already enrolled in this course.");
            }

            // Create new enrollment and add to the list
            Enrollments enrollment = new Enrollments(enrollmentId, student, this, DateTime.Now);
            Enrollments.Add(enrollment);

            
            student.Enrollments.Add(enrollment);

            Console.WriteLine($"{student.FirstName} {student.LastName} enrolled successfully in {CourseName}.");
        }

        /*GetEnrollments(): Retrieves a list of student enrollments for the course.*/
        public void GetEnrollments()
            {
            if (Enrollments.Count == 0)
            {
                Console.WriteLine("No students enrolled yet.");
                return;
            }

            foreach (var enrollment in Enrollments)
            {
                Student student = enrollment.Student;
                Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Enrolled On: {enrollment.EnrollmentDate}");
            }
        }

            /*GetTeacher(): Retrieves the assigned teacher for the course.*/
            public void GetTeacher()
            {
                if (assignedTeacher != null)
                {
                    Console.WriteLine($"Teacher: {assignedTeacher.FirstName} {assignedTeacher.LastName}, Email: {assignedTeacher.Email}");
                }
                else
                {
                    Console.WriteLine("No teacher has been assigned to this course.");
                }
            }
        }


    }

