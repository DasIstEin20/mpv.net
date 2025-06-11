using System.Text.Json;

namespace MpvNet;

static class Config
{
    static readonly string ConfigPath = Player.ConfigFolder + "Config.json";
    static Dictionary<string, JsonElement> _values = new();

    public static void Load()
    {
        try
        {
            if (File.Exists(ConfigPath))
                _values = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(File.ReadAllText(ConfigPath)) ?? new();
        }
        catch { _values = new(); }
    }

    public static void Save()
    {
        try
        {
            File.WriteAllText(ConfigPath, JsonSerializer.Serialize(_values, new JsonSerializerOptions { WriteIndented = true }));
        }
        catch { }
    }

    public static bool GetBool(string name)
    {
        if (_values.TryGetValue(name, out var el) && (el.ValueKind == JsonValueKind.True || el.ValueKind == JsonValueKind.False))
            return el.GetBoolean();
        return false;
    }

    public static string GetString(string name)
    {
        if (_values.TryGetValue(name, out var el) && el.ValueKind == JsonValueKind.String)
            return el.GetString() ?? "";
        return "";
    }

    public static void SetBool(string name, bool value)
    {
        _values[name] = JsonDocument.Parse(value ? "true" : "false").RootElement.Clone();
    }

    public static void SetString(string name, string value)
    {
        _values[name] = JsonDocument.Parse(JsonSerializer.Serialize(value)).RootElement.Clone();
    }
}
