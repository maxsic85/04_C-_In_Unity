using System.Data;
using UnityEngine;
namespace Max.Core
{

    public sealed partial class Player : MonoBehaviour
    {
        Max.Meta.Boost _dropBoost;
        private void Start()
        {
            _dropBoost = FindObjectOfType<Max.Meta.Boost>();
            if (_dropBoost == null) throw new DataException("_dropBoost not found");
            _dropBoost._boostEvent += UseBonus;
        }
        private void UseBonus()
        {
            _dropBoost.UseBonus();
        }
        public void Dispose()
        {
            _dropBoost._boostEvent -= UseBonus;
        }
    }
}