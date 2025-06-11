namespace MpvNet.Windows;

public static class TTSConfig
{
    public static bool EnableTTS = false;
    public static string SelectedVoice = "";

    public static void Load()
    {
        EnableTTS = Config.GetBool("EnableTTS");
        SelectedVoice = Config.GetString("TTSVoice");
    }

    public static void Save()
    {
        Config.SetBool("EnableTTS", EnableTTS);
        Config.SetString("TTSVoice", SelectedVoice);
    }
}
