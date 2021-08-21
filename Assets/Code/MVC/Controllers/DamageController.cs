using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : IDamageble, IExecute
{
    public event System.Action _getDamage;
    private int _damage;
    private GameObject _enemy;

    public DamageController(int damage, GameObject enemy)
    {
        _damage = damage;
        _enemy = enemy;
        _getDamage += GetFamage;
    }

  

    public void GetFamage()
    {
        Debug.Log("Piu");
    }

    public void Execute(float deltaTime)
    {
        GetFamage();
    }
}
