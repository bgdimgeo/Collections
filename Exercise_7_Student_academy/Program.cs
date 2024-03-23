using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.StudentAcademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<double>> academyGrades = new Dictionary<string,List<double>>();
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++) 
            {
                string name = Console.ReadLine();
                if (!academyGrades.ContainsKey(name))
                {
                    academyGrades[name] = new List<double>();
                    double grade = double.Parse(Console.ReadLine());
                    academyGrades[name].Add(grade);
                    academyGrades[name].Add(1);
                }
                else 
                {
                    double grade = double.Parse(Console.ReadLine());
                    academyGrades[name][0] += grade;
                    academyGrades[name][1] += 1;
                }
            }
            foreach (var kvp in academyGrades.Where(item => item.Value[0] / item.Value[1] >= 4.5)) 
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value[0]/kvp.Value[1]:f2}");
            }

        }
    }
}