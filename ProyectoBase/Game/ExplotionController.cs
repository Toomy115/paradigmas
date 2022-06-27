using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ExplotionController
    {
        private Animador explotion;
        private string _texturePath = "Textures/Enemies/Explotion/";
        private Transform _transform;

        public ExplotionController()
        {
            _transform = new Transform();
            _transform.Scale = new Vector2(1,1);
            CreateAnimations();
        }

        public void Update()
        {
            explotion.Update();
            Draw();
        }

        public void Draw()
        {
            Engine.Draw(explotion.CurrentTexture, _transform.Position.X, _transform.Position.Y, _transform.Scale.X, _transform.Scale.Y, 0, 0, 0);
        }
        private void CreateAnimations()
        {
            var explotionTextures = new List<Texture>();
            for (int i = 1; i <= 8; i++)
            {
                var texture = Engine.GetTexture(_texturePath + $"Capa {i}.png");
                explotionTextures.Add(texture);
            }
            explotion = new Animador("explotion", 1f, explotionTextures, false);
        }
    }
}
