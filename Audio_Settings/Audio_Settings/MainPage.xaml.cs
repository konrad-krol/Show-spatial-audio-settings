using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Audio_Settings
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Audio_Devices.FindAudioDevices();
        }

        private void GetAudioDevices()
        {
            Dictionary<string, string> audioDevices = new Dictionary<string, string>();
            audioDevices = Audio_Devices.GetAudioDevices();
            List_AllDevices.ItemsSource = audioDevices;
            GetDefaultDevices();
        }

        private void GetSupportedCodecs()
        {
            var Devices = (KeyValuePair<string, string>)List_AllDevices.SelectedItem;
            string IdDevices = Devices.Key;
            Text_ActiveCodec.Text = Audio_Codec.GetSupportedCodec(IdDevices);
            if (Text_ActiveCodec.Text != "Dolby Atmos for Headphones")
            {
                AudioSettingOpen.Visibility = Visibility.Visible;
            }
            else
            {
                AudioSettingOpen.Visibility = Visibility.Collapsed;
            }
        }
        private void GetDefaultDevices()
        {
            Dictionary<string, string> defaultDevice = new Dictionary<string, string>();
            defaultDevice = Audio_Devices.GetDefaultDevice();
            string defaultName = "";
            defaultDevice.TryGetValue("Name", out defaultName);
            Text_DefaultDevice.Text = defaultName;
            string defaultCodec = "";
            defaultDevice.TryGetValue("Codec", out defaultCodec);
            Text_DefaultCodecAudio.Text = defaultCodec;
        }

        async private void AudioSettingOpen_Click(object sender, RoutedEventArgs e)
        {
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:sound"));
        }

        private void List_AllDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetSupportedCodecs();
        }

        private void FindAudioDevices_Click(object sender, RoutedEventArgs e)
        {
            FindAudioDevices.Visibility = Visibility.Collapsed;
            GetAudioDevices();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
