using System;
using System.Collections.Generic;
using System.Linq;
using Mode13h;

namespace Snake
{
    public class Apple
    {
        private bool _appleExist;

        private int _randomX;
        private int _randomY;
        public void Draw(Random random, Screen screen, List<SnakeParts> parts)
        {
            if (!_appleExist)
            {
                int baseNumber = 10;
                _randomX = random.Next(1, 20) * baseNumber;
                _randomY = random.Next(1, 20) * baseNumber;
                foreach (var part in parts)
                {
                    if (part.X == _randomX)
                    {
                        _randomX = random.Next(1, 20) * baseNumber;
                    }
                    if (part.Y == _randomY)
                    {
                        _randomY = random.Next(1, 20) * baseNumber;
                    }
                }

                _appleExist = true;
            }
            screen.SetColor("#ff3300");            
            screen.Rectangle(_randomX, _randomY, 10, 10);
        }

        public bool CheckIfEat(Screen screen, List<SnakeParts> parts)
        {
            var head = parts.Last();

            if (_randomX != head.X || _randomY != head.Y) return false;
            
            _appleExist = false;
            return true;

        }
    }
}