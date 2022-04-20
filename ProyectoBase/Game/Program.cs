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
        private static EnemyManager enemyManager;
        private static List<SpawnController> spawns;


        public Player ObtenerPlayer
        {
            get { return _player1; }
        }

        public static float GetDeltaTime
        {
            get { return deltaTime; }
        }

        public static List<SpawnController> GetSpawnList
        {
            get { return spawns; }
        }
        public static void Update()
        {
            controlManager.CheckInput();
            _player1.Update();
            enemyManager.Update();
        }
        static void Main(string[] args)
        {
            enemyManager = EnemyManager.Instance;
            startTime = DateTime.Now;
            Engine.Initialize();
            MusicController musicController = new MusicController();
            GenerarSpawnPoints();
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

        private static void GenerarSpawnPoints()
        {
            spawns = new List<SpawnController>();

            var newSpawn = new SpawnController(650, 200, 1);
            spawns.Add(newSpawn);

            newSpawn = new SpawnController(500, 350, 2);
            spawns.Add(newSpawn);

            newSpawn = new SpawnController(600, 450, 3);
            spawns.Add(newSpawn);
        }

        private static void Draw()
        {
            Engine.Clear();
            Engine.Draw("Textures/Background/background.png", 0, 0, 1f, 1f);
            _player1.Draw();
            enemyManager.Draw();
            Engine.Show();
        }
    }
}