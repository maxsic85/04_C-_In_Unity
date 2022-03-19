using System.Collections.Generic;
using UnityEngine;

namespace Labirint.Core
{
    class CompositeMove : Imoveble,IMoveInitialising
    {
        public List<Imoveble> _imoves = new List<Imoveble>();

        public void Move(Vector3 point)
        {
            for (var i = 0; i < _imoves.Count; i++)
            {
                _imoves[i].Move(point);
            }
        }

        public void AddUnit(Imoveble unit)
        {
            _imoves.Add(unit);
        }

        public void RemoveUnit(Imoveble unit)
        {
            _imoves.Remove(unit);
        }
    }
}