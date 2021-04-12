using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sample.Infrastructure.Elastic
{
    public static class StringExtensions
    {
        public static string PascalToKebabCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var result = Regex.Replace(
                value,
                "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                "-$1",
                RegexOptions.Compiled)
                .Trim()
                .ToLower();

            return result;
        }
    }
}
