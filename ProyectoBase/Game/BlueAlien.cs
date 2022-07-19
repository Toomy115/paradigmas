﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BlueAlien : Enemy
    {
        private float _maxRangeX = 700;
        private float _minRangeX = 400;
        private int _direccion = 1;
        public BlueAlien(int type, float posX, float posY, ref Player player, int spawnNum, int speed, BulletsPool<Bullet> enemyBulletPool) :base(type,posX,posY,ref player,spawnNum, speed, enemyBulletPool)
        {            
            base.CreateAnimations("BlueAlien");
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
            //IZQUIERDA Y DERECHA
            if (base.ChangePosX >= _maxRangeX)
            {
                _direccion = -1;
            }
            else if (base.ChangePosX <= _minRangeX)
            {
                _direccion = 1;
            }

            base.ChangePosX = _direccion;
        }

        
    }
}
