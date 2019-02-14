using System;

  namespace task1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int cnt = 0; //счетчик = 0
                int n = Convert.ToInt32(Console.ReadLine()); //размер массива 
                string s = Console.ReadLine(); //ввод элементов в массив 
                string[] ss = s.Split(); //сплитет (игнорировает пробел во время считоваие элементов 
                int[] a = new int[n]; //создаем массив
                for (int i = 0; i < n; i++)//добоваляем элементы в массив 
                {
                    a[i] = int.Parse(ss[i]);//записовает сплитнутый массива в другой массив 
                    if (IsPrime(a[i]))//число прайм или нет 
                    {
                        cnt++;//если прайм то  +1
                    }
                }
                Console.WriteLine(cnt);//число прайм чисел 
                for (int i = 0; i < n; i++)//прайм числа 
                {
                    if (IsPrime(a[i]))
                    {
                        Console.Write(a[i] + " ");
                    }
                }
                Console.WriteLine();
            }

            static bool IsPrime(int num) //функция прайм или не прайм 
            {
                if (num <= 1) return false; //если меньше или равно 1 то не прайм 
                for (int i = 2; i <= Math.Sqrt(num); i++) //форик для нахаждения он прйм или нет  
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }
                return true;//в другом случий  
            }
        }
    }


