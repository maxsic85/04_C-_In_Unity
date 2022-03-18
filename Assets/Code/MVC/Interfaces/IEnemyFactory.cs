using UnityEngine;

namespace Labirint.Core
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(Transform transform);
    }
}