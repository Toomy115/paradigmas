using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class RedAlien : Enemy
    {
        private int _direccion = 1;
        public RedAlien(int type, float posX, float posY, ref Player player, int spawnNum) : base(type, posX, posY, ref player, spawnNum)
        {
            base.ChangeSpeed = 80;
            base.CreateAnimations("RedAlien");
        }

        public override void Update()
        {
            base.Update();
            Movment();
        }
        private void Movment()
        {
            if(base.ChangePosY > base._player.MoveY)
            {
                _direccion = -1;
            }
            else if(base.ChangePosY < base._player.MoveY)
            {
                _direccion = +1;
            }
            base.ChangePosY = _direccion;
        }
    }
}
