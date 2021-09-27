using UnityEngine;

namespace MAX.CODE.MVC
{
    public class PlayerController : IExecute
    {
        private InputData _inputData;
        private float _speed = 2f;
        private LayerMask _mask;
        private Transform _player;
        private IKeybordMove _move;
        BuiletData _fireData = new BuiletData();
        BuiletFactory _fabrik;
        ISavePlayerPosition _save;

        public PlayerController(Transform player, float speed, LayerMask mask, InputData inputData, ISavePlayerPosition save)
        {
            _player = player;
            _speed = speed;
            _mask = mask;
            _inputData = inputData;
            _move = new KeyController(player, _speed, _mask, inputData, save);
            _fabrik = new BuiletFactory(_fireData);

            save.OnLoadPosition += LoadPosition;

        }

        private void LoadPosition(Vector3 pos)
        {
            _player.transform.position = pos;
        }


        public void Execute(float deltaTime)
        {
            _move.Move(Vector3.one);
            _move.Fire(_fireData, _fabrik);
        }

    }

}
