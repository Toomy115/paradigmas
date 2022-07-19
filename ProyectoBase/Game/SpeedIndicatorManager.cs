using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SpeedIndicatorManager
    {
        private Transform transform = new Transform();
        private string _path = "Textures/HUD/Speed Indicator/Speed_Level_";
        private string _texturePath;

        public SpeedIndicatorManager()
        {
            transform.Position = new Vector2(10, 540);
            transform.Size = new Vector2(14, 23);
            transform.Scale = new Vector2(2, 2);
            ChangeTexture(0);
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
                case 0:
                    _texturePath = _path + "0.png";
                    break;
                default:
                    _texturePath = _path + "0.png";
                    break;
            }
        }

        public void Draw()
        {
            Engine.Draw(_texturePath, transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, 0, 0, 0);
        }
    }
}
