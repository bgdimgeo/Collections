using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SoftUniParking
{
    class SoftUniStudents
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseInfo = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "end") 
            {
                string[] courseArgs = command.Split(" : ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string courseName = courseArgs[0];
                string studentName = courseArgs[1];
                if (!courseInfo.ContainsKey(courseName)) 
                {
                    courseInfo[courseName] = new List<string>();
                }
                courseInfo[courseName].Add(studentName);
            }
            PrintCoursesInfo(courseInfo);
        }
        static void PrintCoursesInfo(Dictionary<string, List<string>> courseInfo) 
        {
            foreach (var KeyValuePair in courseInfo) 
            {
                string courseName = KeyValuePair.Key;
                List<string> students = KeyValuePair.Value;
                Console.WriteLine($"{courseName}: {students.Count}");
                foreach (var studentName in students) 
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}