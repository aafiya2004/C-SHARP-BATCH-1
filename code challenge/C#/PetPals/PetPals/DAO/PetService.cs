using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Entity;
using PetPals.DAO;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Reflection.PortableExecutable;
using Microsoft.Data.SqlClient;
using PetPals.Util;


namespace PetPals.DAO
{
    public class PetService : IPet
    {
        private string connectionString = @"Data Source=AAFIYA\SQLEXPRESS03;Initial Catalog = petpals;Integrated Security=True;Encrypt=False;";

        public List<Pet> GetAllPets()
        {
            List<Pet> pets = new List<Pet>();

            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT name, age, breed FROM pets";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int age = reader.GetInt32(1);
                            string breed = reader.GetString(2);

                            Pet pet = new Pet(name, age, breed);
                            pets.Add(pet);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error fetching pets: " + ex.Message);
            }

            return pets;
        }

        public void AddPet(Pet pet)
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO pets (name, age, breed) VALUES (@name, @age, @breed)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", pet.getName());
                        cmd.Parameters.AddWithValue("@age", pet.getAge());
                        cmd.Parameters.AddWithValue("@breed", pet.getBreed());

                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Pet added successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error adding pet: " + ex.Message);
            }
        }
    }
}