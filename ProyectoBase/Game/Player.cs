using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        public event Action<List<Bullet>> OnListChange;

        private int _lifeStack = 3;
        private float _health = 100;

        private Vector2 _position = new Vector2();

        private float _scaleX = 2f;
        private float _scaleY = 2f;
        //private string _texture;
        private Vector2 _shootPoint = new Vector2();

        private float _speed = 100;
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
            get { return _position.X; }

            set { _position.X = value; }
        }

        public float MoveY
        {
            get { return _position.Y; }

            set { _position.Y = value; }
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
            Engine.Draw(currentAnimation.CurrentTexture, _position.X, _position.Y, _scaleX, _scaleY);
        
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
                EnemyManager.Instance.GetBullet(bullets[i]);
                //if (true....)
                if(bullets[i].TimeOfLife <= 0)
                {
                    bullets.RemoveAt(i);
                   OnListChange.Invoke(bullets);
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
            Bullet bullet = new Bullet(_shootPoint, 10, 0,bullets.Count());
            bullets.Add(bullet);
            OnListChange.Invoke(bullets);
        }
        private void SetShootPosition()
        {
            _shootPoint.X = _position.X + 122;
            _shootPoint.Y = _position.Y + 64;
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
