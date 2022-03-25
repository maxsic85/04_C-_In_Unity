namespace Labirint.Boost
{
    public sealed class BoostInitialisation
    {
        private readonly IBoostFactory _boostFactory;
        public BoostInitialisation(IBoostFactory boostFactory)
        {
            _boostFactory = boostFactory;
            _boostFactory.CreateBoost();
        }
    }
}