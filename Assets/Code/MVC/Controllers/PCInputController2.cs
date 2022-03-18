using Labirint.Save;
using System;
using UnityEngine;

namespace Labirint.Core
{
    public sealed class PCInputController2 : IPCKeybordInput,IExecute
    {
   
        InputData _inputData;
        public ISavePlayerPosition _saveDataPosition;
        public event Action<float> OnStepNoizeChange;
        private readonly IBuiletFactory _builetFactory;
        private const float _MaxDistance = 0.5f;
        Transform _tr;
        float _speed;
        private Vector3 _moveVector;
        LayerMask _mask;
        RaycastHit _hit;
        RaycastHit _hitDown;



        public PCInputController2(Transform tr, float speed, LayerMask mask, InputData data, ISavePlayerPosition save)
        {
            _saveDataPosition = save;
            _tr = tr;
            _speed = speed;
            _mask = mask;
            _inputData = data;
        }


        public float GetAxisHorizontal()
        {
            return Input.GetAxis("Horizontal");
        }

        public float GetAxisVertical()
        {
           return -Input.GetAxis("Vertical");
        }

        public bool GetAxisFire()
        {
            return Input.GetKeyUp(KeyCode.Space);
        }



        public void GetAxis()
        {
            _moveVector.z = GetAxisHorizontal();
            _moveVector.x = GetAxisVertical();

            GetSaveHandler();
        }

        private void GetSaveHandler()
        {
            if (Input.GetKeyDown(_inputData.SavePlayer))
            {
                _saveDataPosition.SavePlayerPosition(_tr.position);
            }
            if (Input.GetKeyDown(_inputData.LoadPlayer))
            {
                _saveDataPosition.LoadPlayerPosition(_tr.position);
            }
        }

        private float Moves()
        {
            if (_moveVector.x != 0 || _moveVector.z != 0)
                return 1f;
            else
                return 0f;
        }
        private float Angle360(Vector3 from, Vector3 to, Vector3 right)
        {
            float angle = Vector3.Angle(from, to);
            return Vector3.Angle(right, to) > 90f ? 360f - angle : angle;
        }
        private bool CheckWall()
        {
            //Debug.DrawRay(_tr.position, _tr.forward, Color.red, 0.5f);
            Physics.Raycast(_tr.position, _tr.forward, out _hit, _MaxDistance, _mask);
            return _hit.collider != null ? true : false;
        }

        public void Move(Vector3 _transform)
        {
            GetAxis();
            _transform = _moveVector;
            _tr.Rotate(Vector3.up, Angle360(_tr.forward, _moveVector, _tr.right));

            if (!CheckWall())
            {
                _tr.Translate(
               Moves() * _tr.forward * _speed * Time.deltaTime,
               Space.World
           );
            }

        }
        public void Fire(BuiletData data, BuiletFactory fabrik)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("Fire");

                var currentBuilet = fabrik.CreateBuilet(_tr);
                currentBuilet.GetComponent<Rigidbody>().AddForce(_tr.transform.forward * data._baseSpeed);

            }
        }

        public void GetFire()
        {
            throw new NotImplementedException();
        }

        public void Execute(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public bool GetSave()
        {
            throw new NotImplementedException();
        }

        public bool GetLoad()
        {
            throw new NotImplementedException();
        }
    }
}