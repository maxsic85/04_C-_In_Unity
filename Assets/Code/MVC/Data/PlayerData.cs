using Max.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string _path { get; private set; } = "Prefabs/Core/Player";
    public int _baseSpeed { get;  } = 2;
    public int _baseNoise { get; } = 2;
    public int _baseDamage { get; } = 2;
    public LayerMask _mask { get;  } = LayerMask.GetMask("Wall");
    public GameObject _player;


    public PlayerData()
    {
        _player = (GameObject)Resources.Load(_path);
    }

    public PlayerData(string path, int speed, int noise, int damage, LayerMask mask)
    {
        this._path = path;
        this._baseSpeed = speed;
        this._baseNoise = noise;
        this._baseDamage = damage;
        this._mask = mask;
        _player = (GameObject)Resources.Load(_path);
    }


    public Player GetPlayer()
    {
     
        if (_player == null)
        {
            //    throw new InvalidOperationException($"Enemy type not found");
        }
        return _player.GetComponent<Player>();
    }
}
