using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace Max.Core
{

    public sealed  class Player : MonoBehaviour, IDamageble,IPlayer
    {
        public event Action<int> OnTriggerEnterChange;

        //Just MArker
        public void GetFamage()
        {
            throw new NotImplementedException();
        }
    }
}