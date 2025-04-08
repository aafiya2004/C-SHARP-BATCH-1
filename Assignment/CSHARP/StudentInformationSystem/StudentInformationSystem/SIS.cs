using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;


namespace StudentInformationSystem
{
    internal class SIS
    {
        /*AddEnrollment(student, course, enrollmentDate): In the SIS class, create a method that adds an 
            enrollment to both the Student's and Course's enrollment lists. Ensure the Enrollment object 
            references the correct Student and Course. */
        public void AddEnrollment(Student student, Courses course, int enrollmentId, DateTime enrollmentDate)
        {
            if (student == null)
                throw new StudentNotFoundException("Student not found.");

            if (course == null)
                throw new CourseNotFoundException("Course not found.");

            if (student.Enrollments.Any(e => e.course.CourseID == course.CourseID))
                throw new DuplicateEnrollmentException("Student already enrolled in this course.");

            Enrollments enrollment = new Enrollments(enrollmentId, student, course, enrollmentDate);

            student.Enrollments.Add(enrollment);
            course.Enrollments.Add(enrollment);

            Console.WriteLine($"Enrollment added successfully for {student.FirstName} {student.LastName} in course {course.CourseName}.");
        }

        /*AssignCourseToTeacher(course, teacher): In the SIS class, create a method to assign a course to 
           a teacher. Add the course to the teacher's AssignedCourses list.*/
        public void AssignCourseToTeacher(Courses course, Teachers teacher)
        {
            if (teacher == null)
                throw new Exception("Teacher not found.");

            if (course == null)
                throw new CourseNotFoundException("Course not found.");

            if (teacher.AssignedCourses.Contains(course))
                throw new Exception("Course already assigned to the teacher.");

            teacher.AssignedCourses.Add(course);

            Console.WriteLine($"Course {course.CourseName} assigned to teacher {teacher.FirstName} {teacher.LastName}.");
        }

        /* AddPayment(student, amount, paymentDate): In the SIS class, create a method that adds a 
           payment to the Student's payment history. Ensure the Payment object references the correct 
           Student. */
        public void AddPayment(Student student, double amount, DateTime paymentDate)
        {
            if (student == null)
                throw new StudentNotFoundException("Student not found.");

            if (amount <= 0)
                throw new PaymentValidationException("Invalid amount.");

            if (paymentDate > DateTime.Now)
                throw new PaymentValidationException("Invalid date.");

            int paymentID = Student.PaymentCounter++; 

            Payments payment = new Payments(student, amount, paymentDate);
            student.GetPaymentList().Add(payment); 

            Console.WriteLine($"Payment of {amount} added successfully for {student.FirstName}.");
        }

        /*GetEnrollmentsForStudent(student): In the SIS class, create a method to retrieve all enrollments 
           for a specific student. */
        public void GetEnrollmentsForStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"\n--- Enrollments for {student.FirstName} {student.LastName} ---");

            if (student.Enrollments.Count == 0)
            {
                Console.WriteLine("No enrollments found.");
            }
            else
            {
                foreach (var enrollment in student.Enrollments)
                {
                    Console.WriteLine($"Course: {enrollment.course.CourseName}, Enrolled On: {enrollment.EnrollmentDate.ToShortDateString()}");
                }
            }
        }

        /*GetCoursesForTeacher(teacher) : In the SIS class, create a method to retrieve all courses
           assigned to a specific teacher.*/
        public void GetCoursesForTeacher(Teachers teacher)
        {
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }

            Console.WriteLine($"\n--- Courses for {teacher.FirstName} {teacher.LastName} ---");

            if (teacher.AssignedCourses.Count == 0)
            {
                Console.WriteLine("No courses assigned.");
            }
            else
            {
                foreach (Courses course in teacher.AssignedCourses)
                {
                    Console.WriteLine($"Course ID: {course.CourseID}, Course Name: {course.CourseName}");
                }
            }
        }

    }
}
