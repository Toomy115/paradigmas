using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PowerUpHealth : PowerUp
    {
        public PowerUpHealth(Transform transform, Player player):base(transform,player)
        {
            base._generalPath += "2.png";
        }

        public override void Update()
        {
            base.Update();
            CheckCollitions();
        }
        private void CheckCollitions()
        {
            if (base._collider.IsBoxColliding(_transform.Position, _transform.Size, _player.GetPosition, _player.GetSize))
            {
                _player.GetHealth();
                Console.WriteLine("Colision");
                base.Destroy();
            }
        }
    }
}
