using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Util;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.CustomExceptions;

namespace StudentInformationSystem.DAO
{
    internal class TeacherService : ITeacherService
    {
        private readonly string connectionString;

        public object teacherID { get; private set; }

        public TeacherService()
        {
            connectionString = DBConnUtil.GetConnectionString();
        }
        //Task 9: Teacher Assignment

        //It checks if a teacher exists in the table. If not, it adds the teacher's record
        public int GetOrAddTeacher(int teacherID, string firstName, string lastName, string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();


                string checkQuery = "SELECT teacher_id FROM teacher WHERE first_name = @FirstName AND last_name = @LastName AND email = @Email";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@TeacherID", teacherID);
                    checkCmd.Parameters.AddWithValue("@FirstName", firstName);
                    checkCmd.Parameters.AddWithValue("@LastName", lastName);
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    object result = checkCmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                string insertQuery = "INSERT INTO teacher (teacher_id, first_name, last_name, email) OUTPUT INSERTED.teacher_id VALUES (@TeacherID,@FirstName, @LastName, @Email)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {

                    insertCmd.Parameters.AddWithValue("@TeacherID", teacherID);
                    insertCmd.Parameters.AddWithValue("@FirstName", firstName);
                    insertCmd.Parameters.AddWithValue("@LastName", lastName);
                    insertCmd.Parameters.AddWithValue("@Email", email);

                    int newTeacherId = (int)insertCmd.ExecuteScalar();
                    return newTeacherId;
                }
            }
        }

        //It assigns the teacher to the course
        public void AssignTeacherToCourse(string courseCode, string instructorName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectCourseQuery = "SELECT CourseID, CourseName FROM courses WHERE CourseCode = @CourseCode";
                int courseId = 0;
                string courseName = "";

                using (SqlCommand cmd = new SqlCommand(selectCourseQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseCode", courseCode);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            courseId = Convert.ToInt32(reader["CourseID"]);
                            courseName = reader["CourseName"].ToString();
                        }
                        else
                        {
                            Console.WriteLine("Course not found.");
                            return;
                        }
                    }
                }

                string updateQuery = "UPDATE courses SET InstructorName = @InstructorName WHERE CourseID = @CourseID";
                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@InstructorName", instructorName);
                    updateCmd.Parameters.AddWithValue("@CourseID", courseId);

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Instructor assigned to course '{courseName}' successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to assign instructor.");
                    }
                }
            }
        }

    }
}