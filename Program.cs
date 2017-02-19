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
            int direction = 2;

            // Initialisierung des Fensters
            Console.Title = "Snake 2.0";
            Console.CursorVisible = false;
            Console.SetWindowSize(width + 2, height + 2);
            Console.SetBufferSize(width + 2, height + 2);

            // Initialisierung der Spielfläche
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Clear();

            while (true)
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

                if (playerPositionX <= 0)
                    direction = 0;
            }
        }
    }
}
