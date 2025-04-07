using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.DAO
{
    internal interface IPaymentService
    {
        void RecordPayment(int studentId, decimal amount, DateTime paymentDate);
    }
}
