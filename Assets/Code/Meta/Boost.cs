using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Max.Meta
{
    public class Boost : MonoBehaviour,IDropBoost
    {
        public event Action<bool> OnDropBoost;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void UseBoost()
        {
            throw new NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}