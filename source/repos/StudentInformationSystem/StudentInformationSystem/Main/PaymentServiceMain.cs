using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Util;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.DAO;
using StudentInformationSystem.CustomExceptions;

namespace StudentInformationSystem.Main
{
    internal class PaymentServiceMain
    {
        static void Main(String[] args)
        {
            PaymentService service2 = new PaymentService();
            service2.RecordPayment(1, 500, DateTime.Now);
        }
    }
}
