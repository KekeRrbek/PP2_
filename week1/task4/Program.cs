using System 
namespace task4
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                string[,] s = new string[n, n];
                for (int row = 0; row < n; row++)
                {
                    for (int collom = 0; j <=row; collom++)
                    {
                        s[row,collom] = "[*]";
                        Console.Write(s[row, collom]);
                    }

                    Console.WriteLine();
              }
            Console.ReadKey;s
            }
        }
    }



