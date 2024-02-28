using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //diarection input
            int xDirInput = 0;
            int yDirInput = 0;

            //player posoition
            int xPos = 10;
            int yPos = 10;

            //world size
            int length = 20;
            int height = 20;

            bool exit = false;
            while (exit == false)
            {

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
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                    }
                    //update Logic
                    xPos += xDirInput;
                    yPos += yDirInput;
                    //reset diacrection input

                    xDirInput = 0;
                    yDirInput = 0;
                    //draw

                    Console.Clear();
                    string screen = "";

                    for (int y = 0; y < length; y++)
                    {
                        for (int x = 0; x < height; x++)
                        {
                            if (xPos == x && yPos == y)
                            {
                                screen += " #";
                            }
                            else 
                            {
                                screen += " .";
                            }

                        }
                        screen += "\n";
                    }
                    Console.WriteLine(screen);

                    Console.WriteLine("Ypos = " + xPos + " : " + "Xpos = " + yPos );
                }

            }
        }
    }
}
