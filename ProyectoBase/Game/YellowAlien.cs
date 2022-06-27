using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class YellowAlien : Enemy
    {
        private float _maxRangeY = 100;
        private float _minRangeY = 500;
        private int _direccion = 1;
        public YellowAlien(int type, float posX, float posY, ref Player player, int spawnNum, BulletsPool<Bullet> enemyBulletPool) : base(type, posX, posY, ref player, spawnNum,enemyBulletPool)
        {
            base.ChangeSpeed = 100;
            base.CreateAnimations("YellowAlien");
        }

        public override void Update()
        {
            if (!_inExplotion && !_inThunder)
            {
                base.Update();
                Movment();
            }
            else
            {
                base.Update2();
            }
        }
        private void Movment()
        {
            //SE MUEVE ARRIBA Y ABAJO 
            if (base.ChangePosY <= _maxRangeY)
            {
                _direccion = 1;
            }
            else if (base.ChangePosY >= _minRangeY)
            {
                _direccion = -1;
            }
            base.ChangePosY = _direccion;
        }
    }
}
