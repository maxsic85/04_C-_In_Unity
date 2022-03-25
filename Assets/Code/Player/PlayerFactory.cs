using Labirint.Data;
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

  public   IPlayer CreatePlayer()
    {
        //var a = GameObject.Instantiate(Resources.Load(_playerData._path), _position, Quaternion.identity);
        //return a as GameObject;
        var enemyProvider = _playerData.GetPlayer();
        enemyProvider.transform.position = _position;
        return Object.Instantiate(enemyProvider);
    }
}
