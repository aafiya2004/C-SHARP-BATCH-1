using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.DAO;
using PetPals.Entity;

namespace PetPals
{
    internal class PetServiceMain
    {
            static void Main(string[] args)
            {
                PetService petService = new PetService();

                try
                {
                    Console.WriteLine("Add a New Pet");
                    Console.Write("Enter pet name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter pet age: ");
                    int age = int.Parse(Console.ReadLine());

                    Console.Write("Enter pet breed: ");
                    string breed = Console.ReadLine();

                    Pet newPet = new Pet(name, age, breed);
                    petService.AddPet(newPet);

                    Console.WriteLine("\nAvailable Pets");
                    List<Pet> allPets = petService.GetAllPets();

                    foreach (Pet pet in allPets)
                    {
                        Console.WriteLine($"Name: {pet.getName()}, Age: {pet.getAge()}, Breed: {pet.getBreed()}");
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Invalid input format: " + fe.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong: " + ex.Message);
                }
            }
        }
    }

