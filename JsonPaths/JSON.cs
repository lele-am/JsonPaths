using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JsonPaths
{
    public class JSON
    {
        private Dictionary<string, object> jsonData;

        public JSON(string filepath, string encoding = "utf-8")
        {
            if (!File.Exists(filepath))
            {
                jsonData = new Dictionary<string, object>();
            }
            else
            {
                var data = File.ReadAllText(filepath, Encoding.GetEncoding(encoding));
                jsonData = JsonSerializer.Deserialize<Dictionary<string, object>>(data);
            }
        }

        public void Save(string filepath, string encoding = "utf-8")
        {
            var data = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filepath, data, Encoding.GetEncoding(encoding));
        }

        public bool PathExists(string path)
        {
            var keys = path.Split('/');
            object current = jsonData;

            foreach (var key in keys)
            {
                if (current is Dictionary<string, object> dict && dict.ContainsKey(key))
                {
                    current = dict[key];
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public object Value(string path)
        {
            var keys = path.Split('/');
            object current = jsonData;

            foreach (var key in keys)
            {
                if (current is Dictionary<string, object> dict && dict.ContainsKey(key))
                {
                    current = dict[key];
                }
                else
                {
                    return null;
                }
            }

            return current;
        }

        public void SetKey(string path, string value = "{}")
        {
            var keys = path.Split('/');
            var current = jsonData;

            for (int i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                if (i == keys.Length - 1)
                {
                    current[key] = JsonSerializer.Deserialize<object>(value);
                }
                else
                {
                    if (!current.ContainsKey(key))
                    {
                        current[key] = new Dictionary<string, object>();
                    }
                    current = current[key] as Dictionary<string, object>;
                }
            }
        }

        public bool DeleteKey(string path)
        {
            var keys = path.Split('/');
            var current = jsonData;

            for (int i = 0; i < keys.Length - 1; i++)
            {
                var key = keys[i];
                if (!current.ContainsKey(key))
                {
                    return false;
                }
                current = current[key] as Dictionary<string, object>;
            }

            var lastKey = keys[keys.Length - 1];
            if (!current.ContainsKey(lastKey))
            {
                return false;
            }

            current.Remove(lastKey);
            return true;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this.jsonData, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
