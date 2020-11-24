using Newtonsoft.Json;
using System;
using System.IO;

namespace Assets.Scripts
{
    /// <summary>
    /// This class saves other classes to json file
    /// </summary>
    public static class Serializer
    {
        public static T LoadFromFile<T>(string filePath) where T : class
        {
            if (!IsPathValid(filePath))
                return null;

            string json = File.ReadAllText(filePath);
            if (String.IsNullOrEmpty(json))
                return null;

            return JsonConvert.DeserializeObject<T>(json);
        }

        private static bool IsPathValid(string filePath)
        {
            Guard.ThrowIfStringIsNull(filePath, "Can't load file, path is null");
            if (!File.Exists(filePath))
                return false;

            return true;
        }

        /// <summary>
        /// Save any class to file. This is not done yet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObject"></param>
        /// <param name="savePath"></param>
        /// <param name="overwriteExisting"></param>
        public static void SaveToFile<T>(T jsonObject, string savePath, bool overwriteExisting = true) where T : class
        {
            Guard.ThrowIfNull(savePath, "Can't save file, save path is null", "savePath");
            CreateDirIfNotFound(savePath);
            string json = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

            bool keepOriginal = !overwriteExisting;
            StreamWriter serialize = new StreamWriter(savePath, keepOriginal);
            serialize.Write(json);
            serialize.Close();
        }

        private static void CreateDirIfNotFound(string dir)
        {
            FileInfo f = new FileInfo(dir);
            Directory.CreateDirectory(f.Directory.FullName);
        }
    }
}
