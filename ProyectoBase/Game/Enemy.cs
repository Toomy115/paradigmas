using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Enemy : Actor
    {    
       // protected EnemyMovmentController movmentController;
        protected Player _player;
        protected string _texturePath = "Textures/Enemies/";
        protected int _enemyType;
        protected bool isEnabled;
        protected float currentTimeShoot=0;
        protected float timeToShoot;
        protected int _spawnNum;



        private Animador alien;
        //private Animador currentAnimation;

        public Enemy(int type, float posX, float posY,ref Player player, int spawnNum)
        {
            base._initialPosition = new Vector2(posX, posY);
            base._position = new Vector2(posX, posY);
            base._collider = new Collider(_size,_position);
            base._scale = new Vector2(2, 2);
            base._size = new Vector2(86, 124);
            Random random = new Random();
            timeToShoot = random.Next(200, 600);           
            _enemyType = type;
            _player = player;
            Console.WriteLine("enemy tipe" + type);            
            _spawnNum = spawnNum;
        }

        public Vector2 GetSize
        {
            get { return _size; }
        }
        public Vector2 GetPosition
        {
            get { return _position; }
        }
        public Vector2 GetInitialPosition
        {
            get { return _initialPosition; }
        }
        public int GetSpawnNum
        {
            get { return _spawnNum; }
        }
        public float ChangePosX
        {
            set
            {   
                _position.X += value * _speed * Program.GetDeltaTime;  
            }
            get
            {
                return _position.X;
            }
        }
        public float ChangePosY
        {
            set
            {
                _position.Y += value * _speed * Program.GetDeltaTime;
            }
            get
            {
                return _position.Y;
            }
        }
        
        public Collider GetCollider
        {
            get { return base._collider; }
        }
        public override void Update()
        {
            if(currentTimeShoot >= timeToShoot)
            {
                Shoot();
            }
            else
            {
                currentTimeShoot ++;                   
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
                var bulletActual = bullets[i];
                _player.GetBullet(ref bulletActual);
                if (bullets[i].TimeOfLife <= 0 || bulletActual.isEnabled == false)
                {
                    bullets.RemoveAt(i);
                }
            }
            alien.Update();           
            base._collider.UpdatePosition(_position);
        }

        public override void Draw()
        {
            
            Engine.Draw(alien.CurrentTexture, _position.X, _position.Y, _scale.X, _scale.Y, 0, 30, 62);

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }
        }
        public void Shoot()
        {
            SetShootPosition();
            Bullet bullet = new Bullet(base._shootPoint, 10, 0, bullets.Count(),false);
            bullets.Add(bullet);
            currentTimeShoot = 0;
        }

        private void SetShootPosition()
        {
            base._shootPoint.X = _position.X - 50;
            base._shootPoint.Y = _position.Y;
        }

        protected void CreateAnimations(string color)
        {
            //string color;
            //switch (_enemyType)
            //{
            //    case 1:
            //        color = "BlueAlien";
            //        break;
            //    case 2:
            //        color = "RedAlien";
            //        break;
            //    case 3:
            //        color = "YellowAlien";
            //        break;
            //    default:
            //        color = "BlueAlien";
            //        break;
            //}

            var alienTextures = new List<Texture>();

            for (int i = 1; i <= 3; i++)
            {
                var texture = Engine.GetTexture(_texturePath + color + $"/Alien_{i}.png");
                alienTextures.Add(texture);
            }

            alien = new Animador("alien", 0.2f, alienTextures, true);
        }

        public override void Kill()
        {
            isEnabled = false;
        }

    }
}

