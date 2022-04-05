using UnityEngine;
using System;
using UnityEngine.AI;
using Labirint.Data;

namespace Labirint.Core
{
    public class EnemyProvider : GizmosObjects, IEnemy, IDisposable
    {
        private NavMeshAgent _agent;
        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;
        [SerializeField] public EnemyData Data;

        private void Start()
        {        
            _agent = GetComponent<NavMeshAgent>();
        }
        public void Move(Vector3 point)
        {
            if (this == null) return;
            transform.LookAt(point);
            _agent.speed = _speed;
            _agent.SetDestination(point);
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

        public void AddUnit(Imoveble unit)
        {

        }

        public void RemoveUnit(Imoveble unit)
        {

        }
    }
}