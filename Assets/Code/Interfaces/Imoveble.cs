using UnityEngine;
namespace Labirint.Core
{
    public interface Imoveble
    {
        void Move(Vector3 _point);
        public void AddUnit(Imoveble unit);
        public void RemoveUnit(Imoveble unit);
    }
}