namespace MAX.CODE.MVC
{
    public sealed class PlayerInitialisation : IInitialisation
    {
        private readonly IPlayerFactory _playerFactory;


        public PlayerInitialisation(IPlayerFactory playerFactoryr)
        {
            _playerFactory = playerFactoryr;
            _playerFactory.CreatePlayer();

        }

        //public Transform GetPlayer()
        //{ 

        //}

        public void Initialization()
        {
            throw new System.NotImplementedException();
        }
    }
}