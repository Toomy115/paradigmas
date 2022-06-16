using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyMovmentController
    {
        private int _enemyType;
        private Enemy _enemy;
        private Vector2 _initialPos = new Vector2();
        //private float _initialPosX;
        //private float _initialPosY;
        private float _maxRangeY = 100;
        private float _minRangeY = 500;
        private float _maxRangeX = 700;
        private float _minRangeX = 400;
        private int _direccion = 1;


        public EnemyMovmentController(int type, Enemy enemyReference)
        {
            _enemyType = type;
            _enemy = enemyReference;
            _initialPos.X = enemyReference.GetInitialPosition.X;
            _initialPos.Y = enemyReference.GetInitialPosition.Y;      
        }

        public void Update()
        {
            switch (_enemyType)
            {
                case 1:
                    BlueMovment();
                    break;
                case 2:
                    RedMovment();
                    break;
                case 3:
                    YellowMovment();
                    break;
                default:
                    BlueMovment();
                    break;
            }
        }

        private void BlueMovment()
        {            
            //IZQUIERDA Y DERECHA
            if(_enemy.ChangePosX >= _maxRangeX)
            {
                _direccion = -1;
            } else if (_enemy.ChangePosX <= _minRangeX)
            {
                _direccion = 1;
            }

            _enemy.ChangePosX = _direccion;
        }
        private void RedMovment()
        {
            
        }
        private void YellowMovment()
        {
            //SE MUEVE ARRIBA Y ABAJO 
            if (_enemy.ChangePosY <= _maxRangeY)
            {
                _direccion = 1;
            }
            else if (_enemy.ChangePosY >= _minRangeY)
            {
                _direccion = -1;
            }
            _enemy.ChangePosY = _direccion;
        }
    }
}
