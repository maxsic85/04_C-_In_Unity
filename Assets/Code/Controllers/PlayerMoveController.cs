using Labirint.Constants;
using Labirint.Data;
using UnityEngine;

namespace Labirint.Core
{
    public sealed class PlayerMoveController:IExecute
    {
        private readonly InputController _inputController;
        private PlayerData _playerData;
        private  Transform _playerTransform;
        private Vector3 _moveVector;
        private RaycastHit _hit;
        private LayerMask _playerMask;
        public PlayerMoveController(InputController inputController, PlayerData playerData, Transform playerTransform, LayerMask mask)
        {
            _inputController = inputController;
            _playerTransform = playerTransform;
            _playerData = playerData;
            _playerMask = mask;
        }
        private float Angle360(Vector3 from, Vector3 to, Vector3 right)
        {
            float angle = Vector3.Angle(from, to);
            return Vector3.Angle(right, to) > 90f ? 360f - angle : angle;
        }
        private float Moves()
        {
            if (_moveVector.x != 0 || _moveVector.z != 0)
                return 1f;
            else
                return 0f;
        }
        private bool CheckWall()
        {
            Physics.Raycast(_playerTransform.position, _playerTransform.forward, out _hit, GameConstants.CHECK_WALL_TRESH, _playerMask);
            return _hit.collider != null ? true : false;
        }
        public void Move()
        {
            _moveVector.z =_inputController.GetAxisForMove().x;
            _moveVector.x = _inputController.GetAxisForMove().z;
            _playerTransform.Rotate(Vector3.up, Angle360(_playerTransform.forward, _moveVector, _playerTransform.right));

            if (!CheckWall())
            {
                _playerTransform.Translate(Moves() * _playerTransform.forward * _playerData._baseSpeed * Time.deltaTime,Space.World );
            }

        }
        public void Execute(float deltaTime)
        {
            Move();
        }
    }
}