using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Input", fileName = nameof(InputData))]
public class InputData : ScriptableObject
{
    public KeyCode SavePlayer = KeyCode.C;
    public KeyCode LoadPlayer = KeyCode.V;
    public KeyCode FireAxis = KeyCode.Space;
    public string HorizontalAxis = "Horizontal";
    public string VerticalAxis = "Vertical";


}
