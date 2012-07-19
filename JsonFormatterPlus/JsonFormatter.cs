namespace JsonFormatterPlus
{
    using JsonFormatterPlus.Internals;

    public static class JsonFormatter
    {
        public static string Format(string json)
        {
            var context = new JsonFormatterStrategyContext();
            var formatter = new JsonFormatterInternal(context);

            return formatter.Format(json);
        }
    }
}
