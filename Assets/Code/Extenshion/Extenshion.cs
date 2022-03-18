using System.Collections.Generic;
using UnityEngine;
using System;

namespace Labirint.Extenshion
{
    public static class Extenshion
    {
        [ExecuteInEditMode]
        public static void DebugLog(this string self)
        {
            Debug.Log(self);
        }

        public static T GetOrAddComponent<T>(this GameObject child) where T : Component
        {
            T result = child.GetComponent<T>();
            if (result == null)
            {
                result = child.AddComponent<T>();
            }

            return result;
        }

        public static float TrySingle(this string self)
        {
            if (Single.TryParse(self, out var res))
            {
                return res;
            }
            return 0;
        }

        public static T AddTo<T>(this T self, ICollection<T> coll)
        {
            coll.Add(self);
            return self;
        }
    }
}
