using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Перемещение без физики
/// Для не прохождения через стены пускаем луч
/// </summary>
namespace Max.Core
{
    public sealed class KeyController : IKeybordMove
    {
        public event Action<float> OnStepNoizeChange;
        private readonly IBuiletFactory _builetFactory;
        public void OnMouseDown(MouseDownEvent evt)
        {
            //Fire();
        }

        private const float _MaxDistance = 0.5f;
        Transform _tr;
        float _speed;
        private Vector3 _moveVector;
        LayerMask _mask;
        RaycastHit _hit;
        RaycastHit _hitDown;
        public KeyController(Transform tr, float speed, LayerMask mask)
        {
            this._tr = tr;
            this._speed = speed;
            this._mask = mask;
        }

        public void GetInput()
        {
            _moveVector.z = Input.GetAxis("Horizontal");
            _moveVector.x = -Input.GetAxis("Vertical");
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
            return (Vector3.Angle(right, to) > 90f) ? 360f - angle : angle;
        }
        private bool CheckWall()
        {
            //Debug.DrawRay(_tr.position, _tr.forward, Color.red, 0.5f);
            Physics.Raycast(_tr.position, _tr.forward, out _hit, _MaxDistance, _mask);
            return (_hit.collider != null) ? true : false;
        }

        public void Move(Vector3 _transform)
        {
            GetInput();
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
                // currentBuilet.GetComponent<Rigidbody>().AddForce(_tr.transform.forward * data._baseSpeed);

                // GameObject outBuilett = GameObject.Instantiate((GameObject)Resources.Load(data._path), _tr.position, Quaternion.identity);
                // outBuilett.GetComponent<Rigidbody>().AddForce(_tr.transform.forward * data._baseSpeed);

            }
        }
    }
}