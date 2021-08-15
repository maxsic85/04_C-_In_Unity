using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace Max.Core
{
    public class Player : MonoBehaviour, IKeybordMove,IDamageble
    {
        //оповещаем ботов об уровне шума игрока
        public event Action<float> OnStepNoizeChange;

        public void GetDamage()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void OnMouseDown(MouseDownEvent evt)
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
