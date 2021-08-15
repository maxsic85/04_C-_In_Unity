using System.Collections.Generic;
using UnityEngine;

namespace Max.Generetion
{
    public class ShuffleMapGeneretion : MonoBehaviour, IShuffleGeneretion
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
        List<GameObject> _map;
        public int _seed = 10;
        
        Coord _mapCenter;
        public bool _genereteInInspector;
        // Start is called before the first frame update

        void Start()
        {
          //  GeneretMap();
        }

        public void  GeneretMap()
        {
            _allTileCoords = new List<Coord>();
            _map = new List<GameObject>();

            for (int x = 0; x < _mapSize.x; x++)
            {
                for (int y = 0; y < _mapSize.y; y++)
                {
                    _allTileCoords.Add(new Coord(x, y));
                }
            }
            //SHUFFLE
            Shuffle();
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
                    _map.Add(_newTile.gameObject);
                }


            }

            // Create Obstacle
            bool[,] _obstacleMap = new bool[(int)_mapSize.x, (int)_mapSize.y];
            int _obstacleCount = (int)(_mapSize.x * _mapSize.y * _obstaclePercent);
            int _currentObstacleCount = 0;

            for (int i = 0; i < _obstacleCount; i++)
            {
                Coord _randomCoord = GetRandomCoord();
                _obstacleMap[_randomCoord.x, _randomCoord.y] = true;
                _currentObstacleCount++;

                if (_randomCoord != _mapCenter && MapIsFullAccesible(_obstacleMap, _currentObstacleCount))
                {
                    Vector3 _obtaclePosition = CoordToPosition(_randomCoord.x, _randomCoord.y);
                    //

                    Transform _newObstacle = Instantiate(_obstaclePreefab, _obtaclePosition + Vector3.up * 0.5f, Quaternion.identity) as Transform;
                    _newObstacle.parent = _mapHolder;
                    _map.Add(_newObstacle.gameObject);
                }
                else
                {
                    _obstacleMap[_randomCoord.x, _randomCoord.y] = false;
                    _currentObstacleCount--;
                }
            }
        }

        public void Shuffle()
        {
            _shuffledCoords = new Queue<Coord>(ShuffleArray.Shuffle(_allTileCoords.ToArray(), _seed));
        }

        //
        bool MapIsFullAccesible(bool[,] obstacleMap, int currentObstacleCnt)
        {
            bool[,] _mapFlags = new bool[obstacleMap.GetLength(0), obstacleMap.GetLength(1)];
            Queue<Coord> _queue = new Queue<Coord>();
            _queue.Enqueue(_mapCenter);
            _mapFlags[_mapCenter.x, _mapCenter.y] = true;

            int _accessibleTileCnt = 1;

            while (_queue.Count > 0)
            {
                Coord _tile = _queue.Dequeue();
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        int _neighbourX = _tile.x+x;
                        int _neighbourY = _tile.y+y;

                        if (x==0||y==0 )
                        {
                            if (_neighbourX>=0 && _neighbourX < obstacleMap.GetLength(0) && _neighbourY >= 0 && _neighbourY < obstacleMap.GetLength(1))
                            {
                                if (!_mapFlags[_neighbourX,_neighbourY] && !obstacleMap[_neighbourX,_neighbourY])
                                {
                                    _mapFlags[_neighbourX, _neighbourY] = true;
                                    _queue.Enqueue(new Coord(_neighbourX, _neighbourY));
                                    _accessibleTileCnt++;
                                }
                            }
                        }
                    }
                }
            }
            int _targetAccesibleTileCount = (int)(_mapSize.x * _mapSize.y - currentObstacleCnt);
            return _targetAccesibleTileCount == _accessibleTileCnt;
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

        public void ClearEditor()
        {
            if (_map == null) return;
            foreach (GameObject item in _map)
            {
                DestroyImmediate(item);
            }
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

        public static bool operator ==(Coord c1, Coord c2) => (c1.x == c2.x && c1.y == c2.y);

        public static bool operator !=(Coord c1, Coord c2) => !(c1 ==c2);
    }
}
