using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/Radar", fileName = nameof(RadarData))]
public class RadarData : ScriptableObject
{
    [SerializeField] public string _icoPAth;
    [SerializeField] public float _mapScale;
    [SerializeField] private Transform radar;
    public Image Ico { get => Resources.Load<Image>(_icoPAth); }
    public Transform Radar { get => FindObjectOfType<RadarMarker>().gameObject.transform; }
}
