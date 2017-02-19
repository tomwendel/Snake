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
            ushort points = 0;

            byte width = 140;
            byte height = 40;
            ushort snakeLength = 10;

            // Schlange erstellen
            Coordinate[] playerPositions = new Coordinate[snakeLength];
            for (ushort i = 0; i < playerPositions.Length; i++)
            {
                playerPositions[i].X = 20 - i;
                playerPositions[i].Y = 20;
            }

            Coordinate apple = FindFreeSpot(width, height, playerPositions);
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
                for (byte x = 0; x < width; x++)
                {
                    for (byte y = 0; y < height; y++)
                    {
                        Console.SetCursorPosition(x + 1, y + 1);
                        Console.BackgroundColor = ConsoleColor.Gray;

                        // Ist die Zelle Teil der Schlange?
                        for (ushort i = 0; i < snakeLength; i++)
                        {
                            if (x == playerPositions[i].X && y == playerPositions[i].Y)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                        }

                        // Ist die Zelle Teil des Apfels?
                        if (x == apple.X && y == apple.Y)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }

                        Console.Write(" ");
                    }
                }

                PrintPoints(points);

                // Spieler bewegen
                Coordinate lastPart = playerPositions[snakeLength - 1];
                for (int i = snakeLength - 1; i > 0; i--)
                {
                    playerPositions[i] = playerPositions[i - 1];
                }

                switch (direction)
                {
                    case Direction.Right:
                        playerPositions[0].X++;
                        break;
                    case Direction.Down:
                        playerPositions[0].Y++;
                        break;
                    case Direction.Left:
                        playerPositions[0].X--;
                        break;
                    case Direction.Up:
                        playerPositions[0].Y--;
                        break;
                }

                // Schlange frisst Apfel
                if (CheckCollision(playerPositions[0], apple))
                {
                    // Punkte erhöhen
                    points += 100;

                    // TODO: Schlange verlängern
                    snakeLength++;
                    Coordinate[] temp = new Coordinate[snakeLength];
                    for (ushort i = 0; i < playerPositions.Length; i++)
                    {
                        temp[i] = playerPositions[i];
                    }
                    temp[temp.Length - 1] = lastPart;
                    playerPositions = temp;

                    // Neue Position für den Apfel finden
                    apple = FindFreeSpot(width, height, playerPositions);
                }

                // Schlange frisst sich selbst
                for (ushort i = 1; i < playerPositions.Length; i++)
                {
                    if (CheckCollision(playerPositions[0], playerPositions[i]))
                    {
                        running = false;
                    }
                }

                // Abbruchbedingung
                if (playerPositions[0].X < 0 ||
                    playerPositions[0].Y < 0 ||
                    playerPositions[0].X >= width ||
                    playerPositions[0].Y >= height)
                {
                    running = false;
                }
            }
        }

        static Coordinate FindFreeSpot(byte width, byte height, Coordinate[] player)
        {
            Random random = new Random();
            Coordinate result;

            do
            {
                result.X = random.Next(width);
                result.Y = random.Next(height);
            } while (CheckCollision(result, player));

            return result;
        }

        static bool CheckCollision(Coordinate p1, Coordinate[] snake)
        {
            for (int i = 0; i < snake.Length; i++)
            {
                if (CheckCollision(p1, snake[i]))
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckCollision(Coordinate p1, Coordinate p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        static void PrintPoints(ushort points)
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Points: ");
            Console.Write(points);
        }
    }

    enum Direction
    {
        Right,
        Down,
        Left,
        Up
    }

    struct Coordinate
    {
        public byte X;
        public byte Y;
    }
}
