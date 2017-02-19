using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 140;
            int height = 40;

            int playerPositionX = 20;
            int playerPositionY = 20;

            /*
             * 0 = rechts
             * 1 = unten
             * 2 = links
             * 3 = oben
             */
            int direction = 3;

            // Initialisierung des Fensters
            Console.Title = "Snake 2.0";
            Console.CursorVisible = false;
            Console.SetWindowSize(width + 2, height + 2);
            Console.SetBufferSize(width + 2, height + 2);

            // Initialisierung der Spielfläche
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Clear();

            bool running = true;
            while (running)
            {
                // Usereingabe
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    switch (info.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            direction--;
                            break;
                        case ConsoleKey.RightArrow:
                            direction++;
                            break;
                        case ConsoleKey.Escape:
                            running = false;
                            break;
                    }

                    direction = (direction + 4) % 4;
                }

                // Spielfeld Ausgabe
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Console.SetCursorPosition(x + 1, y + 1);
                        if (x == playerPositionX && y == playerPositionY)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }

                        Console.Write(" ");
                    }
                }

                // Spieler bewegen
                switch (direction)
                {
                    case 0:
                        playerPositionX++;
                        break;
                    case 1:
                        playerPositionY++;
                        break;
                    case 2:
                        playerPositionX--;
                        break;
                    case 3:
                        playerPositionY--;
                        break;
                }

                // Abbruchbedingung
                if (playerPositionX < 0 ||
                    playerPositionY < 0 ||
                    playerPositionX >= width ||
                    playerPositionY >= height)
                {
                    running = false;
                }
            }
        }
    }
}
