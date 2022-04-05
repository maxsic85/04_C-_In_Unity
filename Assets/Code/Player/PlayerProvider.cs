using System;
using UnityEngine;

namespace Labirint.Core
{
    public sealed class PlayerProvider : MonoBehaviour, IDamageble, IPlayer
    {
        public event Action<int> OnTriggerEnterChange;

        private void Start()
        {
            OnTriggerEnterChange += GetDamage;
        }
        public void GetDamage(int damage)
        {
            Debug.Log($"Player Get Damage {damage}");
        }

        private void OnTriggerEnter(Collider other)
        {
          
            if (other.GetComponent<EnemyProvider>()!=null)
            {
                OnTriggerEnterChange.Invoke(10);
            }
        }
    }
}