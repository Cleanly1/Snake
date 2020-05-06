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
        
        public int Xdir { get; set; }
        
        public int Ydir { get; set; }

        public int length { get; set; }

        public List<SnakeParts> Parts = new List<SnakeParts>();
        public Snake()
        {
            X = 320 / 2;
            Y = 200 / 2;
            Orientation = "right";
            length = 1;
            Parts.Add(new SnakeParts(X, Y, Orientation));
        }
        
        public void setDir(int x, int y)
        {
            Xdir = x;
            Ydir = y;
        }

        public void AddPart()
        {
            var firstPart = Parts.First();
            firstPart.X += Xdir;
            firstPart.Y += Ydir;
            length++;
            Parts.Add(new SnakeParts(firstPart.X, firstPart.Y, Orientation));
        }
        
        private void Update()
        {
            var firstPart = Parts.First();
            Parts.RemoveAt(0);
            firstPart.X += Xdir;
            firstPart.Y += Ydir;
            Parts.Add(firstPart);
            /*
            switch (Orientation)
            {
                case "up":
                    var part = new SnakeParts(firstPart.X, firstPart.Y - 5, Orientation);
                    break;
                case "down":
                    Parts.Add(new SnakeParts(firstPart.X, firstPart.Y + 5, Orientation));
                    break;
                case "left":
                    Parts.Add(new SnakeParts(firstPart.X - 5, firstPart.Y, Orientation));
                    break;
                case "right":
                    Parts.Add(new SnakeParts(firstPart.X + 5, firstPart.Y, Orientation));
                    break;
            }*/



        }

        public void Show(Screen screen)
        {
            for (int i = 0; i < length; i++)
            {
                var part = Parts[i];
                if (Orientation == "up" || Orientation == "down")
                {
                    screen.SetColor("#336600");
                    screen.Rectangle(part.X, part.Y, 5, 5);
                    /*
                    screen.SetColor("#000");
                    screen.Rectangle(part.X, part.Y + 3, 5, 2);
                    */
                }
                else
                {
                    screen.SetColor("#336600");
                    screen.Rectangle(part.X, part.Y, 5, 5);
                    /*
                    screen.SetColor("#000");
                    screen.Rectangle(part.X + 3, part.Y, 2, 5);
                    */
                }
            }
        }
        public void Draw(Screen screen)
        {
            if (Parts.First().X > 315 || Parts.First().X <= 0 || Parts.First().Y <= 0 || Parts.First().Y > 195)
            {
                Console.WriteLine("Exit");
                Environment.Exit(0);
            }

            Update();
            Show(screen);

            
            screen.Buffer.Commit();
        }
            
        }
    }
