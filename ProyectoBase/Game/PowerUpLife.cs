using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PowerUpLife : PowerUp
    {
        public PowerUpLife(Transform transform, Player player) : base(transform, player)
        {
            base._generalPath += "1.png";
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
                _player.GetLifeStock();
                Console.WriteLine("Colision");
                base.Destroy();
            }
        }

    }
}
