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
        
        private int _movX = 0;
        private int _movY = 0;
        private float _scaleX = 0.1f;
        private float _scaleY = 0.1f;
        private Texture _texture;

        private float _speed = 0;
        private string _texturePath = "Textures/Player/";
        private string _textureFile = "personaje.png";

        public Player ()
        {
            
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
            Engine.Draw(_texturePath + _textureFile, _movX, _movY, _scaleX, _scaleY);
        }

        private void Kill()
        {
            _lifeStack--;
            if (_lifeStack == 0)
            {
                Console.WriteLine("Game Over");
            }
        }
    }

}
