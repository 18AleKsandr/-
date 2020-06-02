using System;
namespace ConsoleApp4
{
    class Game
    {
        public static int[,] Play(int a, int b, out int x1,out int y1, out int x2, out int y2, int[,]mas)
        {
            int s1 = 0;
            Random rand = new Random();
            x1 = rand.Next(b);
            y1 = rand.Next(a);
            x2 = rand.Next(b);
            y2 = rand.Next(a);
            while(s1==0)
            {
                x2 = rand.Next(b);
                if (x2 != x1)
                    s1 = 1;
            }
            while(s1==1)
            {
                y2 = rand.Next(a);
                if (y2 != y1)
                    s1 = 0;
            }
            mas[y1, x1] = 1;
            mas[y2, x2] = 2;
            for (int i = 0; i < a; i++) 
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(mas[i, j]);
                }
                Console.WriteLine();
            }
            return mas;
        }
        public static void Move(ConsoleKeyInfo f, int a, int b, int x1, int y1, out int x11, out int y11)
        {
            if(f.Key==ConsoleKey.UpArrow)
            {
                if (y1 > 0)
                    y1 -= 1;
                else
                    y1 = a - 1;
            }
            else
                if (f.Key == ConsoleKey.DownArrow)
            {
                if (y1 < a - 1)
                    y1 += 1;
                else
                    y1 = 0;
            }
            else
                if (f.Key == ConsoleKey.LeftArrow)
            {
                if (x1 > 0)
                    x1 -= 1;
                else
                    x1 = b - 1;
            }
            else
                if (f.Key == ConsoleKey.RightArrow)
            {
                if (x1 < b - 1)
                    x1 += 1;
                else
                    x1 = 0;
            }
            x11 = x1;
            y11 = y1;
        }
        public static void Vrag(int a, int b, int x1, int y1, int x2, int y2, out int x22, out int y22)
        {
            int k;
            Random rand = new Random();
            k = rand.Next(4);

            if (k == 0)
            {
                if (y2 < a - 1 && y2 + 1 != y1 && x2 != x1)
                    y2 += 1;
                else if (y1 != 0 && y2 == a - 1)
                    y2 = 0;
            }
            else
            {
                if (k == 1)
                {
                    if (y2 > 0 && y2 - 1 != y1 && x2 != x1)
                        y2 -= 1;
                    else if (y1 != a - 1 && y2 == 0)
                        y2 = a - 1;
                }
                else
                {
                    if (k == 2)
                    {
                        if (x2 > 0 && x2 - 1 != x1 && y2 != y1)
                            x2 -= 1;
                        else if (x1 != b - 1 && x2 == 0)
                            x2 = b - 1;
                    }
                    else
                    {
                        if (k == 3)
                        {
                            if (x2 < b - 1 && x2 + 1 != x1 && y2 != y1)
                                x2 += 1;
                            else if (x1 != 0 && x2 == b - 1)
                                x2 = 0;
                        }
                    }
                }

            }
            x22 = Math.Abs(x2);
            y22 = Math.Abs(y2);
        }
        public static int Win(int x1, int y1, int x2, int y2)
        {
            int s = 0;
            if (x1 == x2 && y1 == y2)
            {
                s = 1;
            }
            return s;
        }
    }
}