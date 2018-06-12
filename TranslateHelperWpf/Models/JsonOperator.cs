using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TranslateHelperWpf.Models
{
    static class JsonOperator
    {
        public static void ReadFile(string filename, out JsonProperty result)
        {
            result = new JsonProperty() { IsRoot = true };
            bool isObjectProperty = false;
            string txt = File.ReadAllText(filename);
            JsonProperty p = new JsonProperty();
            JsonTextReader reader = new JsonTextReader(new StringReader(txt));
            List<JsonProperty> currentList = p.Values;
            int lvl = 0;
            try
            {
                while (reader.Read())
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.StartObject:
                            {
                                lvl++;
                                if (lvl <= 1)
                                {
                                    p = new JsonProperty() { Parent = result };
                                    result.Values.Add(p);
                                    currentList = result.Values;
                                }
                                else
                                {
                                    p = new JsonProperty { Parent = p };
                                    currentList = p.Parent.Values;
                                    currentList.Add(p);
                                }
                                isObjectProperty = true;

                            }
                            break;
                        case JsonToken.EndObject:
                            {
                                lvl--;
                                p = p.Parent;
                                currentList = p.Parent.Values;
                            }
                            break;
                        case JsonToken.String:
                            {
                                p.Value = reader.Value.ToString();
                            }
                            break;
                        case JsonToken.PropertyName:
                            {
                                if (isObjectProperty)
                                {
                                    p.Name = reader.Value.ToString();
                                    isObjectProperty = false;
                                }
                                else
                                {
                                    p = new JsonProperty { Parent = p.Parent, Name = reader.Value.ToString() };
                                    currentList.Add(p);
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void WriteFile(string filename, JsonProperty prop)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                WriteProperty(writer, prop);
            }
            File.WriteAllText(filename, sw.ToString());
        }
        static void WriteProperty(JsonWriter writer, JsonProperty prop)
        {
            if (prop.Name != "")
                writer.WritePropertyName(prop.Name);
            if (prop.Value != "")
                writer.WriteValue(prop.Value);
            else
            {
                if (prop.Values.Count > 0)
                {
                    writer.WriteStartObject();
                    foreach (JsonProperty p in prop.Values)
                    {
                        WriteProperty(writer, p);
                    }
                    writer.WriteEndObject();
                }
            }
        }
        public static Dictionary<string, JsonProperty> GetFlatList(JsonProperty prop)
        {
            Dictionary<string, JsonProperty> result = new Dictionary<string, JsonProperty>();
            FillListWithElements(prop, result);
            return result;
        }
        static void FillListWithElements(JsonProperty prop, Dictionary<string, JsonProperty> result)
        {
            if (prop.IsRoot != true)
            {
                string str = prop.Path;
                if (result.ContainsKey(str) == false)
                    result.Add(str, prop);
                else
                    Debug.WriteLine("Error - only happens if multiple keys");
            }
            foreach (JsonProperty p in prop.Values)
            {
                FillListWithElements(p, result);
            }
        }
    }
}
