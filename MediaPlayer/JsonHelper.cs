using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer
{
    public class JsonHelper
    {
        public static void SaveToJson<T> (BindingList<T> data, string path)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }

        public static BindingList<T> LoadFromJson<T>(string path)
        {
            if(!File.Exists(path))
            {
                return new BindingList<T>();
            }

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<BindingList<T>>(json);
        }

    }


}
