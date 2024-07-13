using UnityEngine;

using System.IO;

namespace RR.Serialization
{
    public static class JsonWrapper
    {
        public static bool ReadJsonArray<T>(string path, out T[] json)
        {
            try
            {
                string jsonStr = File.ReadAllText(path);
                json = JsonUtility.FromJson<JsonArray<T>>(jsonStr).items;
                return true;
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
                json = new T[0];
                return false;
            }
        }

        public static bool OverwriteJsonArray<T>(string path, T[] newJson)
        {
            try
            {
                string oldJsonStr = File.ReadAllText(path);
                string newJsonStr = JsonUtility.ToJson(new JsonArray<T>(){ items = newJson }, true);
                JsonUtility.FromJsonOverwrite(oldJsonStr, newJsonStr);
                Debug.Log(newJsonStr);
                File.WriteAllText(path, newJsonStr);
                return true;
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }

        [System.Serializable]
        public class JsonArray<T>
        {
            public T[] items;
        }
    }
}
