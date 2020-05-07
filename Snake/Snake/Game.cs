using System.Diagnostics;
using System;
using Mode13h;

namespace Snake
{
    internal class Game
    {
        ScheduleTimer _timer;
        
        public bool Paused { get; private set; }
        public bool Started { get; private set; }
        
        public bool Ended { get; private set; }
        public Action OnTick;
        public void Start()
        {
            Console.WriteLine("Start");
            Started = true;
            Ended = false;
            Tick();
        }

        public void Input(ConsoleKey key)
            {
                Console.WriteLine(key);
            }

        public void Pause()
        {
            Console.WriteLine("Pause"); 
            _timer.Pause();
            Paused = true;
        }

        public void Resume() 
        { 
            Console.WriteLine("Resume"); 
            _timer.Resume();
            Paused = false;
        }

        public void Stop()
        {
            Console.WriteLine("Stop");
            _timer.Pause();
            Ended = true;

        }

        void Tick()
        {
            OnTick?.Invoke();
            ScheduleNextTick();
        }

        void ScheduleNextTick()
        {
            _timer = new ScheduleTimer(150, Tick);
        }
    }
}
