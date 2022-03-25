using UnityEditor;

namespace Labirint.Generation
{
    [CustomEditor(typeof(ShuffleMapGeneretionBeh))]
    public class MapEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ShuffleMapGeneretionBeh map = target as ShuffleMapGeneretionBeh;
            base.OnInspectorGUI();

            if (map._doGenereteInInspector)
            {
                map.GeneretMap();

                map._doGenereteInInspector = !map._doGenereteInInspector;
            }

            else if (map._doClearMap && !map._doGenereteInInspector)
            {
                map.ClearEditor();
                map._doClearMap = !map._doClearMap;
            }
        }
    }
}