using System.Collections.Generic;
using UnityEngine;
using Max.Core;
using System;
using UnityEngine.AI;
/// <summary>
/// 
/// </summary>
public  class EnemyProvider : MonoBehaviour, IEnemy
{
    public event Action<int> OnTriggerEnterChange;
    private Rigidbody _rigidbody2D;
    private NavMeshAgent _agent;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
    }
    public void Move(Vector3 point)
    {
        //if ((transform.localPosition - point).sqrMagnitude >= _stopDistance * _stopDistance)
        //{
        //    var dir = (point - transform.localPosition).normalized;
        //    _rigidbody2D.velocity = dir * _speed;
        //}
        //else
        //{
        //    _rigidbody2D.velocity = Vector2.zero;
        //}
        transform.LookAt(point);
        _agent.speed = _speed;
        _agent.SetDestination(point);
      
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
    
    }
}

