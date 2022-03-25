using Labirint.Core;
using Max.Meta;
using System;
using UnityEngine;

namespace Labirint.Boost
{
    public enum BoostType
    {
        ADDSPEED = 1,
        ADDHEALTH = 2,
        ADDPOWER = 3
    }

    public sealed class BoostBeh : MonoBehaviour
    {

        [SerializeField] private BoostType _boost = new BoostType();
        public event Action _boostEvent;

        void Start()
        {
            var random = new System.Random();
            _boost = (BoostType)random.Next(1, 3);
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
                case BoostType.ADDPOWER:
                    Debug.Log("use power");
                    break;
                default:
                    break;
            }

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerProvider>() != null)
            {
                var dispalyEvent = FindObjectOfType<DisplayEvvents>();
                if (dispalyEvent == null) throw new System.Data.DataException("DisplayEvvents not found");
                dispalyEvent.Init(transform.gameObject.GetComponent<BoostBeh>());
                _boostEvent?.Invoke();
            }
        }
    }
}