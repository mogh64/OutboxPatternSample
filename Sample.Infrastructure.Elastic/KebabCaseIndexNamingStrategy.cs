using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Elastic
{
    public class KebabCaseIndexNamingStrategy : IIndexNameStrategy
    {
        public KebabCaseIndexNamingStrategy()
        {

        }

        public string GetIndexName(Type type)
        {
            return type.Name.PascalToKebabCase();
        }
    }
}
