using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Generetion
{
    public class MapGenerator : MonoBehaviour
    {
        public GameObject Generator;
        // Start is called before the first frame update
        void Awake()
        {
            // IMapGeneretion map = new ShuffleMapGeneretion();
            //map.GeneretMap();
            Generator.GetComponent<IMapGeneretion>().GeneretMap();
           
        }

    }
}