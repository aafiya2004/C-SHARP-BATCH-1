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
     

                try
                {
                 
                    string insertStudent = "INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email, phone_no) " +
                                           "VALUES (@StudentId, @FirstName, @LastName, @DOB, @Email, @Phone)";
                    SqlCommand cmd = new SqlCommand(insertStudent, conn);
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
                        SqlCommand checkCmd = new SqlCommand(checkCourse, conn);
                        checkCmd.Parameters.AddWithValue("@CourseId", courseId);
                        int courseExists = (int)checkCmd.ExecuteScalar();

                        if (courseExists == 0)
                        {
                            Console.WriteLine($"Course with ID {courseId} does not exist");
                            continue;
                        }

                
                        string enroll = "INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) " +
                                        "VALUES (@EnrollmentID, @StudentId, @CourseId, @EnrollmentDate)";
                        SqlCommand enrolCmd = new SqlCommand(enroll, conn);
                        enrolCmd.Parameters.AddWithValue("@EnrollmentID", enrollmentCounter++);
                        enrolCmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                        enrolCmd.Parameters.AddWithValue("@CourseId", courseId);
                        enrolCmd.Parameters.AddWithValue("@EnrollmentDate", enrollmentDate);

                        enrolCmd.ExecuteNonQuery();
                    }

                    string selectstud = "SELECT * FROM Students";
                    SqlCommand studCmd = new SqlCommand(selectstud, conn);
                    using(SqlDataReader reader = studCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            DateTime dob = reader.GetDateTime(3);
                            string email = reader.GetString(4);
                            string phoneNo = reader.GetString(5);
                            Console.WriteLine($"StudentID: {studentId}, Name: {firstName} {lastName}, DOB: {dob.ToShortDateString()}, Email: {email}, Phone: {phoneNo}");
                        }
                    }




                    string selectenroll = "SELECT * FROM Enrollments";
                    SqlCommand enrollCmd = new SqlCommand(selectenroll, conn);

                    using (SqlDataReader reader = enrollCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int enrollmentId = reader.GetInt32(0);
                            int studentId = reader.GetInt32(1);
                            int courseId = reader.GetInt32(2);
                            DateTime date = reader.GetDateTime(3);

                            Console.WriteLine($"EnrollmentID: {enrollmentId}, StudentID: {studentId}, CourseID: {courseId}, Date: {date.ToShortDateString()}");
                        }
                    }
                
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine("Enrollment failed: " + ex.Message);
                }
            }
        }
    }
}