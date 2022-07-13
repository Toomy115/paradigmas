using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PowerUpManager
    {
        private Player _player;
        private int drop;
        private Transform _enemyTransform;
        private List<PowerUp> _listPowerUp = new List<PowerUp>();
        public PowerUpManager(Player player)
        {
            _player = player;
        }

        public void Update()
        {
            for (int i = 0; i < _listPowerUp.Count ; i++)
            {
                _listPowerUp[i].Update();
                if(!_listPowerUp[i].IsEnabled)
                    _listPowerUp.RemoveAt(i);
            }
        }

        public void Draw()
        {
            foreach (var powerUp in _listPowerUp)
            {
                powerUp.Draw();
            }
        }
        public void CalculateDrop(Transform transform)
        {
            _enemyTransform = transform;
            Random random = new Random();
            drop = random.Next(1, 20);           
            Console.WriteLine("Drop: " + drop);
            DropItem();
        }
        private void DropItem()
        {
            if (drop >= 13 && drop <= 16)
            {
                Console.WriteLine("+Velocidad");
                PowerUpSpeed powerUp = new PowerUpSpeed(_enemyTransform, _player);
                _listPowerUp.Add(powerUp);
                //Velocidad+
            }
            else
            {
                if (drop >= 17 && drop <= 19)
                {
                    Console.WriteLine("+Salud");
                    PowerUpHealth powerUp = new PowerUpHealth(_enemyTransform, _player);
                    _listPowerUp.Add(powerUp);
                    //Salud+
                }           
                else if(drop == 20)
                {
                    Console.WriteLine("+Vidas");
                    PowerUpLife powerUp = new PowerUpLife(_enemyTransform, _player);
                    _listPowerUp.Add(powerUp);
                    //Stock+
                }
            }
        }
    }
}
