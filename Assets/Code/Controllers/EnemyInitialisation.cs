using System.Collections.Generic;
using UnityEngine;
using Labirint.Generation;

namespace Labirint.Core
{
    public sealed class EnemyInitialisation
    {
        private readonly IEnemyFactory _enemyFactory;
        private Imoveble _moveSystem;
        private List<IEnemy> _enemies;
        private readonly IMapGeneretion _levelGenerator;
        public List<IEnemy> Enemies => _enemies;

        public EnemyInitialisation(IEnemyFactory enemyFactory, int enemyCnt, Imoveble imoveble, IMapGeneretion levelGenerator)
        {
            _enemyFactory = enemyFactory;
            _moveSystem = imoveble;
            _levelGenerator =levelGenerator;
            _enemies = new List<IEnemy>();
            InitEnemy(enemyCnt);
        }

        private void InitEnemy(int enemyCnt)
        {
            for (int i = 0; i < enemyCnt; i++)
            {
                _enemies.Add(_enemyFactory.CreateEnemy(_levelGenerator.GetRandomOpenTile()));
                _moveSystem.AddUnit(_enemies[i]);
            }
        }

        public Imoveble GetMoveEnemies()
        {
            return _moveSystem;
        }

        public IEnumerable<IEnemy> GetEnemies()
        {
            foreach (var item in _enemies)
            {
                yield return item;
            }
        }
    }
}