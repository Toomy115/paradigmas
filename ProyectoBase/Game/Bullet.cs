using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bullet
    {
        private float _speed = 5;
        private int _damage;
        private int _numColor;
        private int SetDamage
        {
            set { _damage = value; }
        }

        private int SetColor
        {
            set { _numColor = value; }
        }
        public Bullet (int posInicial, int damage, Texture texture, int numColor)
        {

            SetDamage = damage;
        }
        static void Update()
        {
            do
            {

            } while (true);
        }

    }
}
