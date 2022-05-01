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
        //public List<Bullet> bulletsList = new List<Bullet>();
     
        private int maxEnemies = 3;
        private Player _player;
        //private Vector2 bulletPosition = new Vector2();
        private Bullet _bullet;
        private int _bulletPosition;

    

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
                
                Random random = new Random();
                var spawnNum = SetSpawnPosition();
                var enemy = new EnemyController(random.Next(1, 4), spawnPoint.X, spawnPoint.Y,ref _player, spawnNum);
                enemies.Add(enemy);
            }

            for (int i = 0; i < enemies.Count; i++)
            {               
                enemies[i].Update();
            }
        }

        public void GetPlayer(Player player)
        {
            _player = player;
        }



        private int SetSpawnPosition()
        {
            var spawnList = Program.GetSpawnList;
            for (int i = 0; i < spawnList.Count; i++)
            {
                if(!spawnList[i].InUse)
                {
                    spawnPoint.X = spawnList[i].GetPosX;
                    spawnPoint.Y = spawnList[i].GetPosY;
                    //spawnList[i].InUse = true;
                    Program.GetSpawnList[i].InUse = true;
                    return Program.GetSpawnList[i].GetNumSpawn;
                }
            }
            return 0;
        }

        public void GetBullet(Bullet bullet, int position)
        {
            _bullet = bullet;
            _bulletPosition = position;
            CheckCollitions();
        }

        private void CheckCollitions()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].GetCollider.IsBoxColliding(enemies[i].GetPosition, enemies[i].GetSize, _bullet.GetPosition, _bullet.GetSize))
                {
                    Console.WriteLine("Colision");
                    //_bullet.Destroy();
                    //_player.DeleteBullet(_bulletPosition);
                    //_player.bullets.RemoveAt(_bulletPosition);
                    _player.bullets[_bulletPosition].isEnabled = false;

                    Program.GetSpawnList[enemies[i].GetSpawnNum-1].InUse = false;
                    enemies.RemoveAt(i);
                    GameManager.Instance.EnemiesDestroyedUpgrade = 1;
                    Console.WriteLine("Enemigos Destruidos: " + GameManager.Instance.GetEnemiesDestroyed);
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
