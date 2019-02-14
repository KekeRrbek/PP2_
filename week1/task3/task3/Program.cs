using System;
using System.Collections.Generic;

namespace task3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); // Создание и введение количества чисел
            string[] arr = Console.ReadLine().Split(); // Создание и введение чисел через пробел
            List<int> ans = new List<int>(); // Создание листа (вектор) для хранения ответа
              for (int i = 0; i < N; i++) // Обход всех чисел
              {
                  int a = int.Parse(arr[i]);
                  ans.Add(a); // Добавление чисел 
                  ans.Add(a); // Двойное добавление чисел 
              }
              for (int i = 0; i < ans.Count; i++) // Вывод ответа
                  Console.Write(ans[i]);
              Console.ReadKey(); // что-то типо return 0 
              
        }
    }
}
