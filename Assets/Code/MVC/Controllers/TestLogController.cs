using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogController : IExecute
{
    public void Execute(float deltaTime)
    {
        Debug.Log("TestCOntroller");
    }
}
