using System;
using System.Data;
using System.IO;
using UnityEngine;

namespace Labirint.Save
{
    public class SavePlayer : ISavePlayerPosition
    {

        public event Action<Vector3> OnLoadPosition = delegate (Vector3 pos) { };
        private readonly IDataSave<SavedData> _data;
        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;
        public SavePlayer()
        {
            _data = new XMLData();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void SavePlayerPosition(Vector3 playerPosition)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var saveData = new SavedData
            {
                Position = playerPosition,
                Name = "Tank",
                IsEnabled = true
            };

            _data.Save(saveData, Path.Combine(_path, _fileName));

        }

        public void LoadPlayerPosition(Vector3 player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                throw new DataException($"File {file} not found");
            }
            var newPlayer = _data.Load(file);
            player = newPlayer.Position;
            OnLoadPosition?.Invoke(player);
            Debug.Log(newPlayer);
        }
    }
}