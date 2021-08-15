using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Meta
{
    public interface IDropBoost : IBoost
    {
        event System.Action<bool> OnDropBoost;
    }
}