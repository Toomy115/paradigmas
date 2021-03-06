using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Actor
    {
        //protected Vector2 _position;
        protected Vector2 _initialPosition;
        //protected Vector2 _size;
        //protected Vector2 _scale;
        protected Transform _transform = new Transform();
        protected Vector2 _shootPoint = new Vector2();
        protected float _speed;
        public List<Bullet> bullets = new List<Bullet>();
        protected Collider _collider;

        public abstract void Draw();


        public abstract void Update();               

        public abstract void Kill();
        
    }
}
