using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager
    {
        private static readonly GameManager instance = new GameManager();
        private float _enemiesToDestroy = 10;
        private float _enemiesNextLevel = 5;
        private int _enemiesDestroyed;
        private Player _player;
        public static GameManager Instance
        {
            get
            {
                return instance;
            }
        }
        public int EnemiesDestroyedUpgrade
        {
            set { _enemiesDestroyed += value; }
        }

        public int GetEnemiesDestroyed
        {
            get { return _enemiesDestroyed; }
        }

        public void SetPlayer(ref Player player)
        {
            _player = player;
        }
        public void Update()
        {
            if (_enemiesDestroyed == _enemiesToDestroy)
            {
                //VICTORY
                _enemiesToDestroy += _enemiesNextLevel;
                _enemiesDestroyed = 0;
                SceneManager.Instance.SetCurrentScene = 2;
                _player.RestoreNextLevel();
            }

        }
    }
}
