using System.Collections.Generic;
using UnityEngine;
using Labirint.Generation;

namespace Labirint.Core
{
    public sealed class EnemyInitialisation
    {
        private readonly IEnemyFactory _enemyFactory;
        private CompositeMove _enemy;
        private List<IEnemy> _enemies;
        IMapGeneretion _levelGenerator;

        public List<IEnemy> Enemies => _enemies;

        public EnemyInitialisation(IEnemyFactory enemyFactory, int enemyCnt)
        {
            _enemyFactory = enemyFactory;
            _enemy = new CompositeMove();

            _levelGenerator = Object.FindObjectOfType<ShuffleMapGeneretion>();
            _enemies = new List<IEnemy>();
            InitEnemy(enemyCnt);
        }

        private void InitEnemy(int enemyCnt)
        {
            for (int i = 0; i < enemyCnt; i++)
            {
                _enemies.Add(_enemyFactory.CreateEnemy(_levelGenerator.GetRandomOpenTile()));
                _enemy.AddUnit(_enemies[i]);
            }
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
    }
}