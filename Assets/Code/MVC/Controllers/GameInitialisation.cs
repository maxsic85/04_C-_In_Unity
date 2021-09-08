using MAX.CODE.GENERETION;
using UnityEngine;
namespace MAX.CODE.MVC
{
    public sealed class GameInitialisation
    {
        ShuffleMapGeneretion _levelGenerator;
        Vector3 c_offset = new Vector3(0, 0.05f, 0);
        public GameInitialisation(Controllers _controllers, InputData inputData, MiniMapData mapdata, RadarData radarData)
        {
            PlayerData _dataPlayer = new PlayerData();
            EnemyData _dataEnemy = new EnemyData();
            BoostData _boostData = new BoostData();
            ITextaData text = UnityEngine.Object.FindObjectOfType<TextData>();
            ISavePlayerPosition _save = new SaveDataRep();



            _levelGenerator = GameObject.FindObjectOfType<ShuffleMapGeneretion>();
            Transform _enemyPosition = _levelGenerator.GetRandomOpenTile();
            Transform[] _boostPosition = { _levelGenerator.GetRandomOpenTile() };  //œ–» √≈Õ≈–¿÷»» > 1 ﬁÕ»“¿ —Œ¡€“»≈  Œ“–¿¡¿“€¬¿≈“ “ŒÀ‹ Œ Õ¿ ŒƒÕŒÃ


            var playerFactory = new PlayerFactory(_dataPlayer, ShuffleMapGeneretion._mapStart + c_offset);
            var playerInitialization = new PlayerInitialisation(playerFactory);

            var enemyFactory = new EnemyFactory(_dataEnemy);
            var enemyInitialization = new EnemyInitialisation(enemyFactory);

            var boostFactory = new BoostFactory(_boostData, _boostPosition);
            var boostInitialization = new BoostInitialisation(boostFactory);

            var _camera = Camera.main.transform;
            var _player = GameObject.FindObjectOfType<Player>().transform;


            _controllers.Add(new TestLogController());
            _controllers.Add(new CameraContrpller(_player, _camera));
            _controllers.Add(new PlayerController(_player, _dataPlayer._baseSpeed, _dataPlayer._mask, inputData, _save));
            _controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), _player.gameObject.transform));
          //  _controllers.Add(new DamageController(10, _player.gameObject));
            _controllers.Add(new MapController(mapdata, _player));
            _controllers.Add(new RadarController(radarData, _player));
            _controllers.Add(new TextController(_dataPlayer, text));
        }
    }
}