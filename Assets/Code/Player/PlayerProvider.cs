using System;
using UnityEngine;

namespace Labirint.Core
{
    public sealed class PlayerProvider : MonoBehaviour, IDamageble, IPlayer
    {
        public event Action<int> OnTriggerEnterChange;
        public void GetFamage()
        {
          
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other is IEnemy enemy)
            {

            }
        }
    }
}