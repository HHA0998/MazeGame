﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MazeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //define
            bool playing = false;
            playing = true;

            while (playing == true)
            {
                new Game();
            }
        }
    }
}
