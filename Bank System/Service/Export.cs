using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace Bank_System.Service
{
    public class Export
    {
        public void ExportToFile<T>(string path, T obj)
        {

            var directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            var type = obj.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                System.IO.File.WriteAllText($"{path}\\data.txt", $"Имя свойства = {property.Name}, Содержимое свойства = {property.GetValue(obj)}");
            }
        }
    }
}