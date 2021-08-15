using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Max.Core
{
    public struct Enemy : IDrawSectorVisibility, ICloneable,IDamageble
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void DrawSectorVisibility()
        {
            throw new System.NotImplementedException();
        }

        public void GetDamage()
        {
            throw new NotImplementedException();
        }
    }
}