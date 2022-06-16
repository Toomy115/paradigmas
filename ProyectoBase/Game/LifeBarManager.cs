using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LifeBarManager
    {
        private Transform transform = new Transform();
        private string _path = "Textures/HUD/Life Bar/";
        private string _texturePath;
        private Texture texture;

        public LifeBarManager()
        {
            //player.OnHealthChange += new HealthChangeEventHandler(ChangeTexture);
            transform.Position = new Vector2(10, 10);
            transform.Size = new Vector2(261, 25);
            transform.Scale = new Vector2(1, 1);
            ChangeTexture(100);
        }
        public void ChangeTexture(float cantLife)
        {
            switch(cantLife)
            {
                case 100:
                    _texturePath = _path + "Barra Llena.png";
                    break;
                case 80:
                    _texturePath = _path + "Barra 80.png";
                    break;
                case 60:
                    _texturePath = _path + "Barra 60.png";
                    break;
                case 40:
                    _texturePath = _path + "Barra 40.png";
                    break;
                case 20:
                    _texturePath = _path + "Barra 20.png";
                    break;
                    default:
                    _texturePath = _path + "Barra Llena.png";
                    break;
            }
            //texture =  Engine.GetTexture(_texturePath);
        }

        public void Draw()
        {
            Engine.Draw(_texturePath, transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, 0, 0, 0);
        }

    }
}
