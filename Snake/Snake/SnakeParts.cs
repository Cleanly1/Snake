namespace Snake
{
    public class SnakeParts
    {
        public int X { get; }
        public int Y { get; }

        public readonly string Orientation;
        public SnakeParts(int x, int y, string orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
    }
}