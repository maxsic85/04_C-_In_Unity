using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Max.Core;
class CompositeMove : Imove
{

    public List<Imove> _imoves = new List<Imove>();
    public void Move(Vector3 point)
    {
        for (var i = 0; i < _imoves.Count; i++)
        {
            _imoves[i].Move(point);
        }
    }

    public void AddUnit(Imove unit)
    {
        _imoves.Add(unit);
    }

    public void RemoveUnit(Imove unit)
    {
        _imoves.Remove(unit);
    }
}

