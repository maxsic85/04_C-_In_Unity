using UnityEngine;

namespace Labirint.Generation
{
    [System.Serializable]
    public class Map
    {
        public Coord _mapSize;
        [Range(0, 1)]
        public float _obtaclePercent;

        public int _seed;
        public float _minObtacleHeight;
        public float _maxObtacleHeight;

        public Coord _mapCenter
        {
            get => new Coord(_mapSize.x / 2, _mapSize.y / 2);
        }
        public Coord _mapStart
        {
            get => new Coord(0, 0);
        }

    }


}
