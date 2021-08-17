using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitialisation : IInitialisation
{
    private readonly IEnemyFactory _enemyFactory;

    public EnemyInitialisation(IEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
        _enemyFactory.CreateEnemy();
    }

    public void Initialization()
    {
        throw new System.NotImplementedException();
    }
}
