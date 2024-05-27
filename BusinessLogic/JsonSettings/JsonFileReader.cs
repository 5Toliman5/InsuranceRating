using BusinessLogic.Prorating;
using System.Text.Json;

namespace ConsoleApp.JsonFile
{
    public class JsonFileReader : IJsonFileReader<Settings>
    {
        public Settings ReadJsonFile(string path)
        {
            var json = File.ReadAllText(path);
            if (string.IsNullOrEmpty(json)) return null;
            return JsonSerializer.Deserialize<Settings>(json);
        }
    }
}
