using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct EnemyData
{
    public string _path { get; private set; }
    public int _baseSpeed { get; private set; }
    public int _baseAreaVisible { get; private set; }
    public int _baseDamage { get; private set; }

    public GameObject _prefab;



    public EnemyData(string path, int speed, int baseAreaVisible, int damage, GameObject prefab)
    {
        this._path = path;
        this._baseSpeed = speed;
        this._baseAreaVisible = baseAreaVisible;
        this._baseDamage = damage;
        _enemyInfos = new List<EnemyInfo>();
        _prefab = prefab;
    }

    public struct EnemyInfo
    {
     public EnemyProvider EnemyPrefab;
    }
    public List<EnemyInfo> _enemyInfos;
    public EnemyProvider GetEnemy()
    {
      
        var enemyInfo = _prefab;
        if (enemyInfo == null)
        {
        //    throw new InvalidOperationException($"Enemy type not found");
        }
        return enemyInfo.GetComponent<EnemyProvider>();
    }
}
