using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Elastic
{
    public class ElasticSearchSettingOption
    {
        public const string SettingName = "ElasticSearchSettings";
        public bool Enabled { get; set; }
        public string Nodes { get; set; }
    }
}
