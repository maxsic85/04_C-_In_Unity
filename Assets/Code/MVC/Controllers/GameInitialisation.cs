using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameInitialisation 
{
    public GameInitialisation(Controllers _controllers)
    {
        _controllers.Add(new TestLogController());
    }
}
