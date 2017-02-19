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
            int snakeLength = 10;

            int[] playerPositionsX = new int[snakeLength];
            for (int i = 0; i < playerPositionsX.Length; i++)
            {
                playerPositionsX[i] = 20 - i;
            }

            int[] playerPositionsY = new int[snakeLength];
            for (int i = 0; i < playerPositionsY.Length; i++)
            {
                playerPositionsY[i] = 20;
            }

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
                        Console.BackgroundColor = ConsoleColor.Gray;
                        for (int i = 0; i < snakeLength; i++)
                        {
                            if (x == playerPositionsX[i] && y == playerPositionsY[i])
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                        }

                        Console.Write(" ");
                    }
                }

                // Spieler bewegen
                for (int i = snakeLength - 1; i > 0; i--)
                {
                    playerPositionsX[i] = playerPositionsX[i - 1];
                    playerPositionsY[i] = playerPositionsY[i - 1];
                }

                switch (direction)
                {
                    case Direction.Right:
                        playerPositionsX[0]++;
                        break;
                    case Direction.Down:
                        playerPositionsY[0]++;
                        break;
                    case Direction.Left:
                        playerPositionsX[0]--;
                        break;
                    case Direction.Up:
                        playerPositionsY[0]--;
                        break;
                }

                // Abbruchbedingung
                if (playerPositionsX[0] < 0 ||
                    playerPositionsY[0] < 0 ||
                    playerPositionsX[0] >= width ||
                    playerPositionsY[0] >= height)
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
