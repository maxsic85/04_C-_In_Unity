using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IExecute
{
    private float _speed = 2f;
    private LayerMask _mask;
    private Transform _player;
    private Max.Core.IKeybordMove _move;
    BuiletData _fireData = new BuiletData();
    BuiletFactory _fabrik;
    public PlayerController( Transform player,float speed, LayerMask mask)
    {
        _player = player;
        _speed = speed;
        _mask = mask;
        _move = new Max.Core.KeyController(player, _speed, _mask);
        _fabrik = new BuiletFactory(_fireData);
       
    }

    public void Execute(float deltaTime)
    {
        _move.Move(Vector3.one);
        _move.Fire(_fireData,_fabrik);
    }

}
