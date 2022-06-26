using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate void WeaponChangeEventHandler(int weapon);
    public class ControlManager
    {
        public event WeaponChangeEventHandler OnWeaponChange;
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
            //player.weapon = new Weapon(this);
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
                    if (player.MoveY >= 100)
                    {
                        player.MoveY = player.MoveY - player.GetSpeed * Program.GetDeltaTime;
                        isWalking = true;
                    }
                }
                if (Engine.GetKey(Keys.D))
                {
                    if (player.MoveX <= 300)
                    {
                        player.MoveX = player.MoveX + player.GetSpeed * Program.GetDeltaTime;
                        isWalking = true;
                    }
                }
                if (Engine.GetKey(Keys.S))
                {
                    if (player.MoveY <= 500)
                    {
                        player.MoveY = player.MoveY + player.GetSpeed * Program.GetDeltaTime;
                        isWalking = true;
                    }
                }
                if (Engine.GetKey(Keys.A))
                {
                    if (player.MoveX >= 0)
                    {
                        player.MoveX = player.MoveX - player.GetSpeed * Program.GetDeltaTime;
                        isWalking = true;
                    }
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
            if (Engine.GetKey(Keys.NUMPAD1))
            {
                player.ChangeColor(1);
            }
            if (Engine.GetKey(Keys.NUMPAD2))
            {
                player.ChangeColor(2);
            }
            if (Engine.GetKey(Keys.NUMPAD3))
            {
                player.ChangeColor(3);
            }
        } 
        
    }
}
