using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utilities
{
    public static class Extensions
    {
        public static Vector3 ToVector2(this Vector3 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }
    }

    // Helper class to emulate a python DefaultDictionary
    // Default values are the type's default value
    // bool -> false
    // int -> 0
    public class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue> where TValue : new()
    {
        public new TValue this[TKey key]
        {
            get
            {
                TValue val;
                if (!TryGetValue(key, out val))
                {
                    val = new TValue();
                    Add(key, val);
                }
                return val;
            }
            set { base[key] = value; }
        }
    }
}