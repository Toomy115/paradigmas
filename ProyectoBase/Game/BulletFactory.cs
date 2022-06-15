using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class BulletFactory
    {
        public enum EnumBullets { PlayerBullet, EnemyBullet };

        public static Bullet CreateBullet(EnumBullets bullet)
        {
            if(bullet == EnumBullets.PlayerBullet)
            {
                return new Bullet(10, 0, true);
            }
            else
            {
                return new Bullet(10, 0, false);
            }            
        }
    }
}
