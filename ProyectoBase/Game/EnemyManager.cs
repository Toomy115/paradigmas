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
        private List<Enemy> enemies = new List<Enemy>();
        private Vector2 spawnPoint = new Vector2();
        //public List<Bullet> bulletsList = new List<Bullet>();
     
        private int maxEnemies = 3;
        private Player _player;
        //private Vector2 bulletPosition = new Vector2();
        private Bullet _bullet;
        private int _bulletPosition;
        BulletsPool<Bullet> enemyBulletPool = new BulletsPool<Bullet>(createBullet);


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
                int color = random.Next(1, 4);              
                if (color == 1)//azul
                {
                    var enemy = new BlueAlien(1, spawnPoint.X, spawnPoint.Y,ref _player, spawnNum,enemyBulletPool);
                    enemies.Add(enemy);
                }
                else if (color == 2)//red
                {
                    var enemy = new RedAlien(2, spawnPoint.X, spawnPoint.Y, ref _player, spawnNum, enemyBulletPool);
                    enemies.Add(enemy);
                }
                else//yellow
                {
                    var enemy = new YellowAlien(3, spawnPoint.X, spawnPoint.Y, ref _player, spawnNum, enemyBulletPool);
                    enemies.Add(enemy);
                }                
            }

            CheckAlienKilled();

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update();               
            }
        }

        public static Bullet createBullet()
        {
            Bullet bullet = BulletFactory.CreateBullet(BulletFactory.EnumBullets.EnemyBullet); //new Bullet(10, 0, false);
            return bullet;
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
                    if (_player.bullets[_bulletPosition].GetColor == enemies[i].GetColor)
                    {
                        enemies[i].Kill();
                        /*Program.GetSpawnList[enemies[i].GetSpawnNum - 1].InUse = false;
                        enemies.RemoveAt(i);
                        GameManager.Instance.EnemiesDestroyedUpgrade = 1;
                        Console.WriteLine("Enemigos Destruidos: " + GameManager.Instance.GetEnemiesDestroyed);*/
                    }
                }
            }
        }

        private void CheckAlienKilled()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].IsEnabled == false)
                {
                    Program.GetSpawnList[enemies[i].GetSpawnNum - 1].InUse = false;
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
