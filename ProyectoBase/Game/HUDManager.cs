using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HUDManager
    {
        private LifeBarManager _lifeBarManager;
        private LifeStackManager _lifeStackManager;
        private PointsManager _pointsManager;

        public HUDManager(Player player,GameManager gameManager)
        {
            _lifeBarManager = new LifeBarManager();
            _lifeStackManager = new LifeStackManager();
            _pointsManager = new PointsManager();

            player.OnLifeStackChange += new LifeStackChangeEventHandler(_lifeStackManager.ChangeTexture);
            player.OnHealthChange += new HealthChangeEventHandler(_lifeBarManager.ChangeTexture);
            gameManager.OnPointsChange += new PointsChangeEventHandler(_pointsManager.CalculateTexture);
        }

        public void Draw()
        {
            _lifeBarManager.Draw();
            _lifeStackManager.Draw();
            _pointsManager.Draw();
        }
    }
}
