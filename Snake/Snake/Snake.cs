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

        public int length { get; set; }

        public String SnakeColor { get; set; } = "#336600";
        public String SnakeSecondColor { get; set; } = "#000";

        public readonly List<SnakeParts> Parts = new List<SnakeParts>();
        public Snake()
        {
            Orientation = "right";
            length = 2;
            Parts.Add(new SnakeParts(200 / 2, 200 / 2, Orientation));
            Parts.Add(new SnakeParts(200 / 2, 200 / 2, Orientation));
        }
        
        public void SetDir(int x, int y)
        {
            Xdir = x;
            Ydir = y;
        }

        public void AddPart()
        {
            var firstPart = Parts.Last();
            var newX = firstPart.X;
            var newY = firstPart.Y;
            length++;
            Parts.Add(new SnakeParts(newX, newY, Orientation));
        }

        public void CheckForCol()
        {
            var x = Parts.Last().X;
            var y = Parts.Last().Y;
            /*
            for (var index = 0; index < Parts.Count; index++)
            {
                var part = Parts[index];
                if (x == part.X && y == part.Y && index != Parts.Count)
                {
                    Console.WriteLine("Exit");
                    Environment.Exit(0);
                }
            }*/
        }

        private void Move()
        {
            switch (Orientation)
            {
                case "up":
                    SetDir(0, -5);
                    break;
                case "down":
                    SetDir(0, +5);
                    break;
                case "left":
                    SetDir(-5, 0);
                    break;
                case "right":
                    SetDir(+5, 0);
                    break;
            }
            
            var newX = Parts.Last().X;
            var newY = Parts.Last().Y;

            newX += Xdir;
            newY += Ydir;
            
            Parts.RemoveAt(0);

            Parts.Add(new SnakeParts(newX,newY, Orientation));
            
        }

        private void Show(Screen screen)
        {
            for (int i = 0; i < length; i++)
            {
                
                var part = Parts[i];
                var direction = i != length - 1 ? part.Orientation : Orientation;
                switch (direction)
                {
                    case "up":
                        screen.SetColor(SnakeColor);
                        screen.Rectangle(part.X, part.Y + 2, 5, 3);
                        screen.SetColor(SnakeSecondColor);
                        screen.Rectangle(part.X, part.Y, 5, 2);
                        break;
                    case "down":
                        screen.SetColor(SnakeColor);
                        screen.Rectangle(part.X, part.Y, 5, 3);
                        screen.SetColor(SnakeSecondColor);
                        screen.Rectangle(part.X, part.Y + 3, 5, 2);
                        break;
                    case "left":
                        screen.SetColor(SnakeColor);
                        screen.Rectangle(part.X + 2, part.Y, 3, 5);
                        screen.SetColor(SnakeSecondColor);
                        screen.Rectangle(part.X, part.Y, 2, 5);
                        break;
                    case "right":
                        screen.SetColor(SnakeColor);
                        screen.Rectangle(part.X, part.Y, 3, 5);
                        screen.SetColor(SnakeSecondColor);
                        screen.Rectangle(part.X + 3, part.Y, 2, 5);
                        break;
                }
            }
        }
        public void Draw(Screen screen)
        {
            if (Parts.Last().X == 200 || Parts.Last().X <= 0 || Parts.Last().Y <= 0 || Parts.Last().Y == 200)
            {
                Console.WriteLine("Exit");
                Environment.Exit(0);
            }

            CheckForCol();

            Move();
            Show(screen);

            screen.Buffer.Commit();
        }
            
        }
    }
