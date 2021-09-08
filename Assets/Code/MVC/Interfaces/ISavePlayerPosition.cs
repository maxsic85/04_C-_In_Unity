using System;
using UnityEngine;
namespace MAX.CODE.MVC
{
    public interface ISavePlayerPosition
    {
        void Save(Vector3 position);
        void Load(Vector3 position);
        public event Action<Vector3> OnLoadPosition;
    }
}
