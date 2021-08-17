using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public string _path { get; private set; }
    public int _baseSpeed { get; private set; }
    public int _baseNoise { get; private set; }
    public int _baseDamage { get; private set; }
    public LayerMask _mask { get; private set; }

    public PlayerData(string path, int speed, int noise, int damage, LayerMask mask)
    {
        this._path = path;
        this._baseSpeed = speed;
        this._baseNoise = noise;
        this._baseDamage = damage;
        this._mask = mask;
    }
}
