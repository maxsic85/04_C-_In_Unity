using Max.Core;
using Max.Generetion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public sealed class GameInitialisation 
{
    Vector3 c_offset =new Vector3(0, 0.05f, 0);
    public GameInitialisation(Controllers _controllers)
    {
        PlayerData _dataPlayer = new PlayerData("Prefabs/Core/Player", 1, 1, 1, LayerMask.GetMask("Wall"));
        EnemyData _dataEnemy = new EnemyData("Prefabs/Core/Enemy", 1, 1, 1);
        BoostData _boostData = new BoostData("Prefabs/Meta/Boost", 1, BoostType.GOOD);


        var playerFactory = new PlayerFactory(_dataPlayer, ShuffleMapGeneretion._mapStart + c_offset);
        var playerInitialization = new PlayerInitialisation(playerFactory);

        var enemyFactory = new EnemyFactory(_dataEnemy, Vector3.zero);
        var enemyInitialization = new EnemyInitialisation(enemyFactory);

        var boostFactory = new BoostFactory(_boostData, Vector3.one);
        var boostInitialization = new BoostInitialisation(boostFactory);

        var _camera = Camera.main.transform;
        var _player = GameObject.FindObjectOfType<Player>().transform;

            _controllers.Add(new TestLogController());
        _controllers.Add(new CameraContrpller(_player,_camera));
    }
}
