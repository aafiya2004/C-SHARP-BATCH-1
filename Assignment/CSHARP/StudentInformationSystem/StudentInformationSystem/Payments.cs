using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;


namespace StudentInformationSystem
{
    internal class Payments
    {
      
        public Student Student;
        public double Amount;
        public DateTime PaymentDate;
       


//Constructor
public Payments(Student student, 
    double amount, DateTime paymentDate)
        {
            if (amount <= 0)
            {
                throw new PaymentValidationException("Invalid amount");
            }

                if (paymentDate > DateTime.Now)
                {
                    throw new PaymentValidationException("Date cannot be in the future");
                }


        
            this.Student = student;
            this.Amount = amount;
            this.PaymentDate = paymentDate;
        }

        /*GetStudent() : Retrieves the student associated with the payment.*/
        public Student GetStudent()
        {
            return Student;
        }

        /*GetPaymentAmount() : Retrieves the payment amount.*/
        public double GetPaymentAmount()
        {
            return Amount;
        }

        /*GetPaymentDate(): Retrieves the payment date.*/
        public DateTime GetPaymentDate()
        {
            return PaymentDate;
        }
    }



}

