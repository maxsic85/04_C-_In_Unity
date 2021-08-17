using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerFactory : IPlayerFactory
{
    private readonly PlayerData _playerData;
    Vector3 _position;
    public PlayerFactory(PlayerData playerData, Vector3 position)
    {
        _playerData = playerData;
        _position = position;
    }

    public GameObject CreatePlayer()
    {
        //return new GameObject (_playerData.Name).
        //    AddSprite(_playerData.Sprite).AddCircleCollider2D().
        //    AddCircleCollider2D().AddTrailRenderer().transform;

      

        var a = GameObject.Instantiate(Resources.Load(_playerData._path), _position, Quaternion.identity);
        return a as GameObject;
    }
}
