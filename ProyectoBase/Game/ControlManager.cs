using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ControlManager
    {
        private Player player;

        public ControlManager()
        {
            Start();
        }
        private void Start()
        {
            player = Program.ObtenerJugador();
        }
        public void CheckInput()
        {
            if (Engine.GetKey(Keys.W))
            {
                player.MoveY = player.MoveY - player.GetSpeed * Program.GetDeltaTime;
            }
            if (Engine.GetKey(Keys.D))
            {
                player.MoveX = player.MoveX + player.GetSpeed * Program.GetDeltaTime;
            }
            if (Engine.GetKey(Keys.S))
            {
                player.MoveY = player.MoveY + player.GetSpeed * Program.GetDeltaTime;
            }
            if (Engine.GetKey(Keys.A))
            {
                player.MoveX = player.MoveX - player.GetSpeed * Program.GetDeltaTime;
            }
            if (Engine.GetKey(Keys.SPACE))
            {
                player.Shoot();
            }
        }
            

        
    }
}
