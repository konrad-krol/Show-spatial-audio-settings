using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Audio;


namespace Audio_Settings
{
    class Audio_Codec
    {
        private readonly static string WindowsSonic = SpatialAudioFormatSubtype.WindowsSonic;
        private readonly static string DolbyAtmosForHeadphones = SpatialAudioFormatSubtype.DolbyAtmosForHeadphones;

        private static SpatialAudioDeviceConfiguration SpatialAudioConfiguration { get; set; }

        private static string FindSupportedCodec(string IdDevices)
        {
            string supportedCodec = "";
            SpatialAudioConfiguration = SpatialAudioDeviceConfiguration.GetForDeviceId(IdDevices);
            if (SpatialAudioConfiguration.IsSpatialAudioSupported)
            {
                string activeCodec = SpatialAudioConfiguration.ActiveSpatialAudioFormat;
                if (activeCodec == WindowsSonic)
                {
                    supportedCodec = "Windows Sonic for Headphones";
                }
                else if (activeCodec == DolbyAtmosForHeadphones)
                {
                    supportedCodec = "Dolby Atmos for Headphones";
                }
                else
                {
                    supportedCodec = "Supported";
                }
            }
            else
            {
                supportedCodec = "Not supported";
            }
            return supportedCodec;
        }

        public static string GetSupportedCodec(string IdDevices)
        {
            return FindSupportedCodec(IdDevices);
        }
    }
}
