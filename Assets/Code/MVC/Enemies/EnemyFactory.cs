using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyFactory : IEnemyFactory
{
    private readonly EnemyData _enemyData;
    Vector3 _position;

    public EnemyFactory(EnemyData enemyData, Vector3 position)
    {
        _enemyData = enemyData;
        _position = position;
    }

    public GameObject CreateEnemy()
    {
        var a = GameObject.Instantiate(Resources.Load(_enemyData._path), _position, Quaternion.identity);
        return a as GameObject;
    }
}
