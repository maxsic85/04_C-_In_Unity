using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using Labirint.Core;
/// <summary>
/// 
/// </summary>
public  class EnemyProvider : GizmosObjects, IEnemy, IDisposable
{
    private NavMeshAgent _agent;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;
   
    private void Start()
    {  
        _agent = GetComponent<NavMeshAgent>();
      
    }
    public void Move(Vector3 point)
    {
        if (this == null) return;
          this.transform.LookAt(point);
        _agent.speed = _speed;
        _agent.SetDestination(point);  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("TARAN");
        }
    }

    public void Dispose()
    {
     
        Destroy(this);
    }

    ~EnemyProvider()
    {
  
        Destroy(this);
    }

    public void OnDestroy()
    {

        Destroy(this);
    }
}

