using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IEnemy
    {

    }
    public static class EnemyFactory
    {
        public enum EnemyType { Red, Yellow, Blue }

        public static IEnemy CreateEnemy(EnemyType type)
        {

        }
    }
}
