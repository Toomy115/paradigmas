using System;
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
        public BlueAlien(int type, float posX, float posY, ref Player player, int spawnNum) :base(type,posX,posY,ref player,spawnNum)
        {
            base.CreateAnimations("Blue");
        }

        public override void Update()
        {
            base.Update();
            Movment();
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
