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
        PlayerData _data = new PlayerData("Prefabs/Core/Player", 1, 1, 1, LayerMask.GetMask("Wall"));
     
        var playerFactory = new PlayerFactory(_data, ShuffleMapGeneretion._mapStart + c_offset);
        var playerInitialization = new PlayerInitialisation(playerFactory);


        var _camera = Camera.main.transform;
        var _player = GameObject.FindObjectOfType<Player>().transform;
            _controllers.Add(new TestLogController());
        _controllers.Add(new CameraContrpller(_player,_camera));
    }
}
