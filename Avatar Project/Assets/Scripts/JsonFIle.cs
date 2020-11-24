using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Base JSON file for use with serializable data
    /// </summary>
    public class JsonFile
    {
        string fileName;

        public JsonFile(string fileName)
        {
            this.fileName = fileName;
        }

        public void Save<T>(T jsonObject)
        {
            string json = JsonUtility.ToJson(jsonObject, true);
            WriteToFile(json);
        }

        private void WriteToFile(string json)
        {
            string path = GetFilePath();
            Debug.Log(path);
            FileStream fileStream = new FileStream(path, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        private string GetFilePath()
        {
            //string path = Application.persistentDataPath + "/ " + fileName;  //use this during release
            string path = Environment.CurrentDirectory + "/JSON Files/" + fileName;
            return path;
        }


        public void Load<T>(T jsonObject)
        {
            string path = GetFilePath();
            if (!File.Exists(path))
                Save<T>(jsonObject);

            string json = ReadFromFile();
            JsonUtility.FromJsonOverwrite(json, jsonObject);
        }

        private string ReadFromFile()
        {
            string json = null;
            string path = GetFilePath();
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    json = reader.ReadToEnd();
                }
            }

            return json;
        }
    }
}
