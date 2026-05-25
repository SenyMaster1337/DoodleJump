using UnityEngine;

namespace Code.Data
{
    public static class DataExtensions
    {
        public static T ToDeserialized<T>(this string json) 
            => JsonUtility.FromJson<T>(json);

        public static string ToJson<T>(this T obj) where T : class
            => JsonUtility.ToJson(obj);
    }
}