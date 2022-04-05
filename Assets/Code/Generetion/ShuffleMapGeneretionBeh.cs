using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

namespace Labirint.Generation
{
    public class ShuffleMapGeneretionBeh : MonoBehaviour, IShuffleMapGeneretion
    {
        private const string _holderName = "Map";

        [SerializeField] private Map[] _maps;
        [SerializeField] private int _mapIndex;
        [SerializeField] private Transform _tilePrefab;
        [SerializeField] private Transform _obstaclePreefab;
        [SerializeField] [Range(0, 1)] private float _outLine = 0;
        [SerializeField] private List<Coord> _allTileCoords;
        public bool _doGenereteInInspector;
        public bool _doClearMap;
        private Queue<Coord> _shuffledCoords;
        private Queue<Coord> _freeShuffledCoords;
        private List<Coord> _freeCoord;
        private List<GameObject> _map;
        private Map _currentMap;
        private Transform[,] _tileMap;
        private Transform _mapHolder;
        [SerializeField] private List<Transform> _mapBorder;
        public static Vector3 VectorMapStart { get; private set; }
        public void GeneretMap()
        {
            _currentMap = _maps[_mapIndex];
            _freeCoord = new List<Coord>();
            _tileMap = new Transform[_currentMap._mapSize.x, _currentMap._mapSize.y];
            _freeCoord = _allTileCoords;
            _map = new List<GameObject>();
            SetParentHolder();
            SetBoardObtacle();
            GenerationCord();
            Shufle();
            SpawnTile(_mapHolder);
            SpawnObtacle(_mapHolder);
            _freeShuffledCoords = new Queue<Coord>(ShuffleArray.Shuffle(_freeCoord.ToArray(), _currentMap._seed));
            VectorMapStart = GetRandomOpenTile().position;
            SetOutputFromLabirint();
        }

        private void SetBoardObtacle()
        {
            _mapBorder = new List<Transform>();

            for (int x = 0; x < _currentMap._mapSize.x + 2; x++)
            {
                for (int y = 0; y < _currentMap._mapSize.y + 1; y++)
                {
                    if (x == 0 || y == 0)
                    {
                        Vector3 _obtaclePosition = CoordToPosition(x - 1, y - 1);
                        Transform _newObstacle = Instantiate(_obstaclePreefab, _obtaclePosition + Vector3.up * 0.5f, Quaternion.identity) as Transform;
                        _newObstacle.parent = _mapHolder;
                        _mapBorder.Add(_newObstacle);
                    }
                    if (x == _currentMap._mapSize.x + 1 || y == _currentMap._mapSize.y)
                    {
                        Vector3 _obtaclePosition = CoordToPosition(x - 1, y);
                        Transform _newObstacle = Instantiate(_obstaclePreefab, _obtaclePosition + Vector3.up * 0.5f, Quaternion.identity) as Transform;
                        _newObstacle.parent = _mapHolder;
                        _mapBorder.Add(_newObstacle);
                    }
                }
            }
        }
        private void SetOutputFromLabirint()
        {
            var random = new System.Random();
            var index = random.Next(0, _mapBorder.Count - 1);
            var selectedBorder = _mapBorder[index].gameObject.transform.position;

            if ((selectedBorder.x == (_currentMap._mapSize.x / 2 + 0.5) || selectedBorder.x == (-_currentMap._mapSize.x / 2 - 0.5)) &&
                (selectedBorder.z == (_currentMap._mapSize.y / 2 - 0.5) || selectedBorder.z == (_currentMap._mapSize.y + _currentMap._mapSize.y / 2) + 0.5))
            {
                SetOutputFromLabirint();
                return;
            }
            foreach (var obtacle in from obtacle in _map
                                    where obtacle.GetComponent<NavMeshObstacle>()
                                    select obtacle)
            {
                for (var x = selectedBorder.x - 1; x <= selectedBorder.x + 1; x++)
                {
                    for (var z = selectedBorder.z - 1; z <= selectedBorder.z + 1; z++)
                    {
                        if (x == obtacle.transform.position.x && z == obtacle.transform.position.z)
                        {
                            SetOutputFromLabirint();
                            return;
                        }
                    }
                }
            }
            DestroyImmediate(_mapBorder[index].gameObject);
            _mapBorder.RemoveAt(index);
        }
        private void SetParentHolder()
        {
            if (transform.Find(_holderName)) DestroyImmediate(transform.Find(_holderName).gameObject);
            _mapHolder = new GameObject(_holderName).transform;
            _mapHolder.parent = transform;
        }
        private void SpawnObtacle(Transform _mapHolder)
        {
            bool[,] _obstacleMap = new bool[_currentMap._mapSize.x, _currentMap._mapSize.y];
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
        }
        private void SpawnTile(Transform _mapHolder)
        {
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
        }
        private void GenerationCord()
        {
            _allTileCoords = new List<Coord>();
            for (int x = 0; x < _currentMap._mapSize.x; x++)
            {
                for (int y = 0; y < _currentMap._mapSize.y; y++)
                {
                    _allTileCoords.Add(new Coord(x, y));
                }
            }
        }
        public void Shufle()
        {
            _shuffledCoords = new Queue<Coord>(ShuffleArray.Shuffle(_allTileCoords.ToArray(), _currentMap._seed));
        }
        private bool MapIsFullAccesible(bool[,] obstacleMap, int currentObstacleCnt)
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
            int _targetAccesibleTileCount = _currentMap._mapSize.x * _currentMap._mapSize.y - currentObstacleCnt;
            return _targetAccesibleTileCount == _accessibleTileCnt;
        }
        private Vector3 CoordToPosition(int x, int y)
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
            foreach (Transform item in _mapBorder)
            {
                DestroyImmediate(item.gameObject);
            }
        }
    }
}
