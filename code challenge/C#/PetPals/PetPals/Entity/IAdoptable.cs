using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Entity
{
    public interface IAdoptable
    {
        void Adopt();
    }

    public class AdoptablePet : Pet, IAdoptable
    {
        public AdoptablePet(string name, int age, string breed)
            : base(name, age, breed)
        {
        }

        public void Adopt()
        {
            Console.WriteLine($"{getName()} the {getBreed()} has been adopted!");
        }
    }
}

   