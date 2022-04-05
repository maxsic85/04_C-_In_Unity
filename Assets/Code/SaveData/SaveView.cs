using UnityEngine;
using UnityEngine.UI;

namespace Labirint.Save
{
    public class SaveView : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private Text _saveTxt;
        [SerializeField] private Text _loadTxt;
        [SerializeField] private Text _infoAboutloadTxt;


        void Start()
        {

            _saveTxt.text = $"For Save press  {_inputData.SavePlayer.ToString()}";
            _loadTxt.text = $"For Load press {_inputData.LoadPlayer.ToString()}";

        }

        public void ShowInfoAboutLoad(Vector3 position)
        {
            _infoAboutloadTxt.text = $"Game was loaded, position: {position}";
        }

    }
}