using Labirint.Save;
using UnityEngine;

namespace Labirint.Core
{
    public class PlayerMoveController2 : IExecute
    {
        private InputData _inputData;
        private float _speed = 2f;
        private LayerMask _mask;
        private Transform _player;
        private IPCKeybordInput _move;
        BuiletData _fireData = new BuiletData();
        BuiletFactory _fabrik;
        ISavePlayerPosition _save;

        public PlayerMoveController2(Transform player, float speed, LayerMask mask, InputData inputData, ISavePlayerPosition save)
        {
            _player = player;
            _speed = speed;
            _mask = mask;
            _inputData = inputData;
            _move = new PCInputController2(player, _speed, _mask, inputData, save);
            _fabrik = new BuiletFactory(_fireData);

            save.OnLoadPosition += LoadPosition;

        }

        private void LoadPosition(Vector3 pos)
        {
            _player.transform.position = pos;
        }

        public void Execute(float deltaTime)
        {
            //_move.Move(Vector3.one);
            //_move.Fire(_fireData, _fabrik);
        }

    }
}