using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
       // public event Action<List<Bullet>> OnListChange;

        private int _lifeStack = 3;
        private float _health = 100;

        private Vector2 _position = new Vector2();
        private Vector2 _initialPosition = new Vector2(0,101);
        private Vector2 _size = new Vector2(59.5f, 182);

        private float _scaleX = 1.75f;
        private float _scaleY = 1.75f;
        //private string _texture;
        private Vector2 _shootPoint = new Vector2();

        private float _speed = 150;
        public List <Bullet> bullets = new List<Bullet>();

        private Collider _collider;
        private Bullet _enemyBullet;
        private int _bulletPosition;

        private Animador idle;
        private Animador shoot;
        private Animador walk;
        private Animador currentAnimation;

        public Player ()
        {
            //_texture =_texturePath + _textureFile;
            _position = _initialPosition;
           CreateAnimations();
            _collider = new Collider(_size, _position);
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
        //public int DeleteBullet
        //{
        //    set { bullets.RemoveAt(value); }
        //}


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
            Engine.Draw(currentAnimation.CurrentTexture, _position.X, _position.Y, _scaleX, _scaleY, 0, 0, 91);
        
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }           
        }

        public void Update()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                EnemyManager.Instance.GetBullet(bullets[i],bullets.IndexOf(bullets[i]));
                bullets[i].Update();
                //if (true....)
                if(bullets[i].TimeOfLife <= 0 || bullets[i].isEnabled == false)
                {
                    bullets.RemoveAt(i);
                    //RemoveBullet(i);
                   //OnListChange.Invoke(bullets);
                }
            }
            currentAnimation.Update();
            _collider.UpdatePosition(_position);
        }      

        public void GetDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0)
            {
                Kill();
            }
            Console.WriteLine("Vida restante: " + _health);
        }

        private void Kill()
        {
            _lifeStack--;
            if (_lifeStack == 0)
            {
                SceneManager.Instance.SetCurrentScene = 3;
                Console.WriteLine("Game Over");
                Restore();
            }
            else
            {
                Respawn();
                Console.WriteLine("Life Stack: " + _lifeStack);
            }
        }

        public void RestoreNextLevel()
        {
            Respawn();
        }
        private void Restore()
        {
            _lifeStack = 3;
            Respawn();
        }

        private void Respawn()
        {
            _position = _initialPosition;
            _health = 100;
        }

        public void Shoot()
        {
            SetShootPosition();
            Bullet bullet = new Bullet(_shootPoint, 10, 0,bullets.Count(),true);
            bullets.Add(bullet);
            //OnListChange.Invoke(bullets);
        }
        private void SetShootPosition()
        {
            _shootPoint.X = _position.X + 115;
            _shootPoint.Y = _position.Y - 37;
        }

        public void GetBullet(ref Bullet bullet)
        {            
            //_bulletPosition = position;
            CheckCollitions(ref bullet);
        }

        private void CheckCollitions(ref Bullet bullet)
        {
            if (_collider.IsBoxColliding(_position, _size, bullet.GetPosition, bullet.GetSize))
            {
                Console.WriteLine("Entro colisiono");
                GetDamage(20);
                bullet.isEnabled = false;
            }
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
