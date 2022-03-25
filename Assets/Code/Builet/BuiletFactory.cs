using UnityEngine;

namespace Labirint.Bullet
{
    public sealed class BuiletFactory : IBuiletFactory
    {
        private readonly BuiletData _builetyData;

        public BuiletFactory(BuiletData builetyData)
        {
            _builetyData = builetyData;

        }
        public GameObject CreateBuilet(Transform position)
        {
            var builetProvider = _builetyData.GetBuilet();
            var bullet = Object.Instantiate(builetProvider);
            bullet.transform.position = position.position;
            return bullet;
        }
    }
}