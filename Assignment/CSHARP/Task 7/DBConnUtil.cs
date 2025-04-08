using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace StudentInformationSystem.Util
{
    internal class DBConnUtil
    {
     
        public static string GetConnectionString()
        {
            return @"Data Source=AAFIYA\SQLEXPRESS03;Initial Catalog = SSIDB;Integrated Security=True;Encrypt=False;";
        }

       
        public static SqlConnection GetConnection(string connectionString)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to connect to database: " + ex.Message);
            }
        }
        public static void TestDatabaseConnection()
        {
            try
            {
                string connStr = GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    Console.WriteLine("Database connection successful!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Database connection failed: " + ex.Message);
            }
        }
    }
}
