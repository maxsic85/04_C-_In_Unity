using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace Max.Core
{

    public  sealed partial class Player : MonoBehaviour
    {
        public float _speed = 2f;
        public LayerMask _mask;

        Imove _move;
        private void Start()
        {      
            _move = new KeyController(gameObject.transform, _speed, _mask);
        }

        private void FixedUpdate()
        {
            _move.Move();
        }
    }

}
