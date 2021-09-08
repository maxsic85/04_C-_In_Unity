using System.Collections.Generic;
using UnityEngine;
namespace MAX.CODE.MVC
{
    public class EnemyData
    {
        public string _path { get; private set; } = "Prefabs/Core/Enemy";
        public int _baseSpeed { get; private set; } = 1;
        public int _baseAreaVisible { get; private set; } = 1;
        public int _baseDamage { get; private set; } = 1;
        public int _baseHp { get; private set; } = 100;
        public int _MaxHp { get; private set; } = 1000;
        public int _baseStamina { get; private set; } = 20;

        public GameObject _prefab;

        public EnemyData()
        {
            _enemyInfos = new List<EnemyInfo>();
            _prefab = (GameObject)Resources.Load("Prefabs/Core/Enemy");
        }

        public EnemyData(string path, int speed, int baseAreaVisible, int damage,int hp,int maxHp, GameObject prefab)
        {
            this._path = path;
            this._baseSpeed = speed;
            this._baseAreaVisible = baseAreaVisible;
            this._baseDamage = damage;
            this._baseHp = hp;
            this._MaxHp = maxHp;
            _enemyInfos = new List<EnemyInfo>();
            _prefab = prefab;
        }

      
        public struct EnemyInfo
        {
            public EnemyProvider EnemyPrefab;
        }
        public List<EnemyInfo> _enemyInfos;
        public EnemyProvider GetEnemy()
        {

            var enemyInfo = _prefab;
            
            if (enemyInfo == null)
            {
                //    throw new InvalidOperationException($"Enemy type not found");
            }
            var ep = enemyInfo.GetComponent<EnemyProvider>();
            ep.CurrentHp = _baseHp;
            ep.MaxHp = _MaxHp;
            ep.Stamina = _baseStamina;
            return ep;
        }
    }
}