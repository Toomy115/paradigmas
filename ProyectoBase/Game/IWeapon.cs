using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IWeapon
    {
        int Color { get; set; }

        void ChangeColor(int num);
            
    }
}
