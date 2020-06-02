using System;
namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов: ");
            int b = Convert.ToInt32(Console.ReadLine());
            
            Console.Clear();
            int x1, y1, x2, y2, p = 0;
            int[,] mas = new int[a, b];
            Game.Play(a, b, out x1, out y1, out x2, out y2, mas);
            ConsoleKeyInfo f;
            while (p == 0)
            {
                f = Console.ReadKey();
                Console.WriteLine();
                int x11, y11;
                
                Game.Move(f, a, b, x1, y1, out x11, out y11);
                mas[y11, x11] = 1;
                mas[y1, x1] = 0;
                x1 = x11;
                y1 = y11;
                p = Game.Win(x1, y1, x2, y2);
                Console.Clear();
                int x22, y22;
                
                Game.Vrag(a, b, x1, y1, x2, y2, out x22, out y22);
                if (x22 != x2 || y22 != y2)
                {
                    mas[y22, x22] = 2;
                    mas[y2, x2] = 0;
                }
                else
                    mas[y22, x22] = 2;
                x2 = x22;
                y2 = y22;
                if (p == 1)
                {
                    break;
                }
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        Console.Write(mas[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n                                                 !!!WIN!!!");
            Console.ReadKey();
        }
    }
}