using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        private int _lifeStack = 3;
        private float _health = 100;
        
        private float _movX = 0;
        private float _movY = 0;
        private float _scaleX = 2f;
        private float _scaleY = 2f;
        private string _texture;
        private float _shootPointX;
        private float _shootPointY;
        private float _speed = 100;
        private string _texturePath = "Textures/Player/";
        private string _textureFile = "Idle_01.png";
        private List <Bullet> bullets = new List<Bullet>();

        private Animador idle;
        private Animador shoot;
        private Animador walk;
        private Animador currentAnimation;

        public Player ()
        {
            //_texture =_texturePath + _textureFile;
           CreateAnimations();
           currentAnimation = idle;

        }

        public float MoveX
        {
            get { return _movX; }

            set { _movX = value; }
        }

        public float MoveY
        {
            get { return _movY; }

            set { _movY = value; }
        }

        public float GetSpeed
        {
            get { return _speed; }
        }
        public float TakeDamage
        {            
            set {               
                _health = _health - value;
                if(_health <= 0)
                {
                    Kill();
                }
            }
        }

        public string SetAnimation
        {
            set 
            { 
                switch(value)
                {
                    case "idle": currentAnimation = idle;
                        break;
                    case "walk":
                        currentAnimation = walk;
                        break;
                    case "shoot":
                        currentAnimation = shoot;
                        break;
                    default: currentAnimation = idle;
                        break;
                }               
            }
        }


        public void Draw()
        {
            Engine.Draw(currentAnimation.CurrentTexture, _movX, _movY, _scaleX, _scaleY);
        
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }           
        }

        public void Update()
        {


            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
                if(bullets[i].TimeOfLife <= 0)
                {
                    bullets.RemoveAt(i);
                }
            }

            currentAnimation.Update();
        }
        private void Kill()
        {
            _lifeStack--;
            if (_lifeStack == 0)
            {
                Console.WriteLine("Game Over");
            }
        }

        public void Shoot()
        {
            SetShootPosition();
   
            Bullet bullet = new Bullet(_shootPointX, _shootPointY, 10, 0,bullets.Count());
            bullets.Add(bullet);

        }
        private void SetShootPosition()
        {
            _shootPointX = _movX + 122;
            _shootPointY = _movY + 64;
        }
       
        private void CreateAnimations()
        {
            var idleTexture = new List<Texture>();
            idleTexture.Add(Engine.GetTexture("Textures/Player/Idle_01.png"));
            idle = new Animador("idle", 1f, idleTexture, false);

            var walkTextures = new List<Texture>();
            for (int i = 1; i <= 4; i++)
            {
                var texture = Engine.GetTexture($"Textures/Player/WalkAnimation/Walk_0{i}.png");
                walkTextures.Add(texture);
            }

            walk = new Animador("walk", 0.2f, walkTextures, false);

            var shootTextures = new List<Texture>();
            for (int i = 1; i <= 5; i++)
            {
                shootTextures.Add(Engine.GetTexture("Textures/Player/ShootAnimation/Shoot_0" + i + ".png"));
            }

            shoot = new Animador("shoot", 0.1f, shootTextures, false);
        }
    }

}
