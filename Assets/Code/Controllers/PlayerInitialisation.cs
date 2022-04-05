namespace Labirint.Player
{
    public sealed class PlayerInitialisation 
    {
        private readonly IPlayerFactory _playerFactory;

        public PlayerInitialisation(IPlayerFactory playerFactoryr)
        {
            _playerFactory = playerFactoryr;
            _playerFactory.CreatePlayer();
        }
    }
}