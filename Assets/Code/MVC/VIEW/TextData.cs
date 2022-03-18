using Labirint.Data;
using UnityEngine;
using UnityEngine.UI;
namespace Labirint.View
{
    [RequireComponent(typeof(Text))]
    public class TextData : MonoBehaviour, ITextaData
    {
        private Text _text;

        private void Awake()
        {
            _text = gameObject.GetComponent<Text>();
        }

        public void UpdateText(PlayerData data)
        {
            if (data == null) return;
            _text.text = data._player.name;
        }
    }
}
