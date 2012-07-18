JsonFormatterPlus
=================

This library provides some simple JSON formatting / pretty printing functionality for .NET.
It is based on Mark Rogers' [JsonPrettyPrinterPlus](http://www.markdavidrogers.com/oxitesample/Blog/json-pretty-printerbeautifier-library-for-net).

Example
-------

<!-- {% examplecode csharp %} -->
    string formattedJson = JsonFormatter.Format(unformattedJson);
<!-- {% endexamplecode %} -->

(I told you it was simple!)

License
-------
JsonFormatter is distributed under the MIT license.