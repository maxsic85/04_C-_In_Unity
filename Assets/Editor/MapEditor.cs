using Labirint.Generation;
using UnityEditor;

namespace Max.Generetion
{
    [CustomEditor(typeof(ShuffleMapGeneretion))]
    public class MapEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ShuffleMapGeneretion map = target as ShuffleMapGeneretion;
            base.OnInspectorGUI();
      

            if (map._genereteInInspector)
            {
                map.GeneretMap();
                
                map._genereteInInspector = !map._genereteInInspector;
            }

            else if(map._clearMap && !map._genereteInInspector)
            {
                map.ClearEditor();
                map._clearMap = !map._clearMap;
            }
        }
    }
}