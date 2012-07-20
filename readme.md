JsonFormatterPlus
=================

This library provides some simple JSON formatting / pretty printing functionality for .NET.
It is based on Mark Rogers' [JsonPrettyPrinterPlus](http://www.markdavidrogers.com/oxitesample/Blog/json-pretty-printerbeautifier-library-for-net).

### Example

```csharp
string formattedJson = JsonFormatter.Format(unformattedJson);
```

(I told you it was simple!)

### What sets this apart from JsonPrettyPrinterPlus?

Not a lot. Mark's version works very well. However, I wanted to make the project suitable for .NET 2.0, 3.0, and the various client profiles. This meant that the extension methods and the dependency on System.Web.Extensions had to go! 

### License

JsonFormatter is distributed under the MIT license.