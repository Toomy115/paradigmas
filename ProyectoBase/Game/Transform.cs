using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Transform
    {
        private Vector2 position = new Vector2();
        private Vector2 rotation = new Vector2();
        private Vector2 scale = new Vector2();
        private Vector2 size = new Vector2();

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }
    }
}
