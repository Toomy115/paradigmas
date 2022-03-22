using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        public static float deltaTime;
        public static DateTime startTime;
        public static float lastFrameTime;
        public static int movX = 0;
        public static int movY = 0;

        public static void Update()
        {
            if (Engine.GetKey(Keys.W))
            {
                movY--;
            }
            if (Engine.GetKey(Keys.D))
            {
                movX++;
            }
            if (Engine.GetKey(Keys.S))
            {
                movY++;
            }
            if (Engine.GetKey(Keys.A))
            {
                movX--;
            }
        }
        static void Main(string[] args)
        {
            startTime = DateTime.Now;
            Engine.Initialize();

            while(true)
            {
                Engine.Clear();
                Update();
                Engine.Draw("background.png", 0, 0, 1f, 1f);
                Engine.Draw("personaje.png",movX,movY,0.05f,0.05f);
                Engine.Show();
                var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
                deltaTime = currentTime - lastFrameTime;
                lastFrameTime = currentTime;               
            }
        }
    }
}