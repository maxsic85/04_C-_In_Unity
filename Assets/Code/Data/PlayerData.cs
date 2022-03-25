using Labirint.Core;
using System;
using UnityEngine;

namespace Labirint.Data
{
    public sealed class PlayerData
    {
        public string _path { get; private set; } = "Prefabs/Core/Player";
        public int _baseSpeed { get; } = 2;
        public int _baseNoise { get; } = 2;
        public int _baseDamage { get; } = 2;
        public LayerMask _mask { get; } = LayerMask.GetMask("Wall");
        public GameObject _player;


        public PlayerData()
        {
            _player = (GameObject)Resources.Load(_path);
        }
        public PlayerProvider GetPlayer()
        {
            if (_player == null)
            {
                throw new InvalidOperationException($"Player type not found");
            }
            return _player.GetComponent<PlayerProvider>();
        }

        public GameObject PlayerOnSceene()
        {
            if (_player == null)
            {
                throw new InvalidOperationException($"Player type not found");
            }
            return GameObject.FindObjectOfType<PlayerProvider>().gameObject ;
        }
    }
}