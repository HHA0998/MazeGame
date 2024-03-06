using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        int length = 25;
        int height = 25;

        //boarder
        int xBoarder = 24;
        int yBoarder = 24;

        bool exit = false;

        //CONSTRUCTOR HERE
        public Game()
        {
            //GAME LOOP


           
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
                    yDirInput = 1;
                    break;
                case ConsoleKey.A:
                    xDirInput = -1;
                    break;
                case ConsoleKey.D:
                    xDirInput = 1;
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
        }



        void Draw()
        {
            //draw
            Console.Clear();

            string screen = "";

            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    // draw player
                    if (yPos == y && xPos == x)
                    {
                        screen += " #";
                    }
                    // draw boarder
                    else if (xBoarder == x || yBoarder == y || x == 0 || y == 0)
                    {
                        screen += "[]";
                    }
                    // draw space
                    else
                    {
                        screen += "  ";
                    }

                }
                screen += "\n";
            }
            Console.WriteLine(screen);

            Console.WriteLine("Ypos = " + yPos + " : " + "Xpos = " + xPos);
        }



    }
}
