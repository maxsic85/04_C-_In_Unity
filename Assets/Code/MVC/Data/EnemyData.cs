using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyData
{
    public string _path { get; private set; } = "Prefabs/Core/Enemy";
    public int _baseSpeed { get; private set; } = 1;
    public int _baseAreaVisible { get; private set; } = 1;
    public int _baseDamage { get; private set; } = 1;

    public GameObject _prefab;

    public EnemyData()
    {
        _enemyInfos = new List<EnemyInfo>();
        _prefab = (GameObject)Resources.Load("Prefabs/Core/Enemy");
    }

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
