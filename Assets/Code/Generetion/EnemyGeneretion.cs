using UnityEngine;
namespace Max.Generetion
{
    public class EnemyGeneretion : MonoBehaviour,IEnemyGeneretion
    {
        ShuffleMapGeneretion _mp ;
        public void CreateEnemy()
        {
            Transform _tile = _mp.GetRandomOpenTile();
            Transform _tile2 = _mp.GetRandomOpenTile();
            GameObject _Player = (GameObject)Instantiate(Resources.Load("Prefabs/Core/Player"),_mp._mapStart+Vector3.up/8, Quaternion.identity);
            GameObject _enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Core/Enemy"), _tile.position, Quaternion.identity);
            GameObject _boost = (GameObject)Instantiate(Resources.Load("Prefabs/Meta/Boost"), _tile2.position, Quaternion.identity);
        }

        private void Start()
        {
            _mp = FindObjectOfType<ShuffleMapGeneretion>();
            CreateEnemy();
        }
    }
}
