using System;
namespace MAX.CODE.MVC
{
    public interface IPlayerMove : Imove
    {
        event Action<float> OnStepNoizeChange;
    }
}