using UnityEngine;
namespace MAX.CODE.MVC
{
    public class MapController : IExecute
    {
        MiniMapData _data;
        Transform _player;
        public MapController(MiniMapData data, Transform player)
        {
            _data = data;
            var main = Camera.main;
            var rt = data.Pathimage;
            var _mapCamera = data.Pathcamera;
            _mapCamera.depth = --main.depth;
            _player = player;
        }

        public void ChangePosition()
        {
            var newPosition = _player.position;
            newPosition.y = _data.Pathcamera.transform.position.y;
            _data.Pathcamera.transform.position = newPosition;
            _data.Pathcamera.transform.rotation = Quaternion.Euler(90, _player.eulerAngles.x, 90);
          //  Debug.Log(_data.Pathcamera.transform.position);
        }

        public void Execute(float deltaTime)
        {
            ChangePosition();
        }
    }
}
