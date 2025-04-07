using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Util;
using Microsoft.Data.SqlClient;

namespace StudentInformationSystem.DAO
{
    internal class EnrollmentReport
    {
        private readonly string connectionString;
        public EnrollmentReport()
        {
            connectionString = DBConnUtil.GetConnectionString();
        }
        // Task 11: Generate Enrollment Report
        public void GenerateEnrollmentReport(string courseName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Correct column name from courses table
                string getCourseIdQuery = "SELECT CourseID FROM courses WHERE CourseName = @CourseName";
                int courseId = 0;

                using (SqlCommand cmd = new SqlCommand(getCourseIdQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        Console.WriteLine("Course not found.");
                        return;
                    }

                    courseId = Convert.ToInt32(result);
                }

                // Correct column name from enrollments table: course_id
                string reportQuery = @"
            SELECT s.student_id, s.first_name, s.last_name, e.enrollment_date
            FROM enrollments e
            INNER JOIN students s ON e.student_id = s.student_id
            WHERE e.course_id = @CourseId";

                using (SqlCommand cmd = new SqlCommand(reportQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine($"Enrollment Report for Course: {courseName}");
                        Console.WriteLine("---------------------------------------------------");

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No students enrolled.");
                            return;
                        }

                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            DateTime enrollmentDate = reader.GetDateTime(3);

                            Console.WriteLine($"Student ID: {studentId}, Name: {firstName} {lastName}, Enrolled On: {enrollmentDate.ToShortDateString()}");
                        }
                    }
                }
            }
        }
    }
}
