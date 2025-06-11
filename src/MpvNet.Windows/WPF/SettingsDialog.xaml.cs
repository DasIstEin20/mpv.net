using System.Linq;
using System.Windows;

namespace MpvNet.Windows.WPF;

public partial class SettingsDialog : Window
{
    public string[] Voices { get; }
    public bool EnableTTS { get; set; }
    public string SelectedVoice { get; set; }

    public SettingsDialog()
    {
        InitializeComponent();
        Voices = TTSManager.GetInstalledVoices();
        EnableTTS = Settings.EnableTTS;
        SelectedVoice = string.IsNullOrEmpty(Settings.TTSVoice) ? Voices.FirstOrDefault() ?? "" : Settings.TTSVoice;
        DataContext = this;
    }

    void OK_Click(object sender, RoutedEventArgs e)
    {
        Settings.EnableTTS = EnableTTS;
        if (!string.IsNullOrEmpty(SelectedVoice))
            Settings.TTSVoice = SelectedVoice;
        TTSManager.Init();
        DialogResult = true;
        Close();
    }

    public Theme? Theme => Theme.Current;
}
