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
        private Vector2 _size = new Vector2(142,86);
        private string _texture;
        private Vector2 _shootPoint = new Vector2();
        private float _speed = 100;
        private string _texturePath = "Textures/Enemies/";       
        private int _enemyType;
        private List<Bullet> bullets = new List<Bullet>();
        private EnemyMovmentController movmentController;
        private Collider collider;

        private Animador alien;
        //private Animador currentAnimation;

        public EnemyController(int type, float posX, float posY)
        {
            _enemyType = type;
            _position = new Vector2(posX, posY);

            _initialPosition = new Vector2(posX, posY);

            Console.WriteLine("enemy tipe" + type);
            CreateAnimations();
            movmentController = new EnemyMovmentController(type, this);
            collider = new Collider(_size,_position);
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
            collider.UpdatePosition(_position);
        }

        public void Draw()
        {
            Engine.Draw(alien.CurrentTexture, _position.X, _position.Y, _scaleX, _scaleY);

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }
        }
        public void Shoot()
        {
            SetShootPosition();

            Bullet bullet = new Bullet(_shootPoint, 10, 0, bullets.Count());
            bullets.Add(bullet);

        }

        private void SetShootPosition()
        {
            _shootPoint.X = _position.X - 122;
            _shootPoint.Y = _position.Y + 64;
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

