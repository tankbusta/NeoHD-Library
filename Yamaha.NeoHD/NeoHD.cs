namespace Yamaha.NeoHD
{
    using System;
    using System.Text;

    public class NeoHD
    {
        /* Variables */
        public Int32 volume_limit { get; set; }
        public string neohd_reciever_ip { get; set; }
        public bool power_status { get; set; }
        public bool mute_status { get; set; }

        /* Classes */
        private Http http_helper = new Http();

        public NeoHD(string ip, Int32 vol_limit)
        {
            this.neohd_reciever_ip = ip;
            this.volume_limit = vol_limit;
        }

        public bool SetVolume(Int32 volume_level)
        {
            string command = @"<YAMAHA_AV cmd=""PUT""><Main_Zone><Vol><Lvl>" + volume_level + "</Lvl></Vol></Main_Zone></YAMAHA_AV>";
            try
            {
                /* We don't want to blow out speakers! */
                if (volume_level > volume_limit)
                {
                    return false;
                }
                else
                {
                    if (http_helper.HttpPost("http://" + neohd_reciever_ip + "/YamahaRemoteControl/ctrl", command) == true)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Error setting volume");
            }
            return false;
        }

        public bool Mute()
        {
            return true;
        }
    }
}
