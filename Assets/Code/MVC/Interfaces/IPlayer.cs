using System;
namespace MAX.CODE.MVC
{
    public interface IPlayer
    {
        event Action<int> OnTriggerEnterChange;
    }
}