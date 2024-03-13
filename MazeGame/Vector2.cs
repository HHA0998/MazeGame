using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    internal class Vector2
    {
        public int x, y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void AddVector(Vector2 toAdd)
        {
            x += toAdd.x;
            y += toAdd.y;
        }

        public static Vector2 operator +(Vector2 leftVal, Vector2 rightVal )
        {
            return new Vector2(leftVal.x + rightVal.x, leftVal.y + rightVal.y);
        }

        public static Vector2 operator -(Vector2 leftVal, Vector2 rightVal)
        {
            return new Vector2(leftVal.x - rightVal.x, leftVal.y - rightVal.y);
        }
    }
}
