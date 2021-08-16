using UnityEditor;

namespace Max.Generetion
{
    [CustomEditor(typeof(Max.Generetion.ShuffleMapGeneretion))]
    public class MapEditor : Editor
    {
    
        [System.Obsolete]
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Max.Generetion.ShuffleMapGeneretion map = target as Max.Generetion.ShuffleMapGeneretion;
         if(map._genereteInInspector)   map.GeneretMap();
            else
            {
               map.ClearEditor();
            }
        }
    }
}