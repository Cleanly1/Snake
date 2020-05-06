using System.Collections.Generic;
using System;

namespace Snake
{
    public class SnakeParts
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Orientation;
        public SnakeParts(int x, int y, string orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
    }
}