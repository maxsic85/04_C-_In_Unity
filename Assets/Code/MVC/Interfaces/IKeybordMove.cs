namespace MAX.CODE.MVC
{
    public interface IKeybordMove : Imove, IPlayerMove, IFire
    {
        public void GetInput();
    }
}