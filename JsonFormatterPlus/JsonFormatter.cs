namespace JsonFormatterPlus
{
    using System;
    using System.Text.RegularExpressions;
    using JsonFormatterPlus.Internals;

    /// <summary>
    /// Provides JSON formatting functionality.
    /// </summary>
    public static class JsonFormatter
    {
        /// <summary>
        /// Returns a 'pretty printed' version of the specified JSON string, formatted for human
        /// consumption.
        /// </summary>
        /// <param name="json">A valid JSON string.</param>
        /// <returns>A 'pretty printed' version of the specified JSON string.</returns>
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

        /// <summary>
        /// Returns a 'minified' version of the specified JSON string, stripped of all 
        /// non-essential characters.
        /// </summary>
        /// <param name="json">A valid JSON string.</param>
        /// <returns>A 'minified' version of the specified JSON string.</returns>
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
