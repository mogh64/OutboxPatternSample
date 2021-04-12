using Nest;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sample.Infrastructure.Elastic
{
    public static class NestHelperExtensions
    {
        public static Expression<Func<T, object>> KeywordSuffix<T>
                                                  (this Expression<Func<T, object>> expression)
        {
            return expression.AppendSuffix("keyword");
        }
    }
}
