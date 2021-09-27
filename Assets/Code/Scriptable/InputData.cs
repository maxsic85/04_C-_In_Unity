using UnityEngine;
namespace MAX.CODE.MVC
{
    [CreateAssetMenu(menuName = "Data/Input", fileName = nameof(InputData))]
    public class InputData : ScriptableObject
    {
        public KeyCode SavePlayer = KeyCode.C;
        public KeyCode LoadPlayer = KeyCode.V;
    }
}