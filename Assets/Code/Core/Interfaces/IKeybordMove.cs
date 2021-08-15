using UnityEngine.UIElements;
namespace Max.Core
{
    public interface IKeybordMove : Imove, IPlayerMove
    {
        void OnMouseDown(MouseDownEvent evt);
    }
}