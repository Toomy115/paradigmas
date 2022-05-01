using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyController
    {
        private float _health = 100;

        private Vector2 _position = new Vector2();
        private Vector2 _initialPosition = new Vector2();
        private float _scaleX = 2f;
        private float _scaleY = 2f;
        private Vector2 _size = new Vector2(86,124);
        private string _texture;
        private Vector2 _shootPoint = new Vector2();
        private float _speed = 100;
        private string _texturePath = "Textures/Enemies/";       
        private int _enemyType;
        public List<Bullet> bullets = new List<Bullet>();
        private EnemyMovmentController movmentController;
        private Collider collider;
        private bool isEnabled;
        private float currentTimeShoot=0;
        private float timeToShoot;
        private Player _player;
        private int _spawnNum;



        private Animador alien;
        //private Animador currentAnimation;

        public EnemyController(int type, float posX, float posY,ref Player player, int spawnNum)
        {
            _enemyType = type;
            _position = new Vector2(posX, posY);
            Random random = new Random();
            timeToShoot = random.Next(200, 600);
            _initialPosition = new Vector2(posX, posY);
            _player = player;
            Console.WriteLine("enemy tipe" + type);
            CreateAnimations();
            movmentController = new EnemyMovmentController(type, this);
            collider = new Collider(_size,_position);
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
            get { return collider; }
        }
        public void Update()
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
            movmentController.Update();
            collider.UpdatePosition(_position);
        }

        public void Draw()
        {
            
            Engine.Draw(alien.CurrentTexture, _position.X, _position.Y, _scaleX, _scaleY, 0, 30, 62);

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }
        }
        public void Shoot()
        {
            SetShootPosition();
            Bullet bullet = new Bullet(_shootPoint, 10, 0, bullets.Count(),false);
            bullets.Add(bullet);
            currentTimeShoot = 0;
        }

        private void SetShootPosition()
        {
            _shootPoint.X = _position.X - 50;
            _shootPoint.Y = _position.Y;
        }

        private void CreateAnimations()
        {
            string color;
            switch (_enemyType)
            {
                case 1:
                    color = "BlueAlien";
                    break;
                case 2:
                    color = "RedAlien";
                    break;
                case 3:
                    color = "YellowAlien";
                    break;
                default:
                    color = "BlueAlien";
                    break;
            }

            var alienTextures = new List<Texture>();

            for (int i = 1; i <= 3; i++)
            {
                var texture = Engine.GetTexture("Textures/Enemies/" + color + $"/Alien_{i}.png");
                alienTextures.Add(texture);
            }

            alien = new Animador("alien", 0.2f, alienTextures, true);
        }

        public void Destroy()
        {
            isEnabled = false;
        }

    }
}

