using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Max.Core;
public interface IEnemyFactory 
{
    IEnemy CreateEnemy(Transform transform);
}
