using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Entity
{
    public class AdoptionEvent
    {
            public int EventId { get; set; }
            public string EventName { get; set; }
            public DateTime EventDate { get; set; }
            public string Location { get; set; }
        
    

    private List<IAdoptable> Participants = new List<IAdoptable>();

     
        public void RegisterParticipant(IAdoptable participant)
        {
            Participants.Add(participant);
            Console.WriteLine("Participant registered successfully.");
        }

     
        public void HostEvent()
        {
            Console.WriteLine("\nAdoption Event: ");

            if (Participants.Count == 0)
            {
                Console.WriteLine("No participants for this event.");
                return;
            }

            foreach (var participant in Participants)
            {
                participant.Adopt(); 
            }

        }
    }
}
