using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Meta
{
    public interface IBoost : IDisposable
    {
        event System.Action Boost;
    }
}
