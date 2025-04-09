using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PetPals.Entity;
using PetPals.Util;

namespace PetPals.DAO
{
    public class AdoptionEventService
    {
        private string connectionString = @"Data Source=AAFIYA\SQLEXPRESS03;Initial Catalog=petpals;Integrated Security=True;Encrypt=False;";

        public void RegisterParticipant(Participants participant)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO participants (participantname, participanttype, eventid) VALUES (@name, @type, @eventid)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", participant.Name);
                        cmd.Parameters.AddWithValue("@type", participant.Type);
                        cmd.Parameters.AddWithValue("@eventid", participant.EventId);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Participant registered successfully.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error registering participant: " + ex.Message);
            }
        }
        public List<AdoptionEvent> GetAllEvents()
        {
            List<AdoptionEvent> events = new List<AdoptionEvent>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM adoptionevents";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AdoptionEvent evt = new AdoptionEvent
                                {
                                    EventId = Convert.ToInt32(reader["eventid"]),
                                    EventName = reader["eventname"].ToString(),
                                    EventDate = Convert.ToDateTime(reader["eventdate"]),
                                    Location = reader["location"].ToString()
                                };
                                events.Add(evt);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retrieving events: " + ex.Message);
            }

            return events;
        }
        public List<Participants> GetAllParticipants()
        {
            List<Participants> participants = new List<Participants>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM participants";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Participants p = new Participants
                                {
                                    ParticipantId = Convert.ToInt32(reader["participantid"]),
                                    Name = reader["participantname"].ToString(),
                                    Type = reader["participanttype"].ToString(),
                                    EventId = Convert.ToInt32(reader["eventid"])
                                };
                                participants.Add(p);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error retrieving participants: " + ex.Message);
            }

            return participants;
        }
    }
}

   