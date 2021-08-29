using System;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Max.Meta
{
    public enum BoostType
    {
        ADDSPEED = 1,
        ADDHEALTH = 2
    }

    public class Boost : MonoBehaviour, IDropBoost
    {
        BoostType _boost = new BoostType();
        public event Action _boostEvent;

        void Start()
        {
            _boost = BoostType.ADDHEALTH;
        }

        public void GeneretionBoost()
        {
            throw new NotImplementedException();
        }
        public void UseBonus()
        {
            switch (_boost)
            {
                case BoostType.ADDSPEED:
                    Debug.Log("use addspeed");
                    break;
                case BoostType.ADDHEALTH:
                    Debug.Log("use addhealth");
                    break;
                default:
                    break;
            }

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Core.Player>() != null)
            {
                var addComponent = this;
                addComponent._boostEvent += () =>
                {
                    Debug.Log(other.gameObject);
                };
                var _de = FindObjectOfType<DisplayEvvents>();
                if (_de == null) throw new System.Data.DataException("DisplayEvvents not found");
                _de.Init(addComponent);

                _boostEvent?.Invoke();
            }
        }
        public void Dispose()
        {

        }
    }
}