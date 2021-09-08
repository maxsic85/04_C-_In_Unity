using System;
using UnityEngine;
using UnityEngine.AI;
using static OtherExtenshions;
/// <summary>
/// 
/// </summary>
/// 

namespace MAX.CODE.MVC
{
    public class EnemyProvider : GizmosObjects, IEnemy, IDisposable
    {
        private NavMeshAgent _agent;
        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;
        [SerializeField] private int _currentHp;
        [SerializeField] private int _maxHp;
        [SerializeField] private int _stamina;


        public int CurrentHp { get => _currentHp; set => _currentHp = value; }
        public int MaxHp { get => _maxHp; set => _maxHp = value; }
        public int Stamina { get => _stamina; set => _stamina = value; }

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();

        }

        public (int Hp, int Stamina) GetDamage(int damage)
        {
            (int Hp, int Stamina) result = (_currentHp, _stamina);
            damage = damage / _stamina;
            _currentHp -= damage;
            return result;
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

          
        }

        ~EnemyProvider()
        {
           
        }

        public void OnDestroy()
        {
          
        }
    }

}