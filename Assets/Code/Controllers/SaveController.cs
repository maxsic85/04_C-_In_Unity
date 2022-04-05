using Labirint.Core;
using UnityEngine;

namespace Labirint.Save
{
    public sealed class SaveController : IExecute
    {
        public ISavePlayerPosition _saveDataPosition;
        private readonly InputController _inputController;
        private Transform _playerTransform;
        public SaveController(ISavePlayerPosition save, InputController inputController, Transform playerTransform, SaveView saveView)
        {
            _saveDataPosition = save;
            _inputController = inputController;
            _playerTransform = playerTransform;
            save.OnLoadPosition += LoadPosition;
            save.OnLoadPosition += saveView.ShowInfoAboutLoad;
        }

        public void Execute(float deltaTime)
        {
            if (_inputController.GetSave().isSave)
            {
                _saveDataPosition.SavePlayerPosition(_playerTransform.position);
            }
            if (_inputController.GetSave().isLoad)
            {
                _saveDataPosition.LoadPlayerPosition(_playerTransform.position);
            }
        }

        private void LoadPosition(Vector3 pos)
        {
            _playerTransform.transform.position = pos;
        }
    }
}