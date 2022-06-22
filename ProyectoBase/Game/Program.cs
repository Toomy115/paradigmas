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
        private static SceneManager sceneManager;
        private static GameManager gameManager;
        private static HUDManager HUDManager;
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
            Engine.Initialize();
            sceneManager = SceneManager.Instance;
            enemyManager = EnemyManager.Instance;
            gameManager = GameManager.Instance;
            startTime = DateTime.Now;          
            //MusicController musicController = new MusicController();
            GenerarSpawnPoints();
            _player1 = new Player();
            controlManager = new ControlManager();
            HUDManager = new HUDManager(_player1,gameManager);
            enemyManager.GetPlayer(_player1);
            gameManager.SetPlayer(ref _player1);
            //_player1.OnListChange += (List<Bullet> bullets) => enemyManager.bulletsList = bullets; 
            
            while (true)
            {
                CalcularDeltaTime();                 
                UpdateManagers();
                if(sceneManager.GetCurrentScene == 1)
                {
                    Update();
                    Draw();
                }
            }
        }

        private static void UpdateManagers()
        {
            sceneManager.Update();
            gameManager.Update();
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

            var newSpawn = new SpawnController(650, 150, 1);
            spawns.Add(newSpawn);

            newSpawn = new SpawnController(500, 300, 2);
            spawns.Add(newSpawn);

            newSpawn = new SpawnController(550, 450, 3);
            spawns.Add(newSpawn);
        }

        private static void Draw()
        {
            Engine.Clear();
            Engine.Draw("Textures/Background/background.png", 0, 0, 1f, 1f);
            _player1.Draw();
            enemyManager.Draw();
            HUDManager.Draw();
            Engine.Show();
        }
    }
}