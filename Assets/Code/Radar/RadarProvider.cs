using UnityEngine;
using UnityEngine.UI;

namespace Labirint.Core
{
    public class RadarProvider : MonoBehaviour
    {

        [SerializeField] private Image _ico;
        [SerializeField] RadarData data;

        private void OnValidate()
        {
            var a = (GameObject)Resources.Load(data._icoPAth);
            _ico = a.GetComponent<Image>();
        }

        private void OnDisable()
        {
          RadarController.RemoveRadarObject(gameObject);
        }

        private void OnEnable()
        {
            RadarController.RegisterRadarObject(gameObject, _ico);
        }

    }
}