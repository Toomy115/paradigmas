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
        private float spawnPointX;
        private float spawnPointY;
        private int maxEnemies = 3;

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
                var enemy = new EnemyController(random.Next(1, 4), spawnPointX, spawnPointY);
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
                    spawnPointX = spawnList[i].GetPosX;
                    spawnPointY = spawnList[i].GetPosY;
                    spawnList[i].InUse = true;
                    break;
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
