using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.CustomExceptions
{
    
        public class DuplicateEnrollmentException : Exception 
    { 
        public DuplicateEnrollmentException(string msg) : base(msg) { } 
    }
        public class CourseNotFoundException : Exception 
    { 
        public CourseNotFoundException(string msg) : base(msg) { } 
    }
        public class StudentNotFoundException : Exception 
    { 
        public StudentNotFoundException(string msg) : base(msg) { } 
    }
        public class TeacherNotFoundException : Exception 
    { 
        public TeacherNotFoundException(string msg) : base(msg) { } 
    }
        public class PaymentValidationException : Exception 
    { 
        public PaymentValidationException(string msg) : base(msg) { }
    }
        public class InvalidStudentDataException : Exception 
    { 
        public InvalidStudentDataException(string msg) : base(msg) { } 
    }
        public class InvalidCourseDataException : Exception 
    { 
        public InvalidCourseDataException(string msg) : base(msg) { } 
    }
        public class InvalidEnrollmentDataException : Exception 
    { 
        public InvalidEnrollmentDataException(string msg) : base(msg) { } 
    }
        public class InvalidTeacherDataException : Exception 
    { 
        public InvalidTeacherDataException(string msg) : base(msg) { } 
    }
        /*public class InsufficientFundsException : Exception 
    { 
        public InsufficientFundsException(string msg) : base(msg) { } 
    }*/


    
}
