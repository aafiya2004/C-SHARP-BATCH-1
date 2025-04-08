using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Util;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.DAO;
using StudentInformationSystem.CustomExceptions;

namespace StudentInformationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student stud1 = new Student(1,"John", "Doe", new DateTime(1995, 08, 15), 
                "john.doe@example.com", "1234567890");
            Enrollments enrollment = new Enrollments(
                  enrollmentID: 2, 
                  student: stud1,
                  course: null,
                  enrollmentDate: DateTime.Now
              );
            List<int> courseIds = new List<int> { 1, 2 };
            StudentService studentService = new StudentService();
            DateTime enrollmentDate = DateTime.Now;
            studentService.EnrollStudentWithCourses(stud1,courseIds, enrollmentDate);

          
            TeacherService service1 = new TeacherService();
            service1.GetOrAddTeacher(1, "Sarah", "Smith", "sarah.smith@example.com");

            service1.AssignTeacherToCourse("CS101","Sarah Smith");



            PaymentService service2 = new PaymentService();
            service2.RecordPayment(1, 450, DateTime.Now);



            EnrollmentReport enrollmentReport = new EnrollmentReport();
            enrollmentReport.GenerateEnrollmentReport("Introduction to Programming");
            enrollmentReport.GenerateEnrollmentReport("Mathematics 101");








        }
    }
}

    

    

