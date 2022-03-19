
using UnityEngine;
using Labirint.Constants;
using Labirint.Generation;
using Labirint.View;
using Labirint.Data;
using Labirint.Save;

namespace Labirint.Core
{
    public sealed class GameInitialisation
    {
        public GameInitialisation(Controllers _controllers,
                                  InputData inputData,
                                  MiniMapData mapdata,
                                  RadarData radarData,
                                  IMapGeneretion levelGenerator,
                                  Camera camera)
        {
            PlayerData dataPlayer = new PlayerData();
            EnemyData dataEnemy = new EnemyData();
            BoostData boostData = new BoostData();
            BuiletData fireData = new BuiletData();

            ITextaData text = Object.FindObjectOfType<TextData>();
            ISavePlayerPosition _savePlayerPosition = new SavePlayer();
            levelGenerator.GeneretMap();

            Transform[] _boostPosition = { levelGenerator.GetRandomOpenTile() };


            var playerFactory = new PlayerFactory(dataPlayer, ShuffleMapGeneretion._mapStart + GameConstants.PLAYER_OFFSET);
            var playerInitialization = new PlayerInitialisation(playerFactory);
            var player = dataPlayer.PlayerOnSceene().transform;

            var cameraController = new CameraController(player, camera.transform);

            Imoveble imoveble = new CompositeMove();
            var enemyFactory = new EnemyFactory(dataEnemy);
            var enemyInitialization = new EnemyInitialisation(enemyFactory, dataEnemy._enemyCntOnScene, imoveble, levelGenerator);
            var enemyMoveController = new EnemyMoveController(enemyInitialization.GetMoveEnemies(), player);

            var boostFactory = new BoostFactory(boostData, _boostPosition);
            var boostInitialization = new BoostInitialisation(boostFactory);

            IPCKeybordInput input = new PCInput(inputData);
            var inputController = new InputController(input);
            var playerMoveController = new PlayerMoveController(inputController, dataPlayer, player, dataPlayer._mask);

            var bulletFactory = new BuiletFactory(fireData);
            var playerShootController = new PlayerShootController(inputController, fireData, bulletFactory, player);

            var saveController = new SaveController(_savePlayerPosition, inputController, player);


            _controllers.Add(cameraController);
            _controllers.Add(playerMoveController);
            _controllers.Add(playerShootController);
            _controllers.Add(saveController);
            _controllers.Add(enemyMoveController);
          //  _controllers.Add(new DamageController(10, player.gameObject));
            _controllers.Add(new MapController(mapdata, player));
            _controllers.Add(new RadarController(radarData, player));
            _controllers.Add(new TextController(dataPlayer, text));
        }
    }
}