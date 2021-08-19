using UnityEngine.UIElements;
namespace Max.Core
{
    public interface IKeybordMove : Imove, IPlayerMove
    {
       public void GetInput();
    }
}