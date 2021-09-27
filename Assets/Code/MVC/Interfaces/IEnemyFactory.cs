using UnityEngine;
public interface IEnemyFactory 
{
    IEnemy CreateEnemy(Transform transform);
}
