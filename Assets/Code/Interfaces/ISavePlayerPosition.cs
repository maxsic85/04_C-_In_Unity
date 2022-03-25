using System;
using UnityEngine;

namespace Labirint.Save
{
    public interface ISavePlayerPosition
    {
        void SavePlayerPosition(Vector3 position);
        void LoadPlayerPosition(Vector3 position);
        public event Action<Vector3> OnLoadPosition;
    }
}