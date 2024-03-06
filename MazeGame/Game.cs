using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
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

        //CONSTRUCTOR HERE
        public Game()
        {
            //GAME LOOP
            xBoarder = levelMap.GetLength(0) - 1;
            yBoarder = levelMap.GetLength(1) - 1;

            Draw();
            while (exit == false)
            {
                //Call functions here
                Inputs();

                Update();

                Draw();



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

        }
        // length or xPos = levelMap.GetLength(0)
        // height or yPos = levelMap.GetLength(1)


        void Draw()
        {
            //draw
            Console.Clear();

            string screen = "";

            for (int y = 0; y < levelMap.GetLength(1); y++)
            {
                for (int x = 0; x < levelMap.GetLength(0); x++)
                {
                    // draw player
                    if (yPos == y && xPos == x)
                    {
                        screen += " #";
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
