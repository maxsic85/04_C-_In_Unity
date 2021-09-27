using UnityEngine.UIElements;
namespace Max.Core
{
    public interface IKeybordMove : Imove, IPlayerMove,IFire
    {
       public void GetInput();
    }
}