using UnityEngine;
namespace Max.Generetion
{
    public class EnemyGeneretion : MonoBehaviour,IEnemyGeneretion
    {
        ShuffleMapGeneretion _mp ;
        public void CreateEnemy()
        {
            Transform _tile = _mp.GetRandomOpenTile();
            GameObject _boost = (GameObject)Instantiate(Resources.Load("Boost"), _tile.position, Quaternion.identity);
        }

        private void Start()
        {
            _mp = FindObjectOfType<ShuffleMapGeneretion>();
            CreateEnemy();
        }
    }
}
