using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class LifeStackManager
    {
        private Transform transform = new Transform();
        private string _path = "Textures/HUD/Life Stack/";
        private string _texturePath;

        public LifeStackManager()
        {
            //player.OnLifeStackChange += new LifeStackChangeEventHandler(ChangeTexture);
            transform.Position = new Vector2(10, 40);
            transform.Size = new Vector2(68, 14);
            transform.Scale = new Vector2(2, 2);
            ChangeTexture(3);
        }
        public void ChangeTexture(int stack)
        {
            switch (stack)
            {
                case 3:
                    _texturePath = _path + "3.png";
                    break;
                case 2:
                    _texturePath = _path + "2.png";
                    break;
                case 1:
                    _texturePath = _path + "1.png";
                    break;               
                default:
                    _texturePath = _path + "3.png";
                    break;
            }            
        }
        public void Draw()
        {
            Engine.Draw(_texturePath, transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, 0, 0, 0);
        }
    }
}
