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

        public List<SnakeParts> Parts = new List<SnakeParts>();
        public Snake()
        {
            Orientation = "right";
            length = 1;
            Parts.Add(new SnakeParts(320 / 2, 200 / 2, Orientation));
            Parts.Add(new SnakeParts(320 / 2, 200 / 2, Orientation));
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

        public void CheckForCol(int x, int y)
        {
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
                if (i != length - 1)
                {
                    switch (part.Orientation)
                    {
                        case "up":
                            screen.SetColor("#336600");
                            screen.Rectangle(part.X, part.Y + 2, 5, 3);
                            screen.SetColor("#000");
                            screen.Rectangle(part.X, part.Y, 5, 2);
                            break;
                        case "down":
                            screen.SetColor("#336600");
                            screen.Rectangle(part.X, part.Y, 5, 3);
                            screen.SetColor("#000");
                            screen.Rectangle(part.X, part.Y + 3, 5, 2);
                            break;
                        case "left":
                            screen.SetColor("#336600");
                            screen.Rectangle(part.X + 2, part.Y, 3, 5);
                            screen.SetColor("#000");
                            screen.Rectangle(part.X, part.Y, 2, 5);
                            break;
                        case "right":
                            screen.SetColor("#336600");
                            screen.Rectangle(part.X, part.Y, 3, 5);
                            screen.SetColor("#000");
                            screen.Rectangle(part.X + 3, part.Y, 2, 5);
                            break;
                    }
                }
                else
                {
                    switch (Orientation)
                    {
                        case "up":
                            screen.SetColor("#336600");
                            screen.Rectangle(part.X, part.Y + 2, 5, 3);
                            screen.SetColor("#000");
                            screen.Rectangle(part.X, part.Y, 5, 2);
                            break;
                        case "down":
                            screen.SetColor("#336600");
                            screen.Rectangle(part.X, part.Y, 5, 3);
                            screen.SetColor("#000");
                            screen.Rectangle(part.X, part.Y + 3, 5, 2);
                            break;
                        case "left":
                            screen.SetColor("#336600");
                            screen.Rectangle(part.X + 2, part.Y, 3, 5);
                            screen.SetColor("#000");
                            screen.Rectangle(part.X, part.Y, 2, 5);
                            break;
                        case "right":
                            screen.SetColor("#336600");
                            screen.Rectangle(part.X, part.Y, 3, 5);
                            screen.SetColor("#000");
                            screen.Rectangle(part.X + 3, part.Y, 2, 5);
                            break;
                    }
                }
            }
        }
        public void Draw(Screen screen)
        {
            if (Parts.Last().X > 320 || Parts.Last().X <= 0 || Parts.Last().Y <= 0 || Parts.Last().Y > 195)
            {
                Console.WriteLine("Exit");
                Environment.Exit(0);
            }

            CheckForCol(Parts.Last().X, Parts.Last().Y);

            Move();
            Show(screen);

            screen.Buffer.Commit();
        }
            
        }
    }
