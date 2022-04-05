using Labirint.Generation;
using Labirint.Save;
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
        [SerializeField] private SaveView _saveView;



        private ShuffleMapGeneretionBeh _levelGenerator;
        void Start()
        {
            _controllers = new Controllers();
            _levelGenerator = FindObjectOfType<ShuffleMapGeneretionBeh>();
            new GameInitialisation(_controllers, _inputData, _mapData, _radarData, _levelGenerator, _camera, _saveView);
            _controllers.Initialization();

        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }
    }
}