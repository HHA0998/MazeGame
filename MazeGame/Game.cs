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
        Player player;

        //world size
        string[,] levelMap =
        {
          { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", "0", ".", ".", ".", ".", ".", ".", "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0", ".", "0"},
          { "0", ".", ".", ".", ".", "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "0"},
          { "0", ".", ".", ".", ".", ".", ".", ".", "1", ".", ".", ".", ".", ".", ".", ".", "0", ".", ".", "0"},
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

        int speed = 1;

        string chars = "x";
        //CONSTRUCTOR HERE
        public Game()
        {
            player = new Player(this);
            //GAME LOOP
            Draw();
            xBoarder = levelMap.GetLength(0) - 1;
            yBoarder = levelMap.GetLength(1) - 1;
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
            player.GetInput();
           
        }

        void Update()
        {
            player.Update(levelMap.GetLength(0), levelMap.GetLength(1));

        }
        void Draw()
        {
            //draw
            Console.Clear();

            WriteColor("Your Playing [m4z5G0ME] Developed by [Dante] \n", ConsoleColor.Blue);

            string screen = "";

            for (int y = 0; y < levelMap.GetLength(1); y++)
            {
                for (int x = 0; x < levelMap.GetLength(0); x++)
                {
                    // draw player
                    if (player.IsInPosition(new Vector2(x,y)))
                    {
                        screen += " #";
                    }
                    // draw boarder
                     if (yBoarder == y || y == 0)
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

        //WriteColor("Ypos = [" + playerPosition.y + "] : " + "Xpos = [" + playerPosition.x + "] ", ConsoleColor.Green);
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

        public bool CheckCollision(Vector2 mapPoint)
        {
            return levelMap[mapPoint.y, mapPoint.x] == "0";
        }

    }
}
