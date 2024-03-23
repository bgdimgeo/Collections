using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentOne = new Student("Ivan", 15, true);
            var secondStudent = new Student("Stamat", 16, true);
            var studentThree = new Student("Maria", 17, true);
            var studentFour = new Student("John", 13, true);
            var studentFive = new Student("Eli", 15, false);

            List<Student> students = new List<Student>() {
                studentOne,
                secondStudent,
                studentThree,
                studentFour,
                studentFive
            };
            //All students above 14 
            var above14Students = students.Where(student => student.Age > 14).Select(student => student.Name).ToArray();
            Console.WriteLine(String.Join(" ", above14Students));
            //All active students 
            var allActiveStudents = students.Where(student => student.IsActive).Select(student => student.Name).ToArray();
            Console.WriteLine(String.Join(" ", allActiveStudents));
            //All inactive students 
            var allInactiveStudents = students.Where(student => !student.IsActive).Select(student => student.Name).ToArray();
            Console.WriteLine(String.Join(" ", allInactiveStudents));
            //Avarage age of students
            var avarageAge = students.Select(student => student.Age).Average();
            Console.WriteLine(avarageAge);
            //are there any inactive students 
            var inactiveExist = students.Any(students => !students.IsActive);
            var inactiveCount = students.Count(student => !student.IsActive);

            bool isTrue = true;
            int value = int.Parse(isTrue);
            Console.WriteLine(value);
        }
    }
    class Student 
    {
        public Student(string name, int age, bool isActive)
        {
            this.Name = name;
            this.Age = age;
            this.IsActive = isActive;

        }
        public string Name { get; set; }

        public int Age { get; set; }
        public bool IsActive { get; set; } // prop tab tab 
    }
}