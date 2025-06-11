// Dodaj to do Settings.cs

public static bool EnableTTS = false;
public static string TTSVoice = "";

public static void LoadTTS()
{
    EnableTTS = Config.GetBool(nameof(EnableTTS));
    TTSVoice = Config.GetString(nameof(TTSVoice));
}

public static void SaveTTS()
{
    Config.SetBool(nameof(EnableTTS), EnableTTS);
    Config.SetString(nameof(TTSVoice), TTSVoice);
}