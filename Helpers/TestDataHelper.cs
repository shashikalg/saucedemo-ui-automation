using System;
using System.Text.Json;

namespace saucedemo_ui_automation.Helpers
{
    public static class TestDataHelper
    {

        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static List<T> LoadListFromJson<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json, _options)!;
        }

        public static T LoadObjectFromJson<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json, _options)!;
        }
    }
}