using System.Speech.Synthesis;

namespace MpvNet.Windows;

public static class TTSManager
{
    static SpeechSynthesizer synth = new SpeechSynthesizer();
    static string last = "";

    public static void Init()
    {
        if (!string.IsNullOrEmpty(TTSConfig.SelectedVoice))
        {
            try { synth.SelectVoice(TTSConfig.SelectedVoice); } catch { }
        }
    }

    public static void Speak(string text)
    {
        if (TTSConfig.EnableTTS && !string.IsNullOrWhiteSpace(text) && text != last)
        {
            last = text;
            synth.SpeakAsyncCancelAll();
            synth.SpeakAsync(text);
        }
    }

    public static string[] GetInstalledVoices()
    {
        List<string> voices = new List<string>();
        foreach (var v in synth.GetInstalledVoices())
            voices.Add(v.VoiceInfo.Name);
        return voices.ToArray();
    }
}
