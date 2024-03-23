using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> courses = new Dictionary<string, string>();
            
            List<Student> students = new List<Student>();
            string command = Console.ReadLine();
            while (command != "end of contests")
            {
                string[] input = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string course = input[0];
                string password = input[1];
                courses.Add(course, password);
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "end of submissions") 
            {
                string[] input = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string course = input[0];
                string password = input[1];
                string studentName = input[2];
                int result = int.Parse(input[3]);
                if (!courses.ContainsKey(course) || courses[course] != password) 
                {
                    command = Console.ReadLine();
                    continue;
                }
                if (!students.Any(x => x.Name == studentName))
                {
                    Student currStudent = new Student(studentName);
                    currStudent.ScorePerCourse.Add(course, result);
                    students.Add(currStudent);
                }
                else if (students.Any(x => x.Name == studentName)) 
                {
                    Student findStudent = students.First(x => x.Name == studentName);
                    if (!findStudent.ScorePerCourse.Any(x => x.Key == course))
                    {
                        findStudent.ScorePerCourse.Add(course, result);
                    }
                    else if(findStudent.ScorePerCourse[course] < result)
                    {
                        findStudent.ScorePerCourse[course] = result;
                    }
                }
                command = Console.ReadLine();
            }
            PrintRanking(students);

        }

        private static void PrintRanking(List<Student> students)
        {
            Student bestStudent = students.OrderByDescending(x => x.ScorePerCourse.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {bestStudent.Name} with total {bestStudent.ScorePerCourse.Values.Sum()} points.");
            Console.WriteLine("Ranking");
            foreach (Student student in students.OrderBy(x => x.Name)) 
            {
                Console.WriteLine(student.Name);
                foreach (var(course, result) in student.ScorePerCourse.OrderByDescending(x=>x.Value)) 
                {
                    Console.WriteLine($"# {course} -> {result}");
                }
            }
        }
    }

  public class Student
    {
       public string Name { get; set; }
       public Dictionary<string,int> ScorePerCourse { get; set; }
        public Student(string name)
        {
            this.Name = name;
            this.ScorePerCourse = new Dictionary<string, int>();
        }
    }
}