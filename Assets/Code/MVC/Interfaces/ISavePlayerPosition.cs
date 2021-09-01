using System;
using UnityEngine;

public  interface ISavePlayerPosition
    {
    void Save(Vector3 position);
    void Load(Vector3 position);
    public event Action<Vector3> OnLoadPosition;
    }

