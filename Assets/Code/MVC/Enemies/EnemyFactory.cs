using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyFactory : IEnemyFactory
{
    private readonly EnemyData _enemyData;
    Transform[] _position;

    public EnemyFactory(EnemyData enemyData, Transform[] position)
    {
        _enemyData = enemyData;
        _position = position;
    }

    public GameObject[] CreateEnemy()
    {
        GameObject[] _go =new GameObject[_position.Length];
        for (int i = 0; i < _position.Length; i++)
        {
            _go[i] = (GameObject)GameObject.Instantiate(Resources.Load(_enemyData._path), _position[i].position, Quaternion.identity);
           
        }
        return _go;
    }
}
