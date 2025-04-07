using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;


namespace StudentInformationSystem
{
    internal class Student
    {
            public int StudentId;
            public string FirstName;
            public string LastName;
            public DateTime DateOfBirth;
            public string Email;
            public string PhoneNo;
         

        //constructor
        public Student(int studentId, string FirstName, string LastName,
            DateTime dob, string email, string phoneNumber)
            {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) ||
               string.IsNullOrWhiteSpace(email) || !email.Contains("@") || string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new InvalidStudentDataException("Invalid student details provided.");
            }

            this.StudentId = studentId;
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.DateOfBirth = dob;
                this.Email = email;
                this.PhoneNo = phoneNumber;
               //initializing collection
            Enrollments = new List<Enrollments>();
            paymentHistory= new List<Payments>();

        }
        public List<Enrollments> Enrollments { get; set; } = new List<Enrollments>();
        private List<Payments> paymentHistory { get; set; } = new List<Payments>();



        /*EnrollInCourse(course: Course): Enrolls the student in a course. */
        public void EnrollInCourse(Courses course, int enrollmentId)
        {
            if (course == null)
            {
                throw new CourseNotFoundException("This course is not found.");
            }

       
     

    
            Enrollments enrollment = new Enrollments(enrollmentId, this, course, DateTime.Now);

          
            Enrollments.Add(enrollment);

           
            course.Enrollments.Add(enrollment);

            Console.WriteLine($"{FirstName} {LastName} has been enrolled in course: {course.CourseName}");
        }


        public static int PaymentCounter = 1;

        private List<Payments> paymentsList = new List<Payments>(); 

        /*MakePayment(amount: decimal, paymentDate: DateTime): Records a payment made by the student.*/
        public void MakePayment(double amount, DateTime paymentDate)
            {
            if (amount <= 0)
            {
                throw new PaymentValidationException("Payment amount must be greater than zero.");
            }

            if (paymentDate > DateTime.Now)
            {
                throw new PaymentValidationException("Payment date cannot be in the future.");
            }

            int paymentID = PaymentCounter++;
                Payments payment = new Payments(this, amount, paymentDate);
                paymentHistory.Add(payment);
                Console.WriteLine($"Payment of Rs. {amount} made on {paymentDate.ToShortDateString()}");
            }

            /*UpdateStudentInfo(firstName: string, lastName: string, dateOfBirth: DateTime,
             email: string, phoneNumber: string): Updates the student's information.*/
            public void UpdateStudentInfo(string firstName, string lastName, DateTime dob, string email, string phoneNumber)
            {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || dob == default || string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidStudentDataException("Updated student data is invalid.");
            }
                FirstName = firstName;
                LastName = lastName;
                DateOfBirth = dob;
                Email = email;
                PhoneNo = phoneNumber;
            Console.WriteLine("The details have been updated");

            }

            /*DisplayStudentInfo(): Displays detailed information about the student. */
            public void DisplayStudentInfo()
            {

                Console.WriteLine("\n--- Student Information ---");
                Console.WriteLine($"First Name: {FirstName}");
                Console.WriteLine($"Last Name: {LastName}");
                Console.WriteLine($"Student ID: {StudentId}");
                Console.WriteLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
                Console.WriteLine($"Email: {Email}");
                Console.WriteLine($"Phone Number: {PhoneNo}");

            }

        /*GetEnrolledCourses(): Retrieves a list of courses in which the student is enrolled. */
        public void GetEnrolledCourses()
        {
            if (Enrollments.Count == 0)
            {
                Console.WriteLine("No courses enrolled yet.");
                return;
            }

            foreach (Enrollments enrollment in Enrollments)
            {
                Courses course = enrollment.course;
                Console.WriteLine($"Course ID: {course.CourseID}, " +
                                  $"Name: {course.CourseName}, " +
                                  $"Instructor: {course.InstructorName}");
            }
        }


        /*GetPaymentHistory(): Retrieves a list of payment records for the student.*/
        public void GetPaymentHistory()
            {
                Console.WriteLine("\n--- Payment History ---");
                if (paymentHistory.Count == 0)
                {
                    Console.WriteLine("No payments made.");
                }
                else
                {
                    foreach (Payments payment in paymentHistory)
                    {
                        Console.WriteLine($"Amount: {payment.Amount}, " +
                            $"Date: {payment.PaymentDate.ToShortDateString()}");
                    }
                }
            }
        public List<Payments> GetPaymentList()
        {
            return paymentHistory;
        }

    }


}

