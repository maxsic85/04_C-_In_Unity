using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BuiletData
{
    public string _path { get; private set; } = "Prefabs/Core/Builet";
    public int _baseSpeed { get; } = 2;
    public int _baseNoise { get; } = 2;
    public int _baseDamage { get; } = 2;

    public GameObject _prefab;

    public BuiletData()
    {
        _prefab = (GameObject)Resources.Load("Prefabs/Core/Builet");
    }
    public BuiletData(string path, int baseSpeed, int baseNoise, int baseDamage, GameObject prefab)
    {
        _path = path;
        _baseSpeed = baseSpeed;
        _baseNoise = baseNoise;
        _baseDamage = baseDamage;
        _prefab = prefab;
    }

    public GameObject GetBuilet()
    {
        var enemyInfo = _prefab;
        if (enemyInfo == null)
        {
               throw new InvalidOperationException($"Enemy type not found");
        }
        return enemyInfo;
    }

}

