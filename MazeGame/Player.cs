using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    internal class Player
    {
        //vars
        public int speed = 1;

        string icon = "#";

        //diarection input
        Vector2 directionInput = new Vector2(0, 0);

        //player posoition
        Vector2 playerPosition = new Vector2(10, 10);

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
                    break;
                case ConsoleKey.S:
                    directionInput.y = +speed;
                    break;
                case ConsoleKey.A:
                    directionInput.x = -speed;
                    break;
                case ConsoleKey.D:
                    directionInput.x = +speed;
                    break;
                case ConsoleKey.UpArrow:
                    directionInput.y = -speed;
                    break;
                case ConsoleKey.DownArrow:
                    directionInput.y = +speed;
                    break;
                case ConsoleKey.LeftArrow:
                    directionInput.x = -speed;
                    break;
                case ConsoleKey.RightArrow:
                    directionInput.x = +speed;
                    break;
            }
        }

        public void Update(int levelmaplength0, int levelmaplengt1)
        {
            Vector2 previousePosition = playerPosition;

            playerPosition += directionInput;

            //reset diacrection input
            directionInput = new Vector2();

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

            if (game.CheckCollision(playerPosition))
            {
                playerPosition = previousePosition;
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
