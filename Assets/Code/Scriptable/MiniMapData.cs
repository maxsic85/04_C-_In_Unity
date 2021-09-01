
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Map", fileName = nameof(MiniMapData))]
public class MiniMapData : ScriptableObject
{
    [SerializeField] private Camera _camera;
    [SerializeField] private string tagCamera;
    [SerializeField] private RenderTexture pathimage;

    public Camera Pathcamera { get => GameObject.FindGameObjectWithTag(tagCamera).GetComponent<Camera>(); set => _camera = value; }
    public RenderTexture Pathimage { get => _camera.targetTexture; set => pathimage = value; }
}
