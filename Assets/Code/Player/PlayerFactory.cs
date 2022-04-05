using Labirint.Data;
using UnityEngine;

namespace Labirint.Player
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerData _playerData;
        Vector3 _position;
        public PlayerFactory(PlayerData playerData, Vector3 position)
        {
            _playerData = playerData;
            _position = position;
        }

        public IPlayer CreatePlayer()
        {
            var enemyProvider = _playerData.GetPlayer();
            enemyProvider.transform.position = _position;
            return Object.Instantiate(enemyProvider);
        }
    }
}