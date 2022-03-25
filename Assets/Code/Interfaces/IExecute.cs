using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExecute : IController
{
    void Execute(float deltaTime);
}
