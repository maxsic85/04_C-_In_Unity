using System;
using UnityEngine;


namespace MAX.CODE.MVC
{
    public sealed class Player : MonoBehaviour, IDamageble, IPlayer
    {
        public event Action<int> OnTriggerEnterChange;

        //Just MArker
        public void GetFamage()
        {
            throw new NotImplementedException();
        }
    }
}