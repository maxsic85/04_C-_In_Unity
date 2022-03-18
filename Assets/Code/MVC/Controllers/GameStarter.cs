using Labirint.Generation;
using UnityEngine;

namespace Labirint.Core
{
    public class GameStarter : MonoBehaviour
    {

        public Controllers _controllers;
        [SerializeField] private Camera _camera;
        [SerializeField] private InputData _inputData;
        [SerializeField] private MiniMapData _mapData;
        [SerializeField] private RadarData _radarData;
        private ShuffleMapGeneretion _levelGenerator;
        void Start()
        {
            _controllers = new Controllers();
            _levelGenerator = FindObjectOfType<ShuffleMapGeneretion>();
            new GameInitialisation(_controllers, _inputData, _mapData, _radarData, _levelGenerator, _camera);
            _controllers.Initialization();

        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }
    }
}