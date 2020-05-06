using System;
using System.Collections.Generic;
using System.Linq;
using Mode13h;

namespace Snake
{
    public class Snake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Orientation { get; set; }
        public string OldOrientation { get; set; }

        public List<int> TurnCord;

        public List<SnakeParts> Parts = new List<SnakeParts>();
        public Snake()
        {
            X = 320 / 2;
            Y = 200 / 2;
            Orientation = "right";
            OldOrientation = "right";
            TurnCord = new List<int>{X, Y};
            Parts.Add(new SnakeParts(X,Y,Orientation));
            AddPart();
        }

        public void AddPart()
        {
            var lastPart = Parts.Last();
            switch (lastPart.Orientation)
            {
                case "up":
                    Parts.Add(new SnakeParts(lastPart.X, lastPart.Y + 5, lastPart.Orientation));
                    break;
                case "down":
                    Parts.Add(new SnakeParts(lastPart.X, lastPart.Y - 5, lastPart.Orientation));
                    break;
                case "left":
                    Parts.Add(new SnakeParts(lastPart.X + 5, lastPart.Y, lastPart.Orientation));
                    break;
                case "right":
                    Parts.Add(new SnakeParts(lastPart.X -5, lastPart.Y, lastPart.Orientation));
                    break;
            }
        }
        public void Draw(Screen screen)
        {
            if (Parts.First().X > 315 || Parts.First().X <= 0 || Parts.First().Y <= 0 || Parts.First().Y > 195)
            {
                Console.WriteLine("Exit");
                Environment.Exit(0);
            }

            foreach (var part in Parts)
            {
                if (part.X == TurnCord[0] || part.Y == TurnCord[1])
                {
                    switch (Orientation)
                    {
                        case "down":
                            part.Y += 5;
                            break;
                        case "up":
                            part.Y -= 5;
                            break;
                        case "right":
                            part.X += 5;
                            break;
                        case "left":
                            part.X -= 5;
                            break;
                    }

                    part.Orientation = Orientation;
                }
                else if (part.X != TurnCord[0] && part.Y != TurnCord[1])
                {
                    switch (OldOrientation)
                    {
                        case "down":
                            part.Y += 5;
                            break;
                        case "up":
                            part.Y -= 5;
                            break;
                        case "right":
                            part.X += 5;
                            break;
                        case "left":
                            part.X -= 5;
                            break;
                    }

                    part.Orientation = OldOrientation;
                }

                if (Orientation == "up" || Orientation == "down")
                {
                    screen.SetColor("#336600");
                    screen.Rectangle(part.X, part.Y, 5, 3);
                    screen.SetColor("#000");
                    screen.Rectangle(part.X, part.Y + 3, 5, 2);
                }
                else
                {
                    screen.SetColor("#336600");
                    screen.Rectangle(part.X, part.Y, 3, 5);
                    screen.SetColor("#000");
                    screen.Rectangle(part.X + 3, part.Y, 2, 5);
                }
            }
            screen.Buffer.Commit();
        }
    }
}