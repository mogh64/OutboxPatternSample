using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Elastic
{
    public interface IIndexNameStrategy
    {
        string GetIndexName(Type type);
    }
}
