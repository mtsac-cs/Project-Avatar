using System;
using System.IO;
using System.Text;

namespace Assets.Scripts
{
    public class JsonFile
    {
        private string filePath;

        public JsonFile(string filePath)
        {
            this.filePath = filePath;
        }


        //Originally from: https://github.com/SubnauticaModding/SMLHelper/blob/master/SMLHelper/Utility/JsonUtils.cs
        //Modified for our purposes
        /*public void Load<T>(T jsonObject, string path = null, bool createFileIfNotExist = true,
            params JsonConverter[] jsonConverters) where T : class
        {
            if (!createFileIfNotExist)
                Guard.ThrowIfPathIsNull(path);

            if (File.Exists(path))
            {
                PopulateJsonObject(jsonObject, path, jsonConverters);
            }
            else if (createFileIfNotExist)
            {
                Save(jsonObject, path, jsonConverters);
            }
        }

        private void PopulateJsonObject<T>(T jsonObject, string path, params JsonConverter[] jsonConverters)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                Converters = jsonConverters
            };

            string serializedJson = File.ReadAllText(path);
            JsonConvert.PopulateObject(
                serializedJson, jsonObject, jsonSerializerSettings
            );
        }

        //Originally from: https://github.com/SubnauticaModding/SMLHelper/blob/master/SMLHelper/Utility/JsonUtils.cs
        //Modified for our purposes
        public void Save<T>(T jsonObject, string path = null, params JsonConverter[] jsonConverters) where T : class
        {
            Guard.ThrowIfPathIsNull(path);

            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);
            var jsonTextWriter = new JsonTextWriter(stringWriter)
            {
                Indentation = 4,
                Formatting = Formatting.Indented
            };

            using (jsonTextWriter)
            {
                var jsonSerializer = new JsonSerializer();
                foreach (var jsonConverter in jsonConverters)
                    jsonSerializer.Converters.Add(jsonConverter);

                jsonSerializer.Serialize(jsonTextWriter, jsonObject);
            }

            var fileInfo = new FileInfo(path);
            fileInfo.Directory.Create();
            File.WriteAllText(path, stringBuilder.ToString());
        }*/
    }
}
