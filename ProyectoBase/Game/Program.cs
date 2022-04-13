using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        private static float deltaTime;
        private static DateTime startTime;
        private static float lastFrameTime;
        private static Player _player1;
        private static ControlManager controlManager;

        public Player ObtenerPlayer
        {
            get { return _player1; }
        }

        public static float GetDeltaTime
        {
            get { return deltaTime; }
        }
        public static void Update()
        {
            controlManager.CheckInput();
            _player1.Update();
        }
        static void Main(string[] args)
        {
            startTime = DateTime.Now;
            Engine.Initialize();
            MusicController musicController = new MusicController();
           
            _player1 = new Player();
            controlManager = new ControlManager();

            while (true)
            {
                CalcularDeltaTime();               
                Update();
                Draw();
            }
        }

        public static Player ObtenerJugador()
        {
            return _player1;
        }
        private static void CalcularDeltaTime()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }

        private static void Draw()
        {
            Engine.Clear();
            Engine.Draw("Textures/Background/background.png", 0, 0, 1f, 1f);
            _player1.Draw();

            Engine.Show();
        }
    }
}