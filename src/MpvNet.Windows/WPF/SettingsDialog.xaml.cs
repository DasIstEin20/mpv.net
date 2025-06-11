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
        EnableTTS = TTSConfig.EnableTTS;
        SelectedVoice = string.IsNullOrEmpty(TTSConfig.SelectedVoice) ? Voices.FirstOrDefault() ?? "" : TTSConfig.SelectedVoice;
        DataContext = this;
    }

    void OK_Click(object sender, RoutedEventArgs e)
    {
        TTSConfig.EnableTTS = EnableTTS;
        if (!string.IsNullOrEmpty(SelectedVoice))
            TTSConfig.SelectedVoice = SelectedVoice;
        TTSManager.Init();
        DialogResult = true;
        Close();
    }

    public Theme? Theme => Theme.Current;
}
