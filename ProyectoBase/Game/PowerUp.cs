using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class PowerUp
    {
        protected Transform _transform = new Transform();
        protected string _generalPath = "Textures/Objects/Power_Up_";       
        protected Collider _collider;
        private float _speed = 250f;
        private float _timeToDestroy = 200;
        protected Player _player;
        protected bool isEnabled = true;

        public PowerUp(Transform transform, Player player)
        {
            _transform = transform;
            _transform.Size = new Vector2(17, 39);
            _player = player;
            _collider = new Collider(_transform.Size, _transform.Position);
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        public virtual void Update()
        {
            _transform.Position.X -= _speed * Program.GetDeltaTime;
            _collider.UpdatePosition(_transform.Position);
        }
        
        public void Draw()
        {
            Engine.Draw(_generalPath,_transform.Position.X, _transform.Position.Y, 1.5f, 1.5f);
        }

        public void Destroy()
        {
            IsEnabled = false;
            _collider.Activated = false;
        }
    }
}
