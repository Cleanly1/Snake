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
                            break;
                        }

                        _window.Invoke(() => { _window.Screen.Text(205, 8, "Paused"); });
                        game.Pause();
                        

                        break;
                    
                    case ConsoleKey.S:

                        if (!game.Started)
                        {
                            game.Start(); 
                        }
                        
                        break;
                    
                    case ConsoleKey.B:
                        if (!game.Started)
                        {
                            snake.SnakeColor = "#0000ff";
                            snake.SnakeSecondColor = "#ffff00";
                        }
                        
                        break;
                    
                    case ConsoleKey.O:
                        if (!game.Started)
                        {
                            snake.SnakeColor = "#ff9900";
                            snake.SnakeSecondColor = "#ffcc00";
                            
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
                    _window.Screen.Rectangle(0,0, 200, 200);
                    _window.Screen.SetColor("#669999");
                    _window.Screen.Rectangle(200,0, 120, 200);
                    _window.Screen.SetColor("#000");
                    _window.Screen.Rectangle(200, 0, 2, 200);
                    _window.Screen.SetColor("#000");
                    _window.Screen.Text(200/2 - 40, 200/2 - 20, "Press \"S\" to start the game");
                    _window.Screen.Text(205, 10, "Press \"B\" for Blue Snake");
                    _window.Screen.Text(205, 15, "Press \"O\" for Orange Snake");
                });
                
                snake = new Snake();
                game.OnTick = () =>
                {
                    if (snake.CheckForCol())
                    {
                        game.Stop();
                        window.Invoke(() => 
                        {
                            _window.Screen.SetColor("#ff9900");
                            _window.Screen.Rectangle( 75, 45, 60, 60);
                            _window.Screen.SetColor("#000");
                            _window.Screen.Rectangle( 80, 50, 50, 50);
                            _window.Screen.SetColor("#FFF");
                            _window.Screen.Text(90, 67, "GAME OVER");
                            _window.Screen.Text(84, 74, "Press \"ESC\" to");
                            _window.Screen.Text(93, 79, "End Game");
                        });
                    }
                    window.Invoke(() =>
                    {
                        if (game.Ended) return;
                        _window.Screen.SetColor("#33cc33");
                        _window.Screen.Rectangle(0, 0, 200, 200);
                        apple.Draw(Random, _window.Screen, snake.Parts);
                        if (apple.CheckIfEat(_window.Screen, snake.Parts))
                        {
                            snake.AddPart();
                            snake.AddPart();
                            Score += 1;
                        }
                        snake.Draw(_window.Screen);
                        _window.Screen.SetColor("#669999");
                        _window.Screen.Rectangle(200, 0, 120, 200);
                        _window.Screen.SetColor("#000");
                        _window.Screen.Rectangle(200, 0, 2, 200);
                        _window.Screen.SetColor("#000");
                        _window.Screen.Text(205, 2, $"Score: {Score}");

                    });
                    
                };

            };

            _window.Load();
        }
    }
}