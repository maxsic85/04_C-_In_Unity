using Labirint.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Max.Core
{
    public interface IPlayerMove : Imove
    {
        event Action<float> OnStepNoizeChange;
    }
}