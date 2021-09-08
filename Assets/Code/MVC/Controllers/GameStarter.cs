using UnityEngine;
namespace MAX.CODE.MVC
{
    public class GameStarter : MonoBehaviour
    {

        public Controllers _controllers;
        [SerializeField] private InputData _inputData;
        [SerializeField] private MiniMapData _mapData;
        [SerializeField] private RadarData _radarData;

        // Start is called before the first frame update
        void Start()
        {
            this.gameObject.GetOrAddComponent<SomeExtenshion>();
            _controllers = new Controllers();
            new GameInitialisation(_controllers, _inputData, _mapData, _radarData);
            _controllers.Initialization();

        }

        // Update is called once per frame
        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }
    }
}