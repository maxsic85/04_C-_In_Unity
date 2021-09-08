using UnityEngine;
namespace MAX.CODE.MVC
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(Transform transform);
    }
}