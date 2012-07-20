namespace JsonFormatterPlus
{
    using System;
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
    }
}
