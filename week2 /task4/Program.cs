using System;
using System.IO;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a name of your file with extention"); // some text

            string name = Console.ReadLine(); //input the name of the new file

            string NewPath = "/Users/ernar/Desktop/path"; //the path
            string NewPath1 = "/Users/ernar/Desktop/path1"; //path1

            string path = Path.Combine(NewPath, name); //adding the name of file to path
            string path1 = Path.Combine(NewPath1, name); //adding the name of file to path1

            bool flag = true; //bool flag which is true

            if (!File.Exists(path)) //if doesnt file exists
            {
                File.Create(path).Dispose();  //create a file in path and Dispose() clears the memory from created file
            }
            else
            {
                flag = false; //flag false
                Console.WriteLine("This file is already exists \n You may cut it to another folder press 'c'"); //some text
                ConsoleKeyInfo press = Console.ReadKey(); //creating key
                if (press.Key == ConsoleKey.C) //if user presses 'C' then this file will move to path1
                {
                    moving(path, path1); //uses the function 
                    Console.WriteLine("File was moved to path1");
                }
                else
                {
                    Console.WriteLine("\nOk, Goodbye!"); //some text   
                }
            }
            if (flag == true) //if flag is true
            {
                Console.WriteLine("File was created if you want to cut it press 'c'"); //some text
                ConsoleKeyInfo press2 = Console.ReadKey(); //key
                if (press2.Key == ConsoleKey.C) //if pressed c then move created file to path 1
                {
                    moving(path, path1); //use func
                    Console.WriteLine("File was moved to path1");
                }
                else
                {
                    Console.WriteLine("\nOk, Goodbye!"); //some text
                }
            }
        }

        public static void moving(string path, string path1) //function to check if file ixists and move it to another path
        {
            if (!File.Exists(path1)) //if file doesnt exists
            {
                File.Move(path, path1); //move from path to path1
            }
            else
            {
                Console.WriteLine("File exists in path1"); //output some text
            }
        }
    }
}