namespace MAX.CODE.MVC
{
    public sealed class BoostInitialisation : IInitialisation
    {
        private readonly IBoostFactory _boostFactory;

        public BoostInitialisation(IBoostFactory boostFactory)
        {
            _boostFactory = boostFactory;
            _boostFactory.CreateBoost();
        }

        public void Initialization()
        {
            throw new System.NotImplementedException();
        }
    }
}