using MAX.CODE.GENERETION;
using UnityEditor;
using UnityEngine;
public class CreateWall : ScriptableWizard
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] ShuffleMapGeneretion _levelGenerator;
    [MenuItem("GameObject/Create Other/Wall")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Create Cone", typeof(CreateWall));
    }

    private void OnWizardCreate()
    {
        GameObject _newWall = new GameObject("Wall4Editor");
        string meshPrefabPath = "Assets/Editor/Wall4Editor.asset";

        BoxCollider _box = (BoxCollider)AssetDatabase.LoadAssetAtPath(meshPrefabPath, typeof(GameObject));
        _box = _newWall.AddComponent<BoxCollider>();

        MeshRenderer _meshRend = (MeshRenderer)AssetDatabase.LoadAssetAtPath(meshPrefabPath, typeof(GameObject));
        _meshRend = _newWall.AddComponent<MeshRenderer>();

        MeshFilter _filter = (MeshFilter)AssetDatabase.LoadAssetAtPath(meshPrefabPath, typeof(GameObject));
        _filter = _newWall.AddComponent<MeshFilter>();
        _filter.mesh = _mesh;

        Transform _pos = (Transform)AssetDatabase.LoadAssetAtPath(meshPrefabPath, typeof(GameObject));
        _pos = _newWall.AddComponent<Transform>();

        if (_levelGenerator == null)
        {
            _levelGenerator = GameObject.FindObjectOfType<ShuffleMapGeneretion>();
            _levelGenerator.ClearEditor();
            _levelGenerator.GeneretMap();
        }
        var _transf = _levelGenerator.GetRandomOpenTile();
        _newWall.transform.position = _transf.position;
        _newWall.transform.position = _newWall.transform.position + Vector3.up / 2;

        _newWall = Resources.Load<GameObject>("Assets/Editor/Wall4Editor");


        Selection.activeObject = _newWall;
    }
}
