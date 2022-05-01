using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SpawnController
    {
        
        private float _posX;
        private float _posY;
        private int _numSpawn;
        private bool inUse;

        public bool InUse
        {
            set { inUse = value; }
            get { return inUse; }
        }
        public float GetPosX
        {
            get { return _posX; }
        }

        public float GetPosY
        {
            get { return _posY; }
        }

        public int GetNumSpawn
        {
            get { return _numSpawn; }
        }
        public SpawnController(float posX, float posY, int num)
        {
            _posX = posX;
            _posY = posY;
            _numSpawn = num;
            inUse = false;
        }
    }
}
