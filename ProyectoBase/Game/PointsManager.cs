using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class PointsManager
    {
        private Transform transformNumber1 = new Transform();
        private Transform transformNumber2 = new Transform();
        private string _path = "Textures/HUD/Numbers/";
        private string _texturePath1;
        private string _texturePath2;

        public PointsManager()
        {
            transformNumber1.Position = new Vector2(750, 10);
            transformNumber1.Size = new Vector2(12, 8);
            transformNumber1.Scale = new Vector2(2, 2);

            transformNumber2.Position = new Vector2(730, 10);
            transformNumber2.Size = new Vector2(12, 8);
            transformNumber2.Scale = new Vector2(2, 2);
            _texturePath1 = ChangeTexture(_texturePath1, "0");
            _texturePath2 = ChangeTexture(_texturePath2, "0");
        }

        public void CalculateTexture(int number)
        {
            string aux = number.ToString();
            if(aux.Length == 1)
            {
                _texturePath1 = ChangeTexture(_texturePath1, aux);
                _texturePath2 = ChangeTexture(_texturePath2, "0");
            }
            else
            {
                _texturePath1 = ChangeTexture(_texturePath1,aux.Substring(1, 1));
                _texturePath2 = ChangeTexture(_texturePath2, aux.Substring(0, 1));
            }
        }

        private string ChangeTexture(string path, string number)
        {           
            switch (number)
            {
                case "9":
                    path = _path + "9.png";
                    break;
                case "8":
                    path = _path + "8.png";
                    break;
                case "7":
                    path = _path + "7.png";
                    break;
                case "6":
                    path = _path + "6.png";
                    break;
                case "5":
                    path = _path + "5.png";
                    break;
                case "4":
                    path = _path + "4.png";
                    break;
                case "3":
                    path = _path + "3.png";
                    break;
                case "2":
                    path = _path + "2.png";
                    break;
                case "1":
                    path = _path + "1.png";
                    break;
                case "0":
                    path = _path + "0.png";
                    break;
                default:
                    path = _path + "0.png";
                    break;
            }
            return path;
        }
        public void Draw()
        {
            Engine.Draw(_texturePath1, transformNumber1.Position.X, transformNumber1.Position.Y, transformNumber1.Scale.X, transformNumber1.Scale.Y, 0, 0, 0);
            Engine.Draw(_texturePath2, transformNumber2.Position.X, transformNumber2.Position.Y, transformNumber2.Scale.X, transformNumber2.Scale.Y, 0, 0, 0);
        }
    }
}

