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

        private float _movX = 0;
        private float _movY = 0;
        private float _initialPosX = 0;
        private float _initialPosY = 0;
        private float _scaleX = 2f;
        private float _scaleY = 2f;
        private string _texture;
        private float _shootPointX;
        private float _shootPointY;
        private float _speed = 100;
        private string _texturePath = "Textures/Enemies/";       
        private int _enemyType;
        private List<Bullet> bullets = new List<Bullet>();
        private EnemyMovmentController movmentController;

        private Animador alien;
        //private Animador currentAnimation;

        public EnemyController(int type, float posX, float posY)
        {
            _enemyType = type;
            _movX = posX;
            _movY = posY;
            _initialPosX = posX;
            _initialPosY = posY;
            Console.WriteLine("enemy tipe" + type);
            CreateAnimations();
            movmentController = new EnemyMovmentController(type, this);
        }

        public float GetInitialPosX
        {
            get { return _initialPosX; }
        }
        public float GetInitialPosY
        {
            get { return _initialPosY; }
        }
        public float ChangePosX
        {
            set
            {
                _movX += value * _speed * Program.GetDeltaTime;
                
            }
            get
            {
                return _movX;
            }
        }
        public float ChangePosY
        {
            set
            {
                _movY += value * _speed * Program.GetDeltaTime;
            }
            get
            {
                return _movY;
            }
        }

        public void Update()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
                if (bullets[i].TimeOfLife <= 0)
                {
                    bullets.RemoveAt(i);
                }
            }

            alien.Update();
            movmentController.Update();
            
        }
        public void Draw()
        {
            Engine.Draw(alien.CurrentTexture, _movX, _movY, _scaleX, _scaleY);

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }
        }
        public void Shoot()
        {
            SetShootPosition();

            Bullet bullet = new Bullet(_shootPointX, _shootPointY, 10, 0, bullets.Count());
            bullets.Add(bullet);

        }

        private void SetShootPosition()
        {
            _shootPointX = _movX - 122;
            _shootPointY = _movY + 64;
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
    }
}

