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
        protected bool isEnabled = true;
        protected float currentTimeShoot=0;
        protected float timeToShoot;
        protected int _spawnNum;
        protected int _maxSpeed = 350;
        private Vector2 _offsetNormal = new Vector2(30, 62);
        private Vector2 _offsetThunder = new Vector2(20, 1300);
        private Vector2 _offset;
        private Vector2 _normalScale = new Vector2(2, 2);
        private Vector2 _thunderScale = new Vector2(1.2f, 2);
        protected BulletsPool<Bullet> bulletsPool;
        private Animador alien;
        private Animador normalAlien;
        private Animador explotion;
        private Animador thunder;
        protected bool _inExplotion = false;
        protected bool _inThunder = false;        
        private int _maxExplotionTexture = 7;
        private int _maxThunderTexture = 3;
        //private Animador currentAnimation;

        public Enemy(int type, float posX, float posY,ref Player player, int spawnNum, int speed, BulletsPool<Bullet> enemyBulletPool)
        {
            _inThunder = true;
            base._initialPosition = new Vector2(posX, posY);
            base._transform.Position = new Vector2(posX, posY);
            base._transform.Scale = _thunderScale;
            base._transform.Size = new Vector2(86, 124);
            base._collider = new Collider(_transform.Size,_transform.Position);
            base._collider.Activated = false;
            base._speed = speed;
            Random random = new Random();
            timeToShoot = random.Next(300, 600);           
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

        public Transform GetTransform
        {
            get { return _transform; }
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

        protected void Update2()
        {
            alien.Update();
        }

        public override void Draw()
        {           
            Engine.Draw(alien.CurrentTexture, _transform.Position.X, _transform.Position.Y, _transform.Scale.X, _transform.Scale.Y, 0, _offset.X, _offset.Y);
            if(!_inExplotion && !_inThunder)
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    bullets[i].Draw();
                }
            }
            else
            {
                if(_inThunder)
                {
                    if(alien.CurrentFrame >= _maxThunderTexture)
                    {
                        _inThunder = false;
                        alien.CurrentFrame = 0;
                        alien = normalAlien;
                        _offset = _offsetNormal;
                        _transform.Scale = _normalScale;
                        base._collider.Activated = true;
                    }
                }
                else if(alien.CurrentFrame >= _maxExplotionTexture)
                {
                    IsEnabled = false;
                }
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
            var alienTextures = new List<Texture>();

            for (int i = 1; i <= 3; i++)
            {
                var texture = Engine.GetTexture(_texturePath + color + $"/Alien_{i}.png");
                alienTextures.Add(texture);
            }

            normalAlien = new Animador("alien", 0.2f, alienTextures, true);

            var explotionTextures = new List<Texture>();
            for (int i = 1; i <= 8; i++)
            {
                var texture = Engine.GetTexture(_texturePath + $"Explotion/Capa {i}.png");
                explotionTextures.Add(texture);
            }

            explotion = new Animador("explotion", 0.09f, explotionTextures, false);

            var thunderTextures = new List<Texture>();
            for (int i = 1; i <= 4; i++)
            {
                var texture = Engine.GetTexture(_texturePath + $"Thunder/Capa {i}.png");
                thunderTextures.Add(texture);
            }

            thunder = new Animador("thunder", 0.1f, thunderTextures, false);

            alien = thunder;
            _offset = _offsetThunder;
        }

        public override void Kill()
        {
            alien = explotion;
            _transform.Scale = new Vector2(1, 1);
            _inExplotion = true;
            _collider.Activated = false;
            alien.CurrentFrame = 0;
            //IsEnabled = false;
        }

    }
}

