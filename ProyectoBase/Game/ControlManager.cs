using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ControlManager
    {
        private float currentTimeShoot = 30;
        private float cooldownTime = 30;
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
            if (currentTimeShoot < cooldownTime)
            {
                currentTimeShoot++;
            }
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
            if (Engine.GetKey(Keys.SPACE) && currentTimeShoot >= cooldownTime)
            {
                currentTimeShoot = 0;
                player.Shoot();
            }
        }
            

        
    }
}
