using System;
using System.Collections.Generic;
using System.Linq;
using Mode13h;

namespace Snake
{
    public class Snake
    {
        public string Orientation { get; set; }
        
        public int Xdir { get; set; }
        
        public int Ydir { get; set; }

        public int Length { get; set; }

        public String SnakeColor { get; set; } = "#336600";
        public String SnakeSecondColor { get; set; } = "#000";

        public readonly List<SnakeParts> Parts = new List<SnakeParts>();
        public Snake()
        {
            Orientation = "right";
            Length = 2;
            Parts.Add(new SnakeParts(200 / 2, 200 / 2, Orientation));
            Parts.Add(new SnakeParts(200 / 2 - 10, 200 / 2, Orientation));
        }
        
        private void SetDir(int x, int y)
        {
            Xdir = x;
            Ydir = y;
        }

        public void AddPart()
        {
            var firstPart = Parts.Last();
            var newX = firstPart.X;
            var newY = firstPart.Y;
            Length++;
            Parts.Add(new SnakeParts(newX, newY, Orientation));

        }

        public bool CheckForCol()
        {
            var x = Parts.Last().X;
            var y = Parts.Last().Y;
            
            if (Parts.Last().X == 200 || Parts.Last().X < 0 || Parts.Last().Y < 0 || Parts.Last().Y == 200)
            {
                return true;
            }

            for (var i = 0; i < Parts.Count - 1; i++)
            {
                var part = Parts[i];
                if (part.X == x && part.Y == y)
                {
                    return true;
                }
            }

            return false;
        }

        private void Move()
        {
            switch (Orientation)
            {
                case "up":
                    SetDir(0, -10);
                    break;
                case "down":
                    SetDir(0, +10);
                    break;
                case "left":
                    SetDir(-10, 0);
                    break;
                case "right":
                    SetDir(+10, 0);
                    break;
            }
            
            var newX = Parts.Last().X;
            var newY = Parts.Last().Y;

            newX += Xdir;
            newY += Ydir;
            
            Parts.RemoveAt(0);

            Parts.Add(new SnakeParts(newX, newY, Orientation));
            
        }

        private void Show(Screen screen)
        {
            for (int i = 0; i < Length; i++)
            {
                
                var part = Parts[i];
                var direction = i != Length - 1 ? part.Orientation : Orientation;
                switch (direction)
                {
                    case "up":
                        screen.SetColor(SnakeColor);
                        screen.Rectangle(part.X, part.Y + 4, 10, 6);
                        screen.SetColor(SnakeSecondColor);
                        screen.Rectangle(part.X, part.Y, 10, 4);
                        break;
                    case "down":
                        screen.SetColor(SnakeColor);
                        screen.Rectangle(part.X, part.Y, 10, 6);
                        screen.SetColor(SnakeSecondColor);
                        screen.Rectangle(part.X, part.Y + 6, 10, 4);
                        break;
                    case "left":
                        screen.SetColor(SnakeColor);
                        screen.Rectangle(part.X + 4, part.Y, 6, 10);
                        screen.SetColor(SnakeSecondColor);
                        screen.Rectangle(part.X, part.Y, 4, 10);
                        break;
                    case "right":
                        screen.SetColor(SnakeColor);
                        screen.Rectangle(part.X, part.Y, 6, 10);
                        screen.SetColor(SnakeSecondColor);
                        screen.Rectangle(part.X + 6, part.Y, 4, 10);
                        break;
                }
            }
        }
        public void Draw(Screen screen)
        {
            Move();
            Show(screen);

            

            screen.Buffer.Commit();
        }
            
        }
    }
