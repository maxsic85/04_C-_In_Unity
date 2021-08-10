using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Max.Generetion
{
    public class MapGeneretion : MonoBehaviour
    {
        public Transform _tilePrefab;
        public Vector2 _mapSize;
        public Transform _obstaclePreefab;
        [Range(0, 1)]
        public float _outLine = 0;
        [Range(0, 1)]
        public float _obstaclePercent = 0;
        List<Coord> _allTileCoords;
        Queue<Coord> _shuffledCoords;
        public int _seed = 10;
        private int _obstacleCount;
        Coord _mapCenter;
        // Start is called before the first frame update
        void Start()
        {
            GeneretMap();
        }

        // Update is called once per frame
        void Update()
        {

        }

        [System.Obsolete]
        public void GeneretMap()
        {
            _allTileCoords = new List<Coord>();
            for (int x = 0; x < _mapSize.x; x++)
            {
                for (int y = 0; y < _mapSize.y; y++)
                {
                    _allTileCoords.Add(new Coord(x, y));
                }
            }
            //SHUFFLE
            _shuffledCoords = new Queue<Coord>(ShuffleArray.ShuffleArr(_allTileCoords.ToArray(), _seed));
            //MAP CENTER
            _mapCenter = new Coord((int)_mapSize.x / 2, (int)_mapSize.y / 2);

            string _holderName = "Map";
            if (transform.FindChild(_holderName)) DestroyImmediate(transform.FindChild(_holderName).gameObject);

            Transform _mapHolder = new GameObject(_holderName).transform;
            _mapHolder.parent = transform;

            for (int x = 0; x < _mapSize.x; x++)
            {
                for (int y = 0; y < _mapSize.y; y++)
                {
                    Vector3 tilePosition = CoordToPosition(x, y);
                    Transform _newTile = Instantiate(_tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                    _newTile.localScale = Vector3.one * (1 - _outLine);
                    _newTile.parent = _mapHolder;
                }


            }

            // Create Obstacle
            bool[,] _obstacleMap = new bool[(int)_mapSize.x, (int)_mapSize.y];
            int obstacleCount = (int)(_mapSize.x * _mapSize.y * _obstaclePercent);
            int _currentObstacleCount = 0;
            for (int i = 0; i < _obstacleCount; i++)
            {
                Coord _randomCoord = GetRandomCoord();
                _obstacleMap[_randomCoord.x, _randomCoord.y] = true;
                _currentObstacleCount++;
                if (_randomCoord != _mapCenter && MapIsFullAccesible(_obstacleMap,_currentObstacleCount))
                {
                    Vector3 _obtaclePosition = CoordToPosition(_randomCoord.x, _randomCoord.y);
                    //

                    Transform _newObstacle = Instantiate(_obstaclePreefab, _obtaclePosition + Vector3.up * 0.5f, Quaternion.identity) as Transform;
                    _newObstacle.parent = _mapHolder;
                }
                else
                {
                    _obstacleMap[_randomCoord.x, _randomCoord.y] = false;
                    _currentObstacleCount--;
                }
            }
        }

        //
        bool MapIsFullAccesible(bool[,] obstacleMap, int _currentObstacleCnt)
        {

            return false;
        }
        Vector3 CoordToPosition(int x, int y)
        {
            return new Vector3(-_mapSize.x / 2 + 0.5f + x, 0, _mapSize.y / 2 + 0.5f + y);
        }

        public Coord GetRandomCoord()
        {
            Coord _randomCoord = _shuffledCoords.Dequeue();
            _shuffledCoords.Enqueue(_randomCoord);
            return _randomCoord;

        }
    }

    public struct Coord
    {
        public int x, y;

        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
