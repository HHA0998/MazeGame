using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Schema;

namespace MazeGame
{
    internal class Game
    {
        //CLASS VARIABLES

        //diarection input
        int xDirInput = 0;
        int yDirInput = 0;

        //player posoition
        int xPos = 10;
        int yPos = 10;

        //world size
        //int length = 25;
        //int height = 25;
        string[,] levelMap =
        {
          { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", "1", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
        };

        //boarder
        int xBoarder = 0;
        int yBoarder = 0;

        bool exit = false;

        bool debug = false;

        string chars = "x";
        //CONSTRUCTOR HERE
        public Game(string chars)
        {
            //string chars = "x";
            //GAME LOOP
            Console.WriteLine("Want to enter debug mode? : y to accept");
            string userChoice = Console.ReadLine();
            if (userChoice == "y" || userChoice == "Y")
            {
                debug = true;
                DrawCol(chars);
            }
            else
            {
                Draw(chars);
                debug = false;
            }
                xBoarder = levelMap.GetLength(0) - 1;
            yBoarder = levelMap.GetLength(1) - 1;
            while (exit == false)
            {
                //Call functions here
                Inputs();

                Update();

                if (debug == true)
                {
                    DrawCol(chars);
                }
                else
                {
                    Draw(chars);
                }
                //Thread.Sleep(100);
                //Console.Clear();
            }

        }
        //FUNCTIONS HERE


        void Inputs()
        {
            ConsoleKey input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.W:
                    yDirInput = -1;
                    break;
                case ConsoleKey.S:
                    yDirInput = +1;
                    break;
                case ConsoleKey.A:
                    xDirInput = -1;
                    break;
                case ConsoleKey.D:
                    xDirInput = +1;
                    break;
                case ConsoleKey.UpArrow:
                    yDirInput = -1;
                    break;
                case ConsoleKey.DownArrow:
                    yDirInput = +1;
                    break;
                case ConsoleKey.LeftArrow:
                    xDirInput = -1;
                    break;
                case ConsoleKey.RightArrow:
                    xDirInput = +1;
                    break;
            }
        }

        void Update()
        {
            //store previouse position
            int xPosPreviouse = xPos;
            int yPoxPreviouse = yPos;

            //update Logic
            yPos += yDirInput;
            xPos += xDirInput;

            //reset diacrection input
            yDirInput = 0;
            xDirInput = 0;

            if (xPos < 1)
            {
                xPos = 1;
            }
            if (yPos < 1)
            {
                yPos = 1;
            }
            if (xPos > 18)
            {
                xPos = levelMap.GetLength(0) - 2;
            }
            if (yPos > 18)
            {
                yPos = levelMap.GetLength(1) - 2;
            }

            if (levelMap[yPos, xPos] == "0")
            {
                xPos = xPosPreviouse;
                yPos = yPoxPreviouse;
            }


        }
        // length or xPos = levelMap.GetLength(0)
        // height or yPos = levelMap.GetLength(1)


        void Draw(string player)
        {
            //draw
            Console.Clear();

            WriteColor("Your Playing [m4z5G0ME] Developed by [DANTE] \n", ConsoleColor.Blue);

            string screen = "";

            for (int y = 0; y < levelMap.GetLength(1); y++)
            {
                for (int x = 0; x < levelMap.GetLength(0); x++)
                {
                    // draw player
                    if (yPos == y && xPos == x)
                    {
                        screen += " " + player;
                    }
                    // draw boarder
                    else if (yBoarder == y || y == 0)
                    {
                        screen += "[]";
                    }
                    else if (x == 0)
                    {
                        screen += " |";
                    }
                    else if (xBoarder == x)
                    {
                        screen += "| ";
                    }
                    // draw space
                    else
                    {
                        screen += " " + levelMap[y,x];
                    }

                }
                screen += "\n";
            }
            Console.WriteLine(screen);

            WriteColor("Ypos = [" + yPos + "] : " + "Xpos = [" + xPos + "] ", ConsoleColor.Green);
        }
        void DrawCol(string player)
        {
            Console.Clear();

            WriteColor("Your Playing [m4z5G0ME] Developed by [DANTE] \n", ConsoleColor.Blue);

            string screen = "";

            for (int y = 0; y < levelMap.GetLength(1); y++)
            {
                for (int x = 0; x < levelMap.GetLength(0); x++)
                {
                    // Draw player
                    if (yPos == y && xPos == x)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" " + player);
                        Console.ResetColor();
                        screen += " #";
                    }
                    else
                    {
                        // Draw borders
                        if (y == 0 || y == levelMap.GetLength(1) - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[]");
                            Console.ResetColor();
                            screen += "[]";
                        }
                        else if (x == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" |");
                            screen += " |";
                            Console.ResetColor();
                        }
                        else if (x == levelMap.GetLength(0) - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("| ");
                            screen += "| ";
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" " + levelMap[y, x]);
                            screen += " " + levelMap[y, x];
                        }
                    }
                    screen += "\n";
                }
                // Move to the next line after drawing each row
                Console.WriteLine();
            }
            Console.ResetColor();

            WriteColor("\n Ypos = [" + yPos + "] : " + "Xpos = [" + xPos + "] ", ConsoleColor.Green);
        }

        // usage: WriteColor("This is my [message] with inline [color] changes.", ConsoleColor.Yellow);
        static void WriteColor(string message, ConsoleColor color)
        {
            var pieces = Regex.Split(message, @"(\[[^\]]*\])");

            for (int i = 0; i < pieces.Length; i++)
            {
                string piece = pieces[i];

                if (piece.StartsWith("[") && piece.EndsWith("]"))
                {
                    Console.ForegroundColor = color;
                    piece = piece.Substring(1, piece.Length - 2);
                }

                Console.Write(piece);
                Console.ResetColor();
            }

            Console.WriteLine();
        }


    }
}
