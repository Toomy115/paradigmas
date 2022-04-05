using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        private static float deltaTime;
        private static DateTime startTime;
        private static float lastFrameTime;        
        private static Player _player1 = new Player();

        public static void Update()
        {
            if (Engine.GetKey(Keys.W))
            {
               // movY--;
            }
            if (Engine.GetKey(Keys.D))
            {
                //movX++;
            }
            if (Engine.GetKey(Keys.S))
            {
                //movY++;
            }
            if (Engine.GetKey(Keys.A))
            {
                //movX--;
            }
        }
        static void Main(string[] args)
        {
            startTime = DateTime.Now;
            Engine.Initialize();
                //el profe dijo que por ahora la musica de fondo va en program, la trampa de este ejercicio es hacer que la musica vuelva
                //a  funcionar despues de que se reproduce otro sonido. Mientras tengamos solo un sonido simplemente usemos lo que puse aca.
                //SoundPlayer musicPlayer = new SoundPlayer("BGM.wav");
                //musicPlayer.PlayLooping();
            while(true)
            {
                CalcularDeltaTime();
                Update();
                Draw();
                Engine.Show();
            }
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
        }
    }
}