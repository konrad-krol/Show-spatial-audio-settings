using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Audio;
using Windows.Devices.Enumeration;

namespace Audio_Settings
{
    class Audio_Devices
    {

        private static Dictionary<string, string> audioDevices = new Dictionary<string, string>();

        private static SpatialAudioDeviceConfiguration SpatialAudioConfiguration { get; set; }

        public async static void FindAudioDevices()
        {
            audioDevices.Clear();
            var getDevices = await DeviceInformation.FindAllAsync(DeviceClass.AudioRender);
            foreach (var getDevice in getDevices)
            {
                audioDevices.Add(getDevice.Id, getDevice.Name);
            }
            
        }
        public static Dictionary<string, string> GetAudioDevices()
        {
            return audioDevices;
        }
        public static Dictionary<string, string> GetDefaultDevice()
        {
            return Audio_Default.FindDefaultDevice(audioDevices);
        }


    }

}
