using System;
using System.Data;
using System.IO;
using UnityEngine;
namespace MAX.CODE.MVC
{
    public class SaveDataRep : ISavePlayerPosition
    {

        public event Action<Vector3> OnLoadPosition = delegate (Vector3 pos) { };
        private readonly IDataSave<SavedData> _data;
        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;
        private Transform _currentPlayer;

        public SaveDataRep()
        {

            _data = new XMLData();
            _path = Path.Combine(Application.dataPath, _folderName);

        }

        public void Save(Vector3 player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                Position = player,
                Name = "Max",
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
            Debug.Log("Save");
        }

        public void Load(Vector3 player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                throw new DataException($"File {file} not found");
            }
            var newPlayer = _data.Load(file);
            player = newPlayer.Position;

            OnLoadPosition?.Invoke(player);

            //player.gameObject.SetActive(newPlayer.IsEnabled);
            //_currentPlayer = GameObject.FindObjectOfType<Max.Core.Player>().GetComponent<Transform>();
            //_currentPlayer.position = player;
            Debug.Log(newPlayer);
        }
    }
}
