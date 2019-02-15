using System;
using System.IO;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo("/Users/ernar/Desktop/pp2_"); //path of folder
            Director(dirInfo, 0); //use the function
        }

        public static void Director(DirectoryInfo dir, int tab) //fuction to output list of directories and files
        {
            foreach (DirectoryInfo y in dir.GetDirectories())
            {
                tabs(tab); //use the tabul func
                Console.WriteLine(y.Name); //output names of folders
                Director(y, tab + 1); //useing recurtion repeat while the directories ends
            }
            foreach (FileInfo x in dir.GetFiles())
            {
                tabs(tab); //adds spaces to file
                Console.WriteLine(x.Name); // outputs names of files
            }
        }

        public static void tabs(int tab) //function to add spaces
        {
            for (int i = 0; i < tab; i++)
            {
                Console.Write("     ");
            }
        }
    }
}