using Labirint.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Max.Core
{
    public interface IPlayerMove : Imoveble
    {
        event Action<float> OnStepNoizeChange;
    }
}