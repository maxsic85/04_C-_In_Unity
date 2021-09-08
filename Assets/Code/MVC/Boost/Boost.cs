using System;
using UnityEngine;
using Random = UnityEngine.Random;
namespace MAX.CODE.MVC
{
    public enum BoostTypeBonus
            {
        ADDSPEED = 1,
        ADDHEALTH = 2,
        ADDPOWER = 3
    }

    public sealed class Boost : MonoBehaviour
    {
        [SerializeField]
        BoostTypeBonus _boost = new BoostTypeBonus();

        public BoostTypeBonus BoostType { get => _boost; set => _boost = value; }

        public event Action _boostEvent;

        void Start()
        {
            BoostType = (BoostTypeBonus)Random.RandomRange(1, 3);
        }

        public void GeneretionBoost()
        {
            throw new NotImplementedException();
        }
  
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                var _de = FindObjectOfType<DisplayEvvents>();
                if (_de == null) throw new System.Data.DataException("DisplayEvvents not found");
                _de.Init(transform.gameObject.GetComponent<Boost>());

                this._boostEvent?.Invoke();
             
                Destroy(this.gameObject);
            }
        }
        public void Dispose()
        {
            
          
            Dispose();
        }
    }
}