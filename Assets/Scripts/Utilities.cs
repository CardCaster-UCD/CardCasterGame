using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utilities
{
    public static class VectorExtensions
    {
        public static Vector3 ToVector2(this Vector3 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }
    }

    public static class MonoBehaviourExtension
    {
        // Run n coroutines in parallel and wait for all to finish
        public static IEnumerator RunToComplete(this MonoBehaviour mb, params IEnumerator[] ienumerators)
        {
            if (ienumerators != null & ienumerators.Length > 0)
            {
                Coroutine[] coroutines = new Coroutine[ienumerators.Length];
                for (int i = 0; i < ienumerators.Length; i++)
                    coroutines[i] = mb.StartCoroutine(ienumerators[i]);
                for (int i = 0; i < coroutines.Length; i++)
                    yield return coroutines[i];
            }
            else
                yield return null;
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