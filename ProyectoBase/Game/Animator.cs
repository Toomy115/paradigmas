using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Animador
    {
        private bool isLoop;
        private string name;
        private float speed;
        private float currentTime;
        private int currentFrame = 0;
        private List<Texture> textures = new List<Texture>();
        public Texture CurrentTexture => textures[currentFrame];
        public Animador(string name, float speed, List<Texture> textures, bool isLoop = true)
        {
            this.name = name;
            this.speed = speed;
            this.isLoop = isLoop;
            this.currentFrame = 0;

            if (textures != null)
            {
                this.textures = textures;
            }
        }       

        public void Update()
        {
            currentTime += Program.GetDeltaTime;

            if (currentTime >= speed)
            {
                currentTime = 0f;
                currentFrame++;

                if(currentFrame >= textures.Count)
                {
                    currentFrame = 0;                  
                }

            }
        }
    }
}
