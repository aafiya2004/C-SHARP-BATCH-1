using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Entity;

namespace PetPals.DAO
{
    public interface IAdoptionEventDAO
    {
        List<Entity.AdoptionEvent> GetEvents();
        void RegisterParticipant(int eventId, string participantName);
    }
}
