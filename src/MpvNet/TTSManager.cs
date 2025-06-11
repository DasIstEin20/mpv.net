using System.Speech.Synthesis;
using System.Collections.Generic;

namespace MpvNet
{
    public static class TTSManager
    {
        static SpeechSynthesizer synth = new SpeechSynthesizer();
        static string last = "";

        public static void Init()
        {
            if (!string.IsNullOrEmpty(Settings.TTSVoice))
                synth.SelectVoice(Settings.TTSVoice);
        }

        public static void Speak(string text)
        {
            if (Settings.EnableTTS && !string.IsNullOrWhiteSpace(text) && text != last)
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
}