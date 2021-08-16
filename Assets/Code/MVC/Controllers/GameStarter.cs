using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{

    private Controllers _controllers;
    // Start is called before the first frame update
    void Start()
    {
        _controllers = new Controllers();
        new GameInitialisation(_controllers);
        _controllers.Initialization();
    }

    // Update is called once per frame
    private void Update()
    {
        var deltaTime = Time.deltaTime;
        _controllers.Execute(deltaTime);
    }
}
