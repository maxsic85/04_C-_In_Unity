using UnityEngine;

namespace Labirint.Generation
{
    public class MapGenerator : MonoBehaviour
    {
        public GameObject Generator;
        void Awake()
        {
            Generator.GetComponent<IMapGeneretion>().GeneretMap();
        }

    }
}