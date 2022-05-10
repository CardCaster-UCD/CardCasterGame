using UnityEngine;

namespace Utilities
{
    public static class Extensions
    {
        public static Vector3 ToVector2(this Vector3 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }
    }
}