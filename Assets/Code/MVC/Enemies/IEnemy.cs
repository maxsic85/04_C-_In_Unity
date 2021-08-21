using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.Core;

public interface IEnemy : Imove
{
    event Action<int> OnTriggerEnterChange;
}

