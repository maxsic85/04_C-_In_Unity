using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Max.Core;
using Max.Generetion;
using System;
public sealed class EnemyInitialisation : IInitialisation
{
    private readonly IEnemyFactory _enemyFactory;
    private CompositeMove _enemy;
    private List<IEnemy> _enemies;
    ShuffleMapGeneretion _levelGenerator;

    public List<IEnemy> Enemies { get => _enemies; set => _enemies = value; }

    public EnemyInitialisation(IEnemyFactory enemyFactory)
    {      
        _enemyFactory = enemyFactory;
        _enemy = new CompositeMove();
    
        _levelGenerator = GameObject.FindObjectOfType<ShuffleMapGeneretion>();
        var currentEnemy = _enemyFactory.CreateEnemy(_levelGenerator.GetRandomOpenTile());
        var currentEnemy2 = _enemyFactory.CreateEnemy(_levelGenerator.GetRandomOpenTile());
        _enemy.AddUnit(currentEnemy);
        _enemy.AddUnit(currentEnemy2);
        _enemies = new List<IEnemy>();
        //{
        //    currentEnemy,
        //    currentEnemy2

        //};

    }

    public Imove GetMoveEnemies()
    {
        return _enemy;
    }

    public IEnumerable<IEnemy> GetEnemies()
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
