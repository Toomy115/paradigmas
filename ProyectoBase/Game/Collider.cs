using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Collider
    {
        //private Vector2 _height = new Vector2();
        //private Vector2 _length = new Vector2();
        private Vector2 _size = new Vector2();
        private Vector2 _position = new Vector2();


        public Collider(Vector2 size, Vector2 position)
        {
            //_height = heigth;
            //_length = length;
            _size = size;
            _position = position;
        }

        public bool IsBoxColliding(Vector2 positionA, Vector2 sizeA, Vector2 positionB, Vector2 sizeB)
        {
            Vector2 distance = new Vector2(Math.Abs(positionA.X - positionB.X), Math.Abs(positionA.Y - positionB.Y));

            float sumHalfWidths = sizeA.X / 2 + sizeB.X / 2;
            float sumHalfHeigths = sizeA.Y / 2 + sizeB.Y / 2;


            return distance.X <= sumHalfWidths && distance.Y <= sumHalfHeigths;
        }

        public void UpdatePosition(Vector2 position)
        {
            _position = position;            
        }
    }
}
