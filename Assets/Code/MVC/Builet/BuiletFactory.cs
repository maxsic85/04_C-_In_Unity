using UnityEngine;
namespace MAX.CODE.MVC
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
            var builetProvider = _builetyData?.GetBuilet();
            var a = Object.Instantiate(builetProvider);
            a.transform.position = position.position;
            return a.gameObject;
        }
    }
}
