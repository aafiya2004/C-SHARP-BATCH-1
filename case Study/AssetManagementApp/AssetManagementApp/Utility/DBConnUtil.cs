using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AssetManagementApp.Utility
{
    internal class DBConnUtil
    {
        public static SqlConnection GetConnection()
        {
            
                var config = DBPropertyUtil.LoadProperties("dbconfig.properties");

                if (!config.ContainsKey("connectionString"))
                {
                    throw new Exception("Missing 'connectionString' in dbconfig.properties");
                }

                string connectionString = config["connectionString"];

                return new SqlConnection(connectionString);      

        }
        public static void TestDatabaseConnection()
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())

                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Database connection successful!");
                    }
                    else
                    {
                        Console.WriteLine("Database connection failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while connecting to the database:");
                Console.WriteLine(ex.Message);
            }

        }
    }
}
