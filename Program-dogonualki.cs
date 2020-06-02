using System;
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] xPos = new int[50];
            xPos[0] = 35;
            int[] yPos = new int[50];
            yPos[0] = 20;
            int eatX;
            int eatY;
            int applesEaten = 0;
            decimal Speed = 125m;
            bool isGameOn = true;
            bool isWallHit;
            bool isAppleEaten;
            Random rand = new Random();
            Console.SetCursorPosition(xPos[0], yPos[0]);
            Console.WriteLine((char)200);
            ApplePos(rand, out eatX, out eatY);
            apple(eatX, eatY);
            polya();
            ConsoleKey move = Console.ReadKey().Key;
            do
            {
                if(move==ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(xPos[0], yPos[0]);
                    Console.Write(" ");
                    xPos[0]--;
                }
                else
                {
                    if(move==ConsoleKey.UpArrow)
                    {
                        Console.SetCursorPosition(xPos[0], yPos[0]);
                        Console.Write(" ");
                        yPos[0]--;
                    }
                    else
                    {
                        if(move==ConsoleKey.RightArrow)
                        {
                            Console.SetCursorPosition(xPos[0], yPos[0]);
                            Console.Write(" ");
                            xPos[0]++;
                        }
                        else
                        {
                            if(move==ConsoleKey.DownArrow)
                            {
                                Console.SetCursorPosition(xPos[0], yPos[0]);
                                Console.Write(" ");
                                yPos[0]++;
                            }
                        }
                    }
                }
                printSnake(applesEaten, xPos, yPos, out xPos, out yPos);
                isWallHit = DidSnakeHitWall(xPos[0], yPos[0]);
                if (isWallHit)
                {
                    isGameOn = false;
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n                                                 !!!Game Ower!!!");
                }
                isAppleEaten = AppleWasEaten(xPos[0], yPos[0], eatX, eatY);
                if (isAppleEaten)
                {
                    ApplePos(rand, out eatX, out eatY);
                    apple(eatX, eatY);
                    applesEaten++;
                    Speed *= .925m;
                }
                if (Console.KeyAvailable) move = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(Convert.ToInt32(Speed));
            } while (isGameOn);
            Console.ReadKey();
        }
        private static void printSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.WriteLine((char)200);
            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
                Console.WriteLine("*");
            }
            Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
            Console.WriteLine(" ");
            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
        }
        private static bool AppleWasEaten(int xPos, int yPos, int eatX, int eatY)
        {
            if (xPos == eatX && yPos == eatY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void apple(int eatX, int eatY)
        {
            Console.SetCursorPosition(eatX, eatY);
            Console.Write((char)64);
        }
        private static void ApplePos(Random rand, out int eatX, out int eatY)
        {
            eatX = rand.Next(0 + 2, 40 - 2);
            eatY = rand.Next(0 + 2, 40 - 2);
        }
        private static bool DidSnakeHitWall(int xPos, int yPos)
        {
            if (xPos == 1 || xPos == 40 || yPos == 1 || yPos == 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void polya()
        {
            for (int i = 0; i < 41; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(40, i);
                Console.Write("#");
            }
            for (int i = 1; i < 40; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, 40);
                Console.Write("#");
            }
        }
    }
}