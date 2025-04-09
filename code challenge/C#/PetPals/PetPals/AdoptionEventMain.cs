using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.DAO;
using PetPals.Entity;

namespace PetPals
{
    internal class AdoptionEvenMain
    {
        static void Main(string[] args)
        {
            AdoptionEventService service = new AdoptionEventService();

            try
            {
                Console.WriteLine("Upcoming Adoption Events:\n");

       
                List<AdoptionEvent> events = service.GetAllEvents();

                if (events.Count == 0)
                {
                    Console.WriteLine("No upcoming events.");
                    return;
                }

                foreach (var e in events)
                {
                    Console.WriteLine($"ID: {e.EventId}, Name: {e.EventName}, Date: {e.EventDate.ToShortDateString()}, Location: {e.Location}");
                }

              
                Console.Write("\nEnter the ID of the event you want to register for: ");
                int selectedId = int.Parse(Console.ReadLine());

             
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();

                Console.Write("Enter your type (e.g., Individual, RescueOrg): ");
                string type = Console.ReadLine();

          
                Participants p = new Participants
                {
                    Name = name,
                    Type = type,
                    EventId = selectedId
                };

               
                service.RegisterParticipant(p);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid input: " + fe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }
    }
}
    