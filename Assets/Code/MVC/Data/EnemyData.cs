using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData 
{
    public string _path { get; private set; }
    public int _baseSpeed { get; private set; }
    public int _baseAreaVisible { get; private set; }
    public int _baseDamage { get; private set; }

    public EnemyData(string path, int speed, int baseAreaVisible, int damage)
    {
        this._path = path;
        this._baseSpeed = speed;
        this._baseAreaVisible = baseAreaVisible;
        this._baseDamage = damage;
    }
}
