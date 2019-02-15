using System;
using System.Collections.Generic;

using task2;

namespace task2
{
    class Student
    {
        public string name;
        public int id;
        public string year_of_study;

        public Student()
        {
            name = Console.ReadLine();
            id = int.Parse(Console.ReadLine());
            year_of_study = Console.ReadLine();
        }


        public Student(string name, int id, string year_of_study)
        {
            this.name = name;
            this.id = id;
            this.year_of_study = year_of_study;
        }
        
        public void PrintInfo()
        {
            Console.WriteLine(name);
            Console.WriteLine(id);
            Console.WriteLine(year_of_study);
        }
    }
}

    class Mainclass  
    {
     static void Main(string[] args)
        {
            Student s = new Student();
            s.PrintInfo(); 
        }
    }

