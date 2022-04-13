using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ControlManager
    {
        private float currentTimeShoot = 40;
        private float cooldownTime = 40;
        private Player player;
        private bool isShoot = false;
        private bool isWalking = false;
        private float timeAnimatorShoot = 0.5f;
        private float timeAnimatorInitialize = 0;

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
            if (isShoot == false)
            {
                if (Engine.GetKey(Keys.W))
                {
                    player.MoveY = player.MoveY - player.GetSpeed * Program.GetDeltaTime;
                    isWalking = true;
                }
                if (Engine.GetKey(Keys.D))
                {
                    player.MoveX = player.MoveX + player.GetSpeed * Program.GetDeltaTime;
                    isWalking = true;
                }
                if (Engine.GetKey(Keys.S))
                {
                    player.MoveY = player.MoveY + player.GetSpeed * Program.GetDeltaTime;
                    isWalking = true;
                }
                if (Engine.GetKey(Keys.A))
                {
                    player.MoveX = player.MoveX - player.GetSpeed * Program.GetDeltaTime;
                    isWalking = true;
                }
            }
            
            if (Engine.GetKey(Keys.SPACE) && currentTimeShoot >= cooldownTime)
            {
                currentTimeShoot = 0;
                player.Shoot();
                player.SetAnimation = "shoot";
                isShoot = true;
            }
            if (isShoot == true)
            {
                timeAnimatorInitialize += Program.GetDeltaTime;
                if(timeAnimatorInitialize >= timeAnimatorShoot)
                {
                    player.SetAnimation = "idle";
                    timeAnimatorInitialize = 0;
                    isShoot = false;
                }               
            }
            else if (isWalking == true)
            {
                player.SetAnimation = "walk";
                isWalking = false;
            }
            else
            {
                player.SetAnimation = "idle";
            }
        }                  
    }
}
