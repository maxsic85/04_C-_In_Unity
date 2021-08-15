using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Max.Core
{

    public sealed partial class Player : MonoBehaviour
    {
        testEvents _te;


        private void Start()
        {
            _te = FindObjectOfType<testEvents>();
            _te.TestEvent += UseBonus;
        }
        private void UseBonus()
        {
            Debug.Log("w");
            _te.Tester();
        }
        public void Dispose()
        {
            _te.TestEvent -= UseBonus;
        }

        // Update is called once per frame
        void Update()
        {
          
        }
    }
}