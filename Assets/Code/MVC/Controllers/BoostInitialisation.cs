using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BoostInitialisation : IInitialisation
{
    private readonly IBoostFactory _boostFactory;

    public BoostInitialisation(IBoostFactory boostFactory)
    {
        _boostFactory = boostFactory;
        _boostFactory.CreateBoost();
    }

    public void Initialization()
    {
        throw new System.NotImplementedException();
    }
}
