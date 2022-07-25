using UnityEngine;

namespace Assets.Level2.Scripts
{
    public static class SnakeStaticExtensions
    {
        public static Vector3Int ToVector3Int(this Vector3 vector3)
        {
            return Vector3Int.RoundToInt(vector3);
        }
    }
}