using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Schema;
using System.IO;

namespace MazeGame
{
    internal class Game
    {
        //CLASS VARIABLES
        Player player;

        //world size
        string[,] levelMap = new string[20, 20];

        //boarder
        int xBoarder = 0;
        int yBoarder = 0;
        public int level = 1;

        bool exit = false;

        bool debug = false;

        //CONSTRUCTOR HERE
        public Game()
        {
            //SaveLevel();
            LoadLevel();
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

            WriteColor("Your Playing [Maze-Game] Developed by [Dante] \n", ConsoleColor.Blue);

            string screen = "";

            for (int y = 0; y < levelMap.GetLength(1); y++)
            {
                for (int x = 0; x < levelMap.GetLength(0); x++)
                {
                    // draw player
                    if (player.IsInPosition(new Vector2(x, y)))
                    {
                        screen += " " + player.icon;
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
                        screen += " " + levelMap[y, x];
                    }

                }
                screen += "\n";
            }
            Console.WriteLine(screen ); // + "JumpPower = [" + player.jump + "] "

            WriteColor("Ypos = [" + player.playerPosition.y + "] : " + "Xpos = [" + player.playerPosition.x + "] ", ConsoleColor.Green);
            if(player.jump >= 1)
            {
                WriteColor("\nJumpPower = [" + player.jump + "] ", ConsoleColor.Green);
            }
            else if(player.jump == 0)
            {
                WriteColor("\nJumpPower = [" + player.jump + "] ", ConsoleColor.Red);
            }
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

        public bool CheckUpgrade(Vector2 mapPoint)
        {
            return levelMap[mapPoint.y, mapPoint.x] == "1";
        }

        public bool CheckLevelBeat(Vector2 mapPoint)
        {
            return levelMap[mapPoint.y, mapPoint.x] == "#";
        }

        public bool CheckTele3(Vector2 mapPoint)
        {
            return levelMap[mapPoint.y, mapPoint.x] == "3";
        }

        public void SaveLevel()
        {
            string level = "";

            for (int y = 0; y < levelMap.GetLength(1); y++)
            {
                for (int x = 0; x < levelMap.GetLength(0); x++)
                {
                    level += levelMap[y, x];
                }
                level += "\n";
            }

            File.WriteAllText("level.txt", level);
        }

        public void LoadLevel(string levelName ="level.txt")
        {
            string level = File.ReadAllText(levelName);
            int x = 0;
            int y = 0;

            for (int i = 0; i < level.Length; i++)
            {
                if (level[i] == '\n') 
                {
                    y++;
                    x = 0;
                    continue;
                }
                levelMap[y, x] = level[i].ToString();
                x++;
            }

        }
    }
}
