using UnityEngine;

public sealed class EnemyFactory : IEnemyFactory
{
    private readonly EnemyData _enemyData;

    public EnemyFactory(EnemyData enemyData)
    {
        _enemyData = enemyData;

    }

    public IEnemy CreateEnemy(Transform position)
    {
        var enemyProvider = _enemyData.GetEnemy();
        enemyProvider.transform.position = position.position;
        return Object.Instantiate(enemyProvider);
    }

}
