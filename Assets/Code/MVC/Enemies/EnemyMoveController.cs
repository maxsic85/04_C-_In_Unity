using UnityEngine;
using Labirint.Core;

public class EnemyMoveController : IExecute
{
    private readonly Imoveble _movebleObjects;
    private readonly Transform _targetPosition;

    public EnemyMoveController(Imoveble move, Transform target)
    {
        _movebleObjects = move;
        _targetPosition = target;
    }

    public void Execute(float deltaTime)
    {
        _movebleObjects?.Move(_targetPosition.localPosition);
      
    }
 
}
