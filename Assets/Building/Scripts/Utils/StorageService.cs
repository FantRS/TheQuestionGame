using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public static class StorageService
{
    public static void Save(string key, object data, bool isNewtonsoft = false)
    {
        string path = GetBuildPath(key);

        string jsonData = isNewtonsoft ?
            JsonConvert.SerializeObject(data) :
            JsonUtility.ToJson(data);

        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(jsonData);
        }
    }

    public static T Load<T>(string key, bool isNewtonsoft = false)
    {
        string path = GetBuildPath(key);
        string jsonData;

        using (var fileStream = new StreamReader(path))
        {
            jsonData = fileStream.ReadToEnd();

            var data = isNewtonsoft ?
                JsonConvert.DeserializeObject<T>(jsonData) :
                JsonUtility.FromJson<T>(jsonData);

            return data;
        }
    }

    private static string GetBuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}