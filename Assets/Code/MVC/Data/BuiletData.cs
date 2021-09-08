using System;
using UnityEngine;
namespace MAX.CODE.MVC
{
    public class BuiletData
    {
        public string _path { get; private set; } = "Prefabs/Core/Builet";
        public int _baseSpeed { get; } = 2;
        public int _baseNoise { get; } = 2;
        public int _baseDamage { get; } = 300;

        public GameObject _prefab;

        public BuiletData()
        {
            _prefab = (GameObject)Resources.Load("Prefabs/Core/Builet");
        }
        public BuiletData(string path, int baseSpeed, int baseNoise, int baseDamage, GameObject prefab)
        {
            _path = path;
            _baseSpeed = baseSpeed;
            _baseNoise = baseNoise;
            _baseDamage = baseDamage;
            _prefab = prefab;
        }

        public BuiletProvider GetBuilet()
        {
            var enemyInfo = _prefab;
            if (enemyInfo == null)
            {
                throw new InvalidOperationException($"Enemy type not found");
            }
            enemyInfo.GetComponent<BuiletProvider>().Damage = _baseDamage;
            return enemyInfo.GetComponent<BuiletProvider>();
        }

    }
}

