using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.CustomExceptions;
using StudentInformationSystem.Util;



namespace StudentInformationSystem.DAO
{
    internal class StudentService : IStudentService
    {
        private readonly string connectionString;

        public StudentService()
        {
            connectionString = DBConnUtil.GetConnectionString();
        }

        public object enrollmentID { get; private set; }

        //Task 8: Student Enrollment 
        public void EnrollStudentWithCourses(Student student, List<int> courseIds, DateTime enrollmentDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                 
                    string insertStudent = "INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email, phone_no) " +
                                           "VALUES (@StudentId, @FirstName, @LastName, @DOB, @Email, @Phone)";
                    SqlCommand cmd = new SqlCommand(insertStudent, conn, transaction);
                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@DOB", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Phone", student.PhoneNo);

                    cmd.ExecuteNonQuery();

                    int enrollmentCounter = 1; 

                    foreach (int courseId in courseIds)
                    {
          
                        string checkCourse = "SELECT COUNT(*) FROM Courses WHERE CourseID = @CourseId";
                        SqlCommand checkCmd = new SqlCommand(checkCourse, conn, transaction);
                        checkCmd.Parameters.AddWithValue("@CourseId", courseId);
                        int courseExists = (int)checkCmd.ExecuteScalar();

                        if (courseExists == 0)
                        {
                            Console.WriteLine($"Course with ID {courseId} does not exist. Skipping enrollment.");
                            continue;
                        }

                
                        string enroll = "INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) " +
                                        "VALUES (@EnrollmentID, @StudentId, @CourseId, @EnrollmentDate)";
                        SqlCommand enrollCmd = new SqlCommand(enroll, conn, transaction);
                        enrollCmd.Parameters.AddWithValue("@EnrollmentID", enrollmentCounter++);
                        enrollCmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                        enrollCmd.Parameters.AddWithValue("@CourseId", courseId);
                        enrollCmd.Parameters.AddWithValue("@EnrollmentDate", enrollmentDate);

                        enrollCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    Console.WriteLine("Student enrolled and courses registered successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Enrollment failed: " + ex.Message);
                }
            }
        }
    }
}