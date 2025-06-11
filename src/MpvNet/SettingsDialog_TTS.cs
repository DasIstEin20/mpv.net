// Dodaj to do SettingsDialog.cs w metodzie GUI init (np. CreateControls)

CheckBox ttsCheckBox = AddCheckBox("Enable Subtitle TTS", Settings.EnableTTS, (b) => { Settings.EnableTTS = b; });
ComboBox ttsVoiceBox = AddComboBox("Select Voice", TTSManager.GetInstalledVoices(), Settings.TTSVoice, (v) => { Settings.TTSVoice = v; TTSManager.Init(); });