using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bullet
    {
        private float _movX = 0;
        private float _movY = 0;
        private float _speed = 500f;
        private int _damage;
        private int _numColor;
        private float _timeToDestroy = 100;
        private float _scaleX = 2f;
        private float _scaleY = 2f;
        private int numInList;

        private string _texturePath = "Textures/Objects/";
        private string _textureFile = "NewBullet.png";
        private string _texture;

        public float TimeOfLife
        {
            get { return _timeToDestroy; }
        }
        private int SetDamage
        {
            set { _damage = value; }
        }

        private int SetColor
        {
            set { _numColor = value; }
        }
        public Bullet(float posInicialX, float posInicialY, int damage, int numColor, int numList)
        {
            _movX = posInicialX;
            _movY = posInicialY;
            numInList = numList;
            _texture = _texturePath + _textureFile;
            SetDamage = damage;
            
        }
        //public Bullet(float posInicialX, float posInicialY, int damage, Texture texture, int numColor)
        //{
        //    _movX = posInicialX;
        //    _movY = posInicialY;
        //    _texture = _texturePath + _textureFile;
        //    SetDamage = damage;
            
        //}
        //ancho dividido 2 + x, alto dividido 2 + y, multiplicar por la escala
        public void Update()
        {           
            Move();
        }
        private void Move()
        {
                Console.WriteLine($"{_movX}");
          
                _movX += _speed * Program.GetDeltaTime;

                _timeToDestroy--;          
        }

        public void Draw()
        {
            Engine.Draw(_texture, _movX, _movY, _scaleX, _scaleY,0,0,0);
        }

        private void Destroy()
        { 
            
        }
    }
}
