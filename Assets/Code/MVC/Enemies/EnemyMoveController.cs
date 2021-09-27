using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Max.Core;
public class EnemyMoveController : IExecute
{
    private readonly Imove _move;
    private readonly Transform _target;

    public EnemyMoveController(Imove move, Transform target)
    {
        _move = move;
        _target = target;
    }

    public void Execute(float deltaTime)
    {
        _move?.Move(_target.localPosition);
      
    }

  
}
