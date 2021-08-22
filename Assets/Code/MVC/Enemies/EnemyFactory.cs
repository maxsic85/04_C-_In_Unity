using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Max.Core;
using Max.Generetion;

public sealed class EnemyFactory : IEnemyFactory
{
    private readonly EnemyData _enemyData;

    public EnemyFactory(EnemyData enemyData)
    {
        _enemyData = enemyData;
      
    }

    public IEnemy CreateEnemy(Transform position)
    {
        //GameObject[] _go =new GameObject[_position.Length];
        //for (int i = 0; i < _position.Length; i++)
        //{
        //    _go[i] = (GameObject)GameObject.Instantiate(Resources.Load(_enemyData._path), _position[i].position, Quaternion.identity);


        //}
        //return _go;
        var enemyProvider = _enemyData.GetEnemy();
        enemyProvider.transform.position = position.position;
        return Object.Instantiate(enemyProvider);
    }

    
}
