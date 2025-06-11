using System.Speech.Synthesis;

namespace MpvNet.Windows;

public static class TTSHelper
{
    static SpeechSynthesizer synth = new SpeechSynthesizer();

    public static void Speak(string text)
    {
        synth.SpeakAsync(text);
    }
}
