using System.Collections.Generic;
using UnityEngine;


namespace MAX.CODE.MVC
{
    public class PathToBot : MonoBehaviour
    {
        [SerializeField]
        private Color _lineColor = Color.red;
        Transform _palyer;
        List<Transform> _enemyProviders = new List<Transform>();
        private void Start()
        {
            _palyer = gameObject.transform;
            var enemyProviders = FindObjectsOfType<EnemyProvider>();
            foreach (var item in enemyProviders)
            {
                var tr = item.TryGetComponent<Transform>(out Transform current);
                _enemyProviders.Add(current);
            }
        }
        private void OnDrawGizmos()
        {
            for (var i = 0; i < _enemyProviders.Count; i++)
            {
                Gizmos.color = _lineColor;

              if(_enemyProviders[i]!=null) Gizmos.DrawLine(_palyer.position,_enemyProviders[i].position);

            }
        }
    }
}
