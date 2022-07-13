using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PowerUpSpeed : PowerUp
    {
        public PowerUpSpeed(Transform transform, Player player) : base(transform, player)
        {
            base._generalPath += "3.png";
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
                _player.GetFaster();
                Console.WriteLine("Colision");
                base.Destroy();
            }
        }
    }
}
