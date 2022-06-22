using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IDamageable
    {
        int Points { get; }
        bool IsEnabled { get; set; }

        void Kill();
    }
}
