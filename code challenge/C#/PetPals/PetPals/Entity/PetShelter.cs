using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Entity
{
    internal class PetShelter
    {
        private List<Pet> availablePets = new List<Pet>();

        public void addPet(Pet pet)
        {
            availablePets.Add(pet);
            Console.WriteLine($"{pet.getName()} has been added to the shelter.");
        }
        public void removePet(Pet pet)
        {
            if (availablePets.Remove(pet)){

                Console.WriteLine($"{pet.getName()} has been adopted.");
            }
            else
            {
                Console.WriteLine($"{pet.getName()} is not available for adoption.");
            }
        }
        public List<Pet> getAvailablePets()
        {
            return availablePets;
        }

    }
}
