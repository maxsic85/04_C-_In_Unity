using UnityEditor;

namespace Max.Generetion
{
    [CustomEditor(typeof(Max.Generetion.ShuffleMapGeneretion))]
    public class MapEditor : Editor
    {
        public override void OnInspectorGUI()
        {
                    Max.Generetion.ShuffleMapGeneretion map = target as Max.Generetion.ShuffleMapGeneretion;
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