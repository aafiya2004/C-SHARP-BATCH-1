using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Main
{
    internal class PAYMENT_OUTPUT

    {
        static void Main(string[] args)
        {

            try
            {
                Student student1 = new Student(1, "Aafiya", "Farheen", new DateTime(2004, 04, 24), "aafiya123@gmail.com", "1234567778");
                Payments payment1 = new Payments(1, student1, 0, DateTime.Now);

            }
            catch (Exception ex) { 
                Console.WriteLine("PaymentValidation Exception caught: " +ex.Message);
            }
        }
    }
}