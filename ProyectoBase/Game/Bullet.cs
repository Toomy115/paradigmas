using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet
    {
        private Vector2 _position = new Vector2();
        //private float _movX = 0;
        //private float _movY = 0;
        private Vector2 _size = new Vector2(12, 14);
        private float _speed = 500f;
        private int _damage;
        private int _numColor;
        private float _timeToDestroy = 100;
        private float _scaleX = 2f;
        private float _scaleY = 2f;
        private int numInList;
        private Collider collider;
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
        public Vector2 GetSize
        {
            get { return _size; }
        }
        public Vector2 GetPosition
        {
            get { return _position; }
        }
        public Bullet(Vector2 position, int damage, int numColor, int numList)
        {
            _position = position;
            numInList = numList;
            _texture = _texturePath + _textureFile;
            SetDamage = damage;
            collider = new Collider(_size,_position);
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
            collider.UpdatePosition(_position);
            
        }
        private void Move()
        {          
                _position.X += _speed * Program.GetDeltaTime;

                _timeToDestroy--;          
        }

        public void Draw()
        {
            Engine.Draw(_texture, _position.X, _position.Y, _scaleX, _scaleY,0,0,0);
        }

        private void Destroy()
        { 
            
        }
    }
}
