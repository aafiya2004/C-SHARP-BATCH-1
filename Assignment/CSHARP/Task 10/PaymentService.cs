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
    internal class PaymentService : IPaymentService
    {
        private readonly string connectionString;

        public PaymentService()
        {
            connectionString = DBConnUtil.GetConnectionString();
        }

        public void RecordPayment(int studentId, decimal amount, DateTime paymentDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkStudentQuery = "SELECT COUNT(*) FROM students WHERE student_id = @StudentId";
                using (SqlCommand checkCmd = new SqlCommand(checkStudentQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@StudentId", studentId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        Console.WriteLine("Student not found.");
                        return;
                    }
                }
                string insertPaymentQuery = @"
                    INSERT INTO payments (student_id, amount, payment_date)
                    VALUES (@StudentId, @Amount, @PaymentDate)";

                using (SqlCommand insertCmd = new SqlCommand(insertPaymentQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@StudentId", studentId);
                    insertCmd.Parameters.AddWithValue("@Amount", amount);
                    insertCmd.Parameters.AddWithValue("@PaymentDate", paymentDate);

                    int rows = insertCmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        Console.WriteLine("Payment recorded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to record payment.");
                    }
                }
            }
        }
    }
}


