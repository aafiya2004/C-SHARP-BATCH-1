using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace PetPals.Util
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
                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create connection object: " + ex.Message);
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
                Console.WriteLine("Database connection failed: " + ex.Message);
            }
        }
    }
}
