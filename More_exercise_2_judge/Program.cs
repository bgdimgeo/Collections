using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Judge
{
    internal class Judge
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> problems = new Dictionary<string, List<string>>();
            List<Student> students = new List<Student>();
            while (input != "no more time") 
            {
                string[] variables = input.Split(" -> ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string student = variables[0];
                string problem = variables[1];
                int score = int.Parse(variables[2]);
                if (!problems.ContainsKey(problem))
                {
                    problems[problem] = new List<string>();
                    problems[problem].Add(student);
                    if (!students.Any(x => x.Name == student))
                    {
                        Student currStudent = new Student(student);
                        currStudent.ScorePerCourse.Add(problem, score);
                        students.Add(currStudent);
                    }
                    else 
                    {
                        students.First(x => x.Name == student).ScorePerCourse.Add(problem, score);
                    }
                

                }
                else
                {
                    if (!problems[problem].Contains(student))
                    {
                        problems[problem].Add(student);
                        //Student currStudent = new Student(student);
                        //currStudent.ScorePerCourse.Add(problem, score);
                        //students.Add(currStudent);
                        if (!students.Any(x => x.Name == student))
                        {
                            Student currStudent = new Student(student);
                            currStudent.ScorePerCourse.Add(problem, score);
                            students.Add(currStudent);
                        }
                        else
                        {
                            students.First(x => x.Name == student).ScorePerCourse.Add(problem, score);
;
                        }
                    }
                    else
                    {
                       if (students.First(x => x.Name == student).ScorePerCourse[problem] < score)
                        {
                            students.First(x => x.Name == student).ScorePerCourse[problem] = score;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            //foreach (Student student in students.OrderBy(x => x.Name))
            //{
            //    Console.WriteLine(student.Name);
            //    foreach (var (course, result) in student.ScorePerCourse.OrderByDescending(x => x.Value))
            //    {
            //        Console.WriteLine($"# {course} -> {result}");
            //    }
            //}
            foreach (var kvp in problems) 
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");
                int n = 0;
                Dictionary<string, int> contains = new Dictionary<string, int>();
                foreach (var student in students.Where(x => x.ScorePerCourse.ContainsKey(kvp.Key)))
                {
                    
                    string name = student.Name;
                    int score = student.ScorePerCourse[kvp.Key];
                    contains.Add(name,score);

                }
                foreach (var kvp2 in contains.OrderByDescending(x => x.Value).ThenBy(u => u.Key))
                {
                    n++;
                    Console.WriteLine($"{n}. {kvp2.Key} <::> {kvp2.Value}");
                }
            }

            int m = 0;

            Dictionary<string, int> orderedStudents = new Dictionary<string, int>();

            Console.WriteLine("Individual standings:");
            foreach (var student in students) 
            {
                orderedStudents.Add(student.Name, student.ScorePerCourse.Values.Sum());
            }

            foreach (var student in orderedStudents.OrderByDescending(x => x.Value).ThenBy(u => u.Key)) 
            {
                m++;
                Console.WriteLine($"{m}. {student.Key} -> {student.Value}");
            }
        }
    }
    public class Student
    {
        public string Name { get; set; }

        public int TotalScore { get; set; }
        public Dictionary<string, int> ScorePerCourse { get; set; }
        public Student(string name)
        {
            this.Name = name;
            this.ScorePerCourse = new Dictionary<string, int>();
        }  

    }
}