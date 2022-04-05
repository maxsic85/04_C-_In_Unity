using UnityEngine;

namespace Labirint.Core
{
    public sealed class MapController : IExecute
    {
        private const float MiniMapPathCameraAngle = 90;
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
            _dataMap.Pathcamera.transform.rotation = Quaternion.Euler(MiniMapPathCameraAngle, _player.eulerAngles.x, MiniMapPathCameraAngle);
        }

        public void Execute(float deltaTime)
        {
            ChangePosition();
        }
    }
}