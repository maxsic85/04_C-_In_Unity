using UnityEngine;

namespace Labirint.Core
{
    public sealed class MapController : IExecute
    {
      private readonly MiniMapData _dataMap;
        private readonly Transform _player;
        public MapController(MiniMapData data, Transform player)
        {
            _dataMap = data;
            var main = Camera.main;
            var _mapCamera = data.Pathcamera;
            _mapCamera.depth = --main.depth;
            _player = player;
        }

        public void ChangePosition()
        {
            var newPosition = _player.position;
            newPosition.y = _dataMap.Pathcamera.transform.position.y;
            _dataMap.Pathcamera.transform.position = newPosition;
            _dataMap.Pathcamera.transform.rotation = Quaternion.Euler(90, _player.eulerAngles.x, 90);
            Debug.Log(_dataMap.Pathcamera.transform.position);
        }

        public void Execute(float deltaTime)
        {
            ChangePosition();
        }
    }
}