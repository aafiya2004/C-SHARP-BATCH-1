using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.CustomExceptions;

namespace StudentInformationSystem.Main
{
    internal class TEACHER_MAIN
    {
        static void Main(string[] args)
        {
        
            Teachers teacher = new Teachers(501, "Marie", "Curie", "curie@example.com");
            try
            {
                teacher.AssignCourse(null);
            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine($"Caught CourseNotFoundException: {ex.Message}");
            }
            Courses physicsCourse = new Courses(201,"Physics","PHY101","Dr. Curie");
            teacher.AssignCourse(physicsCourse);
            Console.WriteLine("Successfully assigned Physics course");

            teacher.AssignCourse(physicsCourse);
            Console.WriteLine("Duplicate course assignment handled");
            teacher.DisplayTeacherInfo();
            teacher.GetAssignedCourses();
            teacher.UpdateTeacherInfo("Marie", "Curie", physicsCourse, "marie.curie@univ.edu");
        }
    }
}
    

