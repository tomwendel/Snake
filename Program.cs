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

            int playerPositionX2 = 19;
            int playerPositionY2 = 20;

            int playerPositionX3 = 18;
            int playerPositionY3 = 20;

            Direction direction = Direction.Up;

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
                            if (direction < Direction.Right)
                                direction = Direction.Up;
                            break;
                        case ConsoleKey.RightArrow:
                            direction++;
                            if (direction > Direction.Up)
                                direction = Direction.Right;
                            break;
                        case ConsoleKey.Escape:
                            running = false;
                            break;
                    }
                }

                // Spielfeld Ausgabe
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Console.SetCursorPosition(x + 1, y + 1);
                        if ((x == playerPositionX && y == playerPositionY) ||
                            (x == playerPositionX2 && y == playerPositionY2) ||
                            (x == playerPositionX3 && y == playerPositionY3))
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
                playerPositionX3 = playerPositionX2;
                playerPositionY3 = playerPositionY2;

                playerPositionX2 = playerPositionX;
                playerPositionY2 = playerPositionY;

                switch (direction)
                {
                    case Direction.Right:
                        playerPositionX++;
                        break;
                    case Direction.Down:
                        playerPositionY++;
                        break;
                    case Direction.Left:
                        playerPositionX--;
                        break;
                    case Direction.Up:
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

    enum Direction
    {
        Right,
        Down,
        Left,
        Up
    }
}
