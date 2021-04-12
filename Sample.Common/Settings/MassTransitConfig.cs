using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Common.Settings
{
    public class MassTransitConfig
    {
        public const string SettingName = "MassTransitConfig";
        public string Host { get; set; }
        public string VirtualHost { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool SSLActive { get; set; }
        public string EndPoint { get; set; }
        public string SSLThumbprint { get; set; }

    }
}
