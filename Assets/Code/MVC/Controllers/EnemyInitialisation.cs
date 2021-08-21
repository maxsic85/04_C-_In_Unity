using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Max.Core;
public sealed class EnemyInitialisation : IInitialisation
{
    private readonly IEnemyFactory _enemyFactory;
    private CompositeMove _enemy;
    private List<IEnemy> _enemies;

    public EnemyInitialisation(IEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
        _enemy = new CompositeMove();
        var currentEnemy = _enemyFactory.CreateEnemy();
        var currentEnemy2 = _enemyFactory.CreateEnemy();
        _enemy.AddUnit(currentEnemy);
        _enemy.AddUnit(currentEnemy2);
        _enemies = new List<IEnemy>()
        {
            currentEnemy

        };
    }

    public Imove GetMoveEnemies()
    {
        return _enemy;
    }

  public   IEnumerable<IEnemy> GetEnemies()
    {
        foreach (var item in _enemies)
        {
            yield return item;
        }
    }

    public void Initialization()
    {
       
    }
}
