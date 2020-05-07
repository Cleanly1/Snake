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
                    case ConsoleKey.S :
                        game.Start();
                        break;
                    case ConsoleKey.RightArrow:
                        if (game.Paused)
                        {
                            break;
                        }

                        if (snake.Orientation != "left")
                        {
                            snake.Orientation = "right";
                        }

                        break;

                    case ConsoleKey.LeftArrow:
                        if (game.Paused)
                        {
                            break;
                        }
                        if (snake.Orientation != "right")
                        {
                            snake.Orientation = "left";
                            
                        }
                        
                        break;

                    case ConsoleKey.UpArrow:
                        if (game.Paused)
                        {
                            break;
                        }
                        if (snake.Orientation != "down")
                        {
                            snake.Orientation = "up";
                            
                        }
                        
                        break;

                    case ConsoleKey.DownArrow:
                        if (game.Paused)
                        {
                            break;
                        }
                        if (snake.Orientation != "up")
                        {
                            snake.Orientation = "down";
                        }
                        
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
                window.Invoke(() =>
                {
                    _window.Screen.SetColor("#33cc33");
                    _window.Screen.Rectangle(0,0, 320, 200);
                    _window.Screen.SetColor("#000");
                    _window.Screen.Text(320/2 - 50, 200/2, "Press \"S\" to start the game");
                });
                //game.Start();
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
                        _window.Screen.Text(8,8, $"{snake.Parts.First().X} {snake.Parts.First().Y}");
                    });
                };

            };

            _window.Load();
        }
    }
}