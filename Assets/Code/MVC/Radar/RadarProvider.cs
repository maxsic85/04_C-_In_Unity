using UnityEngine;
using UnityEngine.UI;
using static RadarController;
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
		RemoveRadarObject(gameObject);
	}

	private void OnEnable()
	{
		RegisterRadarObject(gameObject, _ico);
	}

}
