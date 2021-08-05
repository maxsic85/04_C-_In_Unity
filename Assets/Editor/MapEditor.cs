using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(Max.Generetion.MapGeneretion))]
public class MapEditor : Editor
{
    [System.Obsolete]
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Max.Generetion.MapGeneretion map = target as Max.Generetion.MapGeneretion;
        map.GeneretMap();
    }
}
