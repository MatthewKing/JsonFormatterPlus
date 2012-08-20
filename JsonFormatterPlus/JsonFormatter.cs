namespace JsonFormatterPlus
{
    using System;
    using System.Text.RegularExpressions;
    using JsonFormatterPlus.Internals;

    public static class JsonFormatter
    {
        public static string Format(string json)
        {
            if (json == null)
            {
                throw new ArgumentNullException("json should not be null.");
            }

            var context = new JsonFormatterStrategyContext();
            var formatter = new JsonFormatterInternal(context);

            return formatter.Format(json);
        }

        public static string Minify(string json)
        {
            if (json == null)
            {
                throw new ArgumentNullException("json should not be null.");
            }

            return Regex.Replace(json, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
        }
    }
}
