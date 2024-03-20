using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    internal class Player
    {
        //vars
        public int speed = 1;

        public string icon = "<";

        public int jump = 0;

        public int level = 1;

        //diarection input
        Vector2 directionInput = new Vector2(0, 0);

        //player posoition
         public Vector2 playerPosition = new Vector2(10, 10);

        Game game;

        public Player(Game game)
        {
            this.game = game;
        }


        public void GetInput()
        {
            ConsoleKey input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.W:
                    directionInput.y = -speed;
                    icon = "^";
                    break;
                case ConsoleKey.S:
                    directionInput.y = +speed;
                    icon = "v";
                    break;
                case ConsoleKey.A:
                    icon = "<";
                    directionInput.x = -speed;
                    break;
                case ConsoleKey.D:
                    icon = ">";
                    directionInput.x = +speed;
                    break;
                case ConsoleKey.UpArrow:
                    directionInput.y = -speed;
                    icon = "^";
                    break;
                case ConsoleKey.DownArrow:
                    directionInput.y = +speed;
                    icon = "v";
                    break;
                case ConsoleKey.LeftArrow:
                    directionInput.x = -speed;
                    icon = "<";
                    break;
                case ConsoleKey.RightArrow:
                    directionInput.x = +speed;
                    icon = ">";
                    break;
                case ConsoleKey.Spacebar:
                    if (icon == "v" && jump >= 1)
                    {
                        directionInput.y = +speed * 2;
                        jump--;
                    }
                    if (icon == "^" && jump >= 1)
                    {
                        directionInput.y = -speed * 2;
                        jump--;
                    }
                    if (icon == "<" && jump >= 1)
                    {
                        directionInput.x = -speed * 2;
                        jump --;
                    }
                    if (icon == ">" && jump >= 1)
                    {
                        directionInput.x = +speed * 2;
                        jump--;
                    }
                    break;
            }
        }

        public void Update(int levelmaplength0, int levelmaplengt1)
        {
            Vector2 previousePosition = playerPosition;

            playerPosition += directionInput;

            //reset diacrection input
            directionInput = new Vector2();

            if (game.CheckCollision(playerPosition))
            {
                playerPosition = previousePosition;
            }

            if (game.CheckUpgrade(playerPosition))
            {
                jump++;
            }
            if (game.CheckTele3(playerPosition))
            {
                playerPosition.x = 17;
                playerPosition.y = 2;
            }
            if (game.CheckLevelBeat(playerPosition))
            {
                string levelnumber = ("level" + level + ".txt");
                 game.LoadLevel(levelnumber);
                level++;
            }

            if (playerPosition.x < 1)
            {
                playerPosition.x = 1;
            }
            if (playerPosition.y < 1)
            {
                playerPosition.y = 1;
            }
            if (playerPosition.x > 18)
            {
                playerPosition.x = levelmaplength0 - 2;
            }
            if (playerPosition.y > 18)
            {
                playerPosition.y = levelmaplengt1 - 2;
            }
            directionInput = new Vector2();

        }

        public string Draw()
        {
            return icon;
        }

        public bool IsInPosition(Vector2 position)
        {
            return playerPosition.y == position.y && playerPosition.x == position.x;
        }

    }
}
