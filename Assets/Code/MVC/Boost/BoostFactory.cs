using Labirint.Data;
using UnityEngine;

namespace Labirint.Core
{
    public sealed class BoostFactory : IBoostFactory
    {
        private readonly BoostData _boostData;
        private Transform[] _boostPosition;
        private GameObject[] _boostGameobjectsOnSceene;
        public BoostFactory(BoostData boostData, Transform[] position)
        {
            _boostData = boostData;
            _boostPosition = position;
            _boostGameobjectsOnSceene = new GameObject[_boostPosition.Length];
        }

        public GameObject[] CreateBoost()
        {
            for (int i = 0; i < _boostPosition.Length; i++)
            {
                _boostGameobjectsOnSceene[i] = (GameObject)Object.Instantiate(Resources.Load(_boostData._path), _boostPosition[i].position, Quaternion.identity);
            }
            return _boostGameobjectsOnSceene;
        }
    }
}