using System;
using UnityEngine;

namespace Labirint.Core
{
    public sealed class Player : MonoBehaviour, IDamageble, IPlayer
    {
        public event Action<int> OnTriggerEnterChange;
        public void GetFamage()
        {
            throw new NotImplementedException();
        }
    }
}