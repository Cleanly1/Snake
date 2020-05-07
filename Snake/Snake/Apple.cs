using System;
using System.Collections.Generic;
using System.Linq;
using Mode13h;

namespace Snake
{
    public class Apple
    {
        public bool AppleExist;

        public int RandomX;
        public int RandomY;
        public void Draw(Random random, Screen screen, List<SnakeParts> parts)
        {
            if (!AppleExist)
            {
                int baseNumber = 5;
                RandomX = random.Next(1, 62) * baseNumber;
                RandomY = random.Next(1, 38) * baseNumber;
                foreach (var part in parts)
                {
                    if (part.X == RandomX)
                    {
                        RandomX = random.Next(1, 62) * baseNumber;
                    }
                    if (part.Y == RandomY)
                    {
                        RandomY = random.Next(1, 38) * baseNumber;
                    }
                }

                AppleExist = true;
            }
            screen.SetColor("#ff3300");            
            screen.Rectangle(RandomX, RandomY, 5, 5);
        }

        public bool CheckIfEat(Screen screen, List<SnakeParts> parts)
        {
            var head = parts.Last();
            
            if (RandomX == head.X && RandomY == head.Y)
            {
                AppleExist = false;
                return true;
            }

            return false;
        }
    }
}