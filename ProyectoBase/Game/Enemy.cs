using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Enemy : Actor, IDamageable
    {
        // protected EnemyMovmentController movmentController;
        protected int _points;
        public int Points => _points;
        protected Player _player;
        protected string _texturePath = "Textures/Enemies/";
        protected int _enemyType;
        protected bool isEnabled;
        protected float currentTimeShoot=0;
        protected float timeToShoot;
        protected int _spawnNum;
        protected BulletsPool<Bullet> bulletsPool;
        private Animador alien;
        //private Animador currentAnimation;

        public Enemy(int type, float posX, float posY,ref Player player, int spawnNum,BulletsPool<Bullet> enemyBulletPool)
        {
            base._initialPosition = new Vector2(posX, posY);
            base._transform.Position = new Vector2(posX, posY);
            base._transform.Scale = new Vector2(2, 2);
            base._transform.Size = new Vector2(86, 124);
            base._collider = new Collider(_transform.Size,_transform.Position);
            Random random = new Random();
            timeToShoot = random.Next(200, 600);           
            _enemyType = type;
            _player = player;
            Console.WriteLine("enemy tipe" + type);            
            _spawnNum = spawnNum;
            bulletsPool = enemyBulletPool;
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }
        public Vector2 GetSize
        {
            get { return _transform.Size; }
        }
        public Vector2 GetPosition
        {
            get { return _transform.Position; }
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
                _transform.Position.X += value * _speed * Program.GetDeltaTime;  
            }
            get
            {
                return _transform.Position.X;
            }
        }
        public float ChangePosY
        {
            set
            {
                _transform.Position.Y += value * _speed * Program.GetDeltaTime;
            }
            get
            {
                return _transform.Position.Y;
            }
        }
        
        protected float ChangeSpeed
        {
            set { base._speed = value; }
        }
        public Collider GetCollider
        {
            get { return base._collider; }
        }
        public int GetColor
        {
            get { return _enemyType; }
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
            base._collider.UpdatePosition(_transform.Position);
        }

        public override void Draw()
        {
            
            Engine.Draw(alien.CurrentTexture, _transform.Position.X, _transform.Position.Y, _transform.Scale.X, _transform.Scale.Y, 0, 30, 62);

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }
        }
        public void Shoot()
        {
            SetShootPosition();
            Bullet bullet = bulletsPool.GetElement();
            bullet.SetNumList = bullets.Count();
            bullet.SetPosition = _shootPoint;
            //Bullet bullet = new Bullet(base._shootPoint, 10, 0, bullets.Count(),false);
            bullets.Add(bullet);
            currentTimeShoot = 0;
        }

        private void SetShootPosition()
        {
            base._shootPoint.X = _transform.Position.X - 50;
            base._shootPoint.Y = _transform.Position.Y;
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
            IsEnabled = false;
        }

    }
}

