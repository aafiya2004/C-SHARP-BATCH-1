using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Entity;

namespace PetPals.DAO
{
    public interface IPet
    {
        List<Pet> GetAllPets();
    }
}
