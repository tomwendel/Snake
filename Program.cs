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

            // Initialisierung des Fensters
            Console.Title = "Snake 2.0";
            Console.CursorVisible = false;
            Console.SetWindowSize(width + 2, height + 2);
            Console.SetBufferSize(width + 2, height + 2);

            // Initialisierung der Spielfläche
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Clear();

            while (playerPositionX >= 0)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Console.SetCursorPosition(x + 1, y + 1);
                        Console.Write(" ");
                    }
                }

                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(playerPositionX, playerPositionY);
                Console.Write(" ");

                playerPositionX--;
            }
        }
    }
}
