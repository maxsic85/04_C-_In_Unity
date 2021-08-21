using System.Collections.Generic;
using UnityEngine;
using Max.Core;
using System;
/// <summary>
/// 
/// </summary>
public  class EnemyProvider : MonoBehaviour, IEnemy
{
    public event Action<int> OnTriggerEnterChange;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector3 point)
    {
        if ((transform.localPosition - point).sqrMagnitude >= _stopDistance * _stopDistance)
        {
            var dir = (point - transform.localPosition).normalized;
            _rigidbody2D.velocity = dir * _speed;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
    
    }
}

