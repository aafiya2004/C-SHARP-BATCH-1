using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Main
{
    internal class ENOLLMENTS_MAIN
    {
        static void Main(string[] args)
        {
            try
            {
                Enrollments enrollment1 = new Enrollments(1, null ,null  , DateTime.Now);
            }
            catch (Exception ex) { 
                Console.WriteLine("Invalid Student and course data exception caught: " +ex.Message);
            }
        }
    }
}
