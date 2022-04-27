using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class EnemyManager
    {
        private static readonly EnemyManager instance = new EnemyManager();
        private List<EnemyController> enemies = new List<EnemyController>();
        private Vector2 spawnPoint = new Vector2();
        public List<Bullet> bulletsList = new List<Bullet>();
     
        private int maxEnemies = 3;

        //private Vector2 bulletPosition = new Vector2();
        private Bullet _bullet;

    

        public static EnemyManager Instance
        {
            get 
            { 
                return instance; 
            }
        }

        public void Update()
        {
            if(enemies.Count < maxEnemies)
            {
                Console.WriteLine("Entro en if Update");
                Random random = new Random();
                SetSpawnPosition();
                var enemy = new EnemyController(random.Next(1, 4), spawnPoint.X, spawnPoint.Y);
                enemies.Add(enemy);
            }

            for (int i = 0; i < enemies.Count; i++)
            {               
                enemies[i].Update();
            }
        }

        private void SetSpawnPosition()
        {
            var spawnList = Program.GetSpawnList;
            for (int i = 0; i < spawnList.Count; i++)
            {
                if(!spawnList[i].InUse)
                {
                    spawnPoint.X = spawnList[i].GetPosX;
                    spawnPoint.Y = spawnList[i].GetPosY;
                    spawnList[i].InUse = true;
                    break;
                }
            }
        }

        public void GetBullet(Bullet bullet)
        {
            _bullet = bullet;

            CheckCollitions();
        }

        private void CheckCollitions()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].GetCollider.IsBoxColliding(enemies[i].GetPosition, enemies[i].GetSize, _bullet.GetPosition, _bullet.GetSize))
                {
                    Console.WriteLine("Colision");
                }
            }
        }
        public void Draw()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw();
            }
        }
    }
}
