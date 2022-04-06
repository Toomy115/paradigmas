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
        private float _scaleX = 0.1f;
        private float _scaleY = 0.1f;
        private string _texture;
        private float _shootPointX;
        private float _shootPointY;
        private float _speed = 100;
        private string _texturePath = "Textures/Player/";
        private string _textureFile = "personaje.png";
        private List <Bullet> bullets = new List<Bullet>();

        public Player ()
        {
            _texture =_texturePath + _textureFile;
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

        public void Draw()
        {
            Engine.Draw(_texture, _movX, _movY, _scaleX, _scaleY);
           
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
   
            Bullet bullet = new Bullet(_movX, _movY, 10, 0,bullets.Count());
            bullets.Add(bullet);

        }
        private void SetShootPosition()
        {
            _shootPointX = _movX + 5;
            _shootPointY = _movY + 5;
        }
       
    }

}
