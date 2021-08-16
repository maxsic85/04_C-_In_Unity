using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers : IInitialisation, IExecute
{
    private readonly List<IInitialisation> _initializeControllers;
    private readonly List<IExecute> _executeControllers;

    public Controllers()
    {
        _initializeControllers = new List<IInitialisation>();
        _executeControllers = new List<IExecute>();
    }

    public Controllers Add(IController _controller)
    {
        if (_controller is IInitialisation initializeController)
            _initializeControllers.Add(initializeController);

        if (_controller is IExecute executeController)
            _executeControllers.Add(executeController);

        return this;
    }

    public void Execute(float deltaTime)
    {
        for (var index = 0; index < _executeControllers.Count; ++index)
        {
            _executeControllers[index].Execute(deltaTime);
        }
    }

    public void Initialization()
    {
        for (var i = 0; i < _initializeControllers.Count; ++i)
        {
            _initializeControllers[i].Initialization();
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
