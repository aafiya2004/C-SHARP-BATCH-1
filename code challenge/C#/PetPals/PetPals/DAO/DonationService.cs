using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PetPals.Util;

namespace PetPals.DAO
{
    public class DonationService
    {
        private string connectionString = @"Data Source=AAFIYA\SQLEXPRESS03;Initial Catalog = petpals;Integrated Security=True;Encrypt=False;";

        public void AddDonation(string donorName, decimal amount)
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO donations (donorname, donationamount) VALUES (@donorName, @amount)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@donorName", donorName);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Donation recorded successfully!");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error while recording donation: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
        public void GetAllDonations()
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM donations";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\n--- Donation Records ---");
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            decimal amount = reader.GetDecimal(1);
                            Console.WriteLine($"Donor: {name}, Amount: {amount}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error while fetching donations: " + ex.Message);
            }
        }
    }
}

