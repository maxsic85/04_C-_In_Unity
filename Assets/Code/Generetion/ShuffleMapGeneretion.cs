using System.Collections.Generic;
using UnityEngine;

namespace Max.Generetion
{
    public class ShuffleMapGeneretion : MonoBehaviour, IShuffleGeneretion
    {
        public Map[] _maps;
        public int _mapIndex;

        public Transform _tilePrefab;
        public Transform _obstaclePreefab;
        [Range(0, 1)]
        public float _outLine = 0;
        [SerializeField] List<Coord> _allTileCoords;
        Queue<Coord> _shuffledCoords;
        Queue<Coord> _freeShuffledCoords;
        List<Coord> _freeCoord;
        List<GameObject> _map;
        public bool _genereteInInspector;
        Map _currentMap;
        Transform[,] _tileMap;
        public static Vector3 _mapStart { get; private set; }
        public void GeneretMap()
        {
            _currentMap = _maps[_mapIndex];
            _freeCoord = new List<Coord>();
            _tileMap = new Transform[_currentMap._mapSize.x, _currentMap._mapSize.y];
            _freeCoord = _allTileCoords;
            _map = new List<GameObject>();
            _mapStart = CoordToPosition(0, 0);
            //Generete Coords
            _allTileCoords = new List<Coord>();
            for (int x = 0; x < _currentMap._mapSize.x; x++)
            {
                for (int y = 0; y < _currentMap._mapSize.y; y++)
                {
                    _allTileCoords.Add(new Coord(x, y));
                }
            }
            //SHUFFLE
            Shufle();

            //Create holder map
            string _holderName = "Map";
            if (transform.FindChild(_holderName)) DestroyImmediate(transform.FindChild(_holderName).gameObject);
            Transform _mapHolder = new GameObject(_holderName).transform;
            _mapHolder.parent = transform;
            //Spawn Tile
            for (int x = 0; x < _currentMap._mapSize.x; x++)
            {
                for (int y = 0; y < _currentMap._mapSize.y; y++)
                {
                    Vector3 tilePosition = CoordToPosition(x, y);
                    Transform _newTile = Instantiate(_tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                    _newTile.localScale = Vector3.one * (1 - _outLine);
                    _newTile.parent = _mapHolder;
                    _map.Add(_newTile.gameObject);
                    _tileMap[x, y] = _newTile;
                }
            }

            // Spawn Obstacle
            bool[,] _obstacleMap = new bool[(int)_currentMap._mapSize.x, (int)_currentMap._mapSize.y];
            int _obstacleCount = (int)(_currentMap._mapSize.x * _currentMap._mapSize.y * _currentMap._obtaclePercent);
            int _currentObstacleCount = 0;
            List<Coord> _allFreeCoord = new List<Coord>(_allTileCoords);

            for (int i = 0; i < _obstacleCount; i++)
            {
                Coord _randomCoord = GetRandomCoord();
                _obstacleMap[_randomCoord.x, _randomCoord.y] = true;
                _currentObstacleCount++;

                if (_randomCoord != _currentMap._mapCenter && _randomCoord != _currentMap._mapStart && MapIsFullAccesible(_obstacleMap, _currentObstacleCount))
                {
                    Vector3 _obtaclePosition = CoordToPosition(_randomCoord.x, _randomCoord.y);
                    //

                    Transform _newObstacle = Instantiate(_obstaclePreefab, _obtaclePosition + Vector3.up * 0.5f, Quaternion.identity) as Transform;
                    _newObstacle.parent = _mapHolder;
                    _map.Add(_newObstacle.gameObject);
                    _freeCoord.Remove(_randomCoord);
                    _allFreeCoord.Remove(_randomCoord);
                }
                else
                {
                    _obstacleMap[_randomCoord.x, _randomCoord.y] = false;
                    _currentObstacleCount--;
                }
            }
            _freeShuffledCoords = new Queue<Coord>(ShuffleArray.Shuffle(_allFreeCoord.ToArray(), _currentMap._seed));
            Debug.Log(_freeCoord.Count);
        }

        public void Shufle()
        {
            _shuffledCoords = new Queue<Coord>(ShuffleArray.Shuffle(_allTileCoords.ToArray(), _currentMap._seed));
        }

        //
        bool MapIsFullAccesible(bool[,] obstacleMap, int currentObstacleCnt)
        {
            bool[,] _mapFlags = new bool[obstacleMap.GetLength(0), obstacleMap.GetLength(1)];
            Queue<Coord> _queue = new Queue<Coord>();
            _queue.Enqueue(_currentMap._mapCenter);
            _mapFlags[_currentMap._mapCenter.x, _currentMap._mapCenter.y] = true;

            int _accessibleTileCnt = 1;

            while (_queue.Count > 0)
            {
                Coord _tile = _queue.Dequeue();
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        int _neighbourX = _tile.x + x;
                        int _neighbourY = _tile.y + y;

                        if (x == 0 || y == 0)
                        {
                            if (_neighbourX >= 0 && _neighbourX < obstacleMap.GetLength(0) && _neighbourY >= 0 && _neighbourY < obstacleMap.GetLength(1))
                            {
                                if (!_mapFlags[_neighbourX, _neighbourY] && !obstacleMap[_neighbourX, _neighbourY])
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
            int _targetAccesibleTileCount = (int)(_currentMap._mapSize.x * _currentMap._mapSize.y - currentObstacleCnt);
            return _targetAccesibleTileCount == _accessibleTileCnt;
        }
        Vector3 CoordToPosition(int x, int y)
        {
            return new Vector3(-_currentMap._mapSize.x / 2 + 0.5f + x, 0, _currentMap._mapSize.y / 2 + 0.5f + y);
        }
        public Coord GetRandomCoord()
        {
            Coord _randomCoord = _shuffledCoords.Dequeue();
            _shuffledCoords.Enqueue(_randomCoord);
            return _randomCoord;

        }

        public Transform GetRandomOpenTile()
        {
            Coord _randomCoord = _freeShuffledCoords.Dequeue();
            _freeShuffledCoords.Enqueue(_randomCoord);
            return _tileMap[_randomCoord.x, _randomCoord.y];
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
            get => new Coord(0,0);
        }

    }
    [System.Serializable]
    public struct Coord
    {
        public int x, y;

        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public static bool operator ==(Coord c1, Coord c2) => (c1.x == c2.x && c1.y == c2.y);

        public static bool operator !=(Coord c1, Coord c2) => !(c1 == c2);
    }


}
