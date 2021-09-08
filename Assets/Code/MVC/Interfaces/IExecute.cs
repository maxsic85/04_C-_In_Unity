namespace MAX.CODE.MVC
{
    public interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}