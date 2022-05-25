using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class RedAlien : Enemy
    {
        public RedAlien(int type, float posX, float posY, ref Player player, int spawnNum) : base(type, posX, posY, ref player, spawnNum)
        {
            base.CreateAnimations("Red");
        }

        public override void Update()
        {
            base.Update();
            Movment();
        }
        private void Movment()
        {
            
        }
    }
}
