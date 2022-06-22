using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Weapon : IWeapon
    {
        private int _currentWeapon;
        public int Color
        {
            get { return _currentWeapon; }
            set { _currentWeapon = value; }
        }

        public Weapon()
        {
            Color = 1;
           
        }

        public void ChangeColor(int num)
        {
            Color = num;
        }
    }
}
