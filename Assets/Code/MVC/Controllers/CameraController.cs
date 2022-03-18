using Labirint.Constants;
using UnityEngine;

namespace Labirint.Core
{
    public class CameraController : IExecute
    {
        private Vector3 _camera_offset = new Vector3(0, 2, -0);
        private Transform _playeTransformr;
        private Transform _camerTransform;   
        private Vector3 _cameraFollowPosition;
        public CameraController(Transform player, Transform camera)
        {
            _playeTransformr = player;
            _camerTransform = camera;
            _cameraFollowPosition = new Vector3();
        }

        void MoveToPlayer()
        {
            var distanse = Vector3.Distance(_camerTransform.transform.position, _playeTransformr.transform.position);
            if (distanse > GameConstants.CAMERA_TRESH_TO_MOVE)
            {
                _cameraFollowPosition.x = _playeTransformr.transform.position.x + _camera_offset.x;
                _cameraFollowPosition.y = _camerTransform.transform.position.y;
                _cameraFollowPosition.z = _playeTransformr.transform.position.z + _camera_offset.z;
                _camerTransform.transform.position = Vector3.Lerp(_camerTransform.transform.position, _cameraFollowPosition, Time.deltaTime * GameConstants.CAMERA_SMOOTH);
            }
        }
        public void Execute(float deltaTime)
        {
            MoveToPlayer();
        }
    }
}