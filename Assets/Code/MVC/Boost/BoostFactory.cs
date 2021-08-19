using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostFactory : IBoostFactory
{
    private readonly BoostData _boostData;
    Transform[] _position;
    GameObject[] _go;
    public BoostFactory(BoostData boostData, Transform[] position)
    {
        _boostData = boostData;
        _position = position;
        _go = new GameObject[_position.Length];
    }

    public GameObject[] CreateBoost()
    {     
        for (int i = 0; i < _position.Length; i++)
        {
            _go[i] = (GameObject)GameObject.Instantiate(Resources.Load(_boostData._path), _position[i].position, Quaternion.identity);
          //  _go[i].SetActive(false);
        }
        return _go;
    }
}
