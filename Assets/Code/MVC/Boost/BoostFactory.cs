using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostFactory : IBoostFactory
{
    private readonly BoostData _boostData;
    Vector3 _position;

    public BoostFactory(BoostData boostData, Vector3 position)
    {
        _boostData = boostData;
        _position = position;
    }

    public GameObject CreateBoost()
    {
        var a = GameObject.Instantiate(Resources.Load(_boostData._path), _position, Quaternion.identity);
        return a as GameObject;
    }
}
