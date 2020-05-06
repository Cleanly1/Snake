using System;
using System.Collections.Generic;
using System.Linq;
using Mode13h;

namespace Snake
{
    class Program
    {
        static readonly Random Random = new Random();
        static Window _window;
        static Snake snake { get; set; }
        public static int Score { get; set; }
        
        static void Main(string[] args)
        {
            var game = new Game();
            var apple = new Apple();
            _window = new Window(3)
            {
                Title = "Snake"
            };

            _window.OnKeyDown = key =>
            {
                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        if (game.Paused)
                        {
                            break;
                        }
                        snake.setDir(+5, 0);
                        break;

                    case ConsoleKey.LeftArrow:
                        if (game.Paused)
                        {
                            break;
                        }

                        snake.setDir(-5, 0);
                        break;

                    case ConsoleKey.UpArrow:
                        if (game.Paused)
                        {
                            break;
                        }
                        snake.setDir(0, -5);
                        break;

                    case ConsoleKey.DownArrow:
                        if (game.Paused)
                        {
                            break;
                        }
                        snake.setDir(0, +5);
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("Exit");
                        Environment.Exit(0);
                        break;
                    
                    case ConsoleKey.P:
                        if (game.Paused)
                        {
                            game.Resume();
                        }
                        else
                        {
                            game.Pause();
                        }

                        break;

                    default:
                        return;
                }
            };

            _window.OnReady = window =>
            {
                game.Start();
                snake = new Snake();
                game.OnTick = () =>
                {
                    window.Invoke(() =>
                    {
                        _window.Screen.SetColor("#33cc33");
                        _window.Screen.Rectangle(0,0, 320, 200);
                        apple.Draw(Random, _window.Screen, snake.Parts);
                        snake.Draw(_window.Screen);
                        if (apple.CheckIfEat(_window.Screen, snake.Parts))
                        {
                            snake.AddPart();
                            Score += 1;
                        }
                        _window.Screen.Text(1, 1, $"Score: {Score}");
                        _window.Screen.Text(8,8, $"{apple.RandomX} {apple.RandomY}");
                    });
                };

            };
            
            
            
            _window.Load();
        }
    }
}