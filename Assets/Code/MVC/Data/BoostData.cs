using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoostType
{
    GOOD=0,
    BAD=1
}

public struct BoostData 
{
    public BoostData(string path, int value, BoostType type)
    {
        _path = path;
        _value = value;
        _type = type;
    }

    public string _path { get; private set; }
    public int _value { get; private set; }

    public BoostType _type { get; private set; }


}
