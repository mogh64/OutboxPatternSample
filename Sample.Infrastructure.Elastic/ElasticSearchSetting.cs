using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Infrastructure.Elastic
{
    public class ElasticSearchSetting
    {
        const char nodeSplitter = ';';

        public ElasticSearchSetting(IOptions<ElasticSearchSettingOption> options)
        {
            var nodeList = new List<Uri>();

            if (string.IsNullOrWhiteSpace(options.Value.Nodes))
            {
                return;
            }

            if (options.Value.Nodes.Contains(nodeSplitter))
            {
                var uris = options.Value.Nodes.Split(';').ToList();
                if (uris != null && uris.Count > 0)
                {
                    foreach (var uri in uris)
                    {
                        if (!string.IsNullOrWhiteSpace(uri))
                        {
                            nodeList.Add(new Uri(uri));
                        }
                    }
                }
            }
            else
            {
                nodeList.Add(new Uri(options.Value.Nodes));
            }

            Nodes = nodeList;
            Enabled = options.Value.Enabled;
        }

        public IReadOnlyList<Uri> Nodes { get; private set; }
        public bool Enabled { get; private set; }
    }
}
