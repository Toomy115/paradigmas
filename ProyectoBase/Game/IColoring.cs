using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IColoring
    {
        int Color { get; set; }

        void ChangeColor(int color);
    }
}
