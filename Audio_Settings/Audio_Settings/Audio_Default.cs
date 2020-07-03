using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Audio;
using Windows.Media.Devices;


namespace Audio_Settings
{
    class Audio_Default
    {
        private readonly static string WindowsSonic = SpatialAudioFormatSubtype.WindowsSonic;
        private readonly static string DolbyAtmosForHeadphones = SpatialAudioFormatSubtype.DolbyAtmosForHeadphones;

        private static SpatialAudioDeviceConfiguration SpatialAudioConfiguration { get; set; }

        public static Dictionary<string, string> FindDefaultDevice(Dictionary<string, string> allDevices)
        {
            Dictionary<string, string> defaultDevices = new Dictionary<string, string>();
            string defaultID = MediaDevice.GetDefaultAudioRenderId(AudioDeviceRole.Default);
            SpatialAudioConfiguration = SpatialAudioDeviceConfiguration.GetForDeviceId(defaultID);
            string defaultSupportedCodec = SpatialAudioConfiguration.DefaultSpatialAudioFormat;
            string defaultName = "";
            if (allDevices.TryGetValue(defaultID, out defaultName))
            {
                defaultDevices.Add("ID", defaultID);
                defaultDevices.Add("Name", defaultName);
                
                if (defaultSupportedCodec == WindowsSonic)
                {
                    defaultDevices.Add("Codec", "Supported");
                }
                else if (defaultSupportedCodec == DolbyAtmosForHeadphones)
                {
                    defaultDevices.Add("Codec", "Supported");
                }
                else
                {
                    defaultDevices.Add("Codec", "Supported");
                }
            }
            return defaultDevices;
        }
    }
}
