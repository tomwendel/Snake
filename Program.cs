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
            int points = 0;

            int width = 140;
            int height = 40;
            int snakeLength = 10;

            Random random = new Random();
            
            Coordinate apple;
            apple.X = random.Next(width);
            apple.Y = random.Next(height);

            Coordinate[] playerPositions = new Coordinate[snakeLength];
            for (int i = 0; i < playerPositions.Length; i++)
            {
                playerPositions[i].X = 20 - i;
                playerPositions[i].Y = 20;
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

                        // Ist die Zelle Teil der Schlange?
                        for (int i = 0; i < snakeLength; i++)
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
                if (playerPositions[0].X == apple.X &&
                    playerPositions[0].Y == apple.Y)
                {
                    // Punkte erhöhen
                    points++;

                    // TODO: Schlange verlängern
                    snakeLength++;
                    Coordinate[] temp = new Coordinate[snakeLength];
                    for (int i = 0; i < playerPositions.Length; i++)
                    {
                        temp[i] = playerPositions[i];
                    }
                    temp[temp.Length - 1] = lastPart;
                    playerPositions = temp;

                    // Neue Position für den Apfel finden
                    apple.X = random.Next(width);
                    apple.Y = random.Next(height);
                }

                // Schlange frisst sich selbst
                for (int i = 1; i < playerPositions.Length; i++)
                {
                    if (playerPositions[0].X == playerPositions[i].X &&
                        playerPositions[0].Y == playerPositions[i].Y)
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
        public int X;
        public int Y;
    }
}
