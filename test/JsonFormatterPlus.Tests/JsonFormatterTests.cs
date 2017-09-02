namespace JsonFormatterPlus.Tests
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public sealed class JsonFormatterTests
    {
        #region Example data.

        // Source data from JSON.ORG: http://json.org/example.html
        // Formatted using JSONLint's formatter: http://jsonlint.com/

        private static readonly string example1Minified =
            "{\"glossary\":{\"title\":\"example glossary\",\"GlossDiv\":{\"title\":\"S\",\"GlossList\":{\"GlossEntry\":{\"ID\":\"SGML\",\"SortAs\":\"SGML\",\"GlossTerm\":\"Standard Generalized Markup Language\",\"Acronym\":\"SGML\",\"Abbrev\":\"ISO 8879:1986\",\"GlossDef\":{\"para\":\"A meta-markup language,used to create markup languages such as DocBook.\",\"GlossSeeAlso\":[\"GML\",\"XML\"]},\"GlossSee\":\"markup\"}}}}}";

        private static readonly string example1Formatted =
            "{" + Environment.NewLine +
            "    \"glossary\": {" + Environment.NewLine +
            "        \"title\": \"example glossary\"," + Environment.NewLine +
            "        \"GlossDiv\": {" + Environment.NewLine +
            "            \"title\": \"S\"," + Environment.NewLine +
            "            \"GlossList\": {" + Environment.NewLine +
            "                \"GlossEntry\": {" + Environment.NewLine +
            "                    \"ID\": \"SGML\"," + Environment.NewLine +
            "                    \"SortAs\": \"SGML\"," + Environment.NewLine +
            "                    \"GlossTerm\": \"Standard Generalized Markup Language\"," + Environment.NewLine +
            "                    \"Acronym\": \"SGML\"," + Environment.NewLine +
            "                    \"Abbrev\": \"ISO 8879:1986\"," + Environment.NewLine +
            "                    \"GlossDef\": {" + Environment.NewLine +
            "                        \"para\": \"A meta-markup language,used to create markup languages such as DocBook.\"," + Environment.NewLine +
            "                        \"GlossSeeAlso\": [" + Environment.NewLine +
            "                            \"GML\"," + Environment.NewLine +
            "                            \"XML\"" + Environment.NewLine +
            "                        ]" + Environment.NewLine +
            "                    }," + Environment.NewLine +
            "                    \"GlossSee\": \"markup\"" + Environment.NewLine +
            "                }" + Environment.NewLine +
            "            }" + Environment.NewLine +
            "        }" + Environment.NewLine +
            "    }" + Environment.NewLine +
            "}";

        private static readonly string example2Minified =
            "{\"menu\":{\"id\":\"file\",\"value\":\"File\",\"popup\":{\"menuitem\":[{\"value\":\"New\",\"onclick\":\"CreateNewDoc()\"},{\"value\":\"Open\",\"onclick\":\"OpenDoc()\"},{\"value\":\"Close\",\"onclick\":\"CloseDoc()\"}]}}}";

        private static readonly string example2Formatted =
            "{" + Environment.NewLine +
            "    \"menu\": {" + Environment.NewLine +
            "        \"id\": \"file\"," + Environment.NewLine +
            "        \"value\": \"File\"," + Environment.NewLine +
            "        \"popup\": {" + Environment.NewLine +
            "            \"menuitem\": [" + Environment.NewLine +
            "                {" + Environment.NewLine +
            "                    \"value\": \"New\"," + Environment.NewLine +
            "                    \"onclick\": \"CreateNewDoc()\"" + Environment.NewLine +
            "                }," + Environment.NewLine +
            "                {" + Environment.NewLine +
            "                    \"value\": \"Open\"," + Environment.NewLine +
            "                    \"onclick\": \"OpenDoc()\"" + Environment.NewLine +
            "                }," + Environment.NewLine +
            "                {" + Environment.NewLine +
            "                    \"value\": \"Close\"," + Environment.NewLine +
            "                    \"onclick\": \"CloseDoc()\"" + Environment.NewLine +
            "                }" + Environment.NewLine +
            "            ]" + Environment.NewLine +
            "        }" + Environment.NewLine +
            "    }" + Environment.NewLine +
            "}";

        private static readonly string example3Minified =
            "{\"widget\":{\"debug\":\"on\",\"window\":{\"title\":\"Sample Konfabulator Widget\",\"name\":\"main_window\",\"width\":500,\"height\":500},\"image\":{\"src\":\"Images/Sun.png\",\"name\":\"sun1\",\"hOffset\":250,\"vOffset\":250,\"alignment\":\"center\"},\"text\":{\"data\":\"Click Here\",\"size\":36,\"style\":\"bold\",\"name\":\"text1\",\"hOffset\":250,\"vOffset\":100,\"alignment\":\"center\",\"onMouseUp\":\"sun1.opacity = (sun1.opacity / 100) * 90;\"}}}";

        private static readonly string example3Formatted =
            "{" + Environment.NewLine +
            "    \"widget\": {" + Environment.NewLine +
            "        \"debug\": \"on\"," + Environment.NewLine +
            "        \"window\": {" + Environment.NewLine +
            "            \"title\": \"Sample Konfabulator Widget\"," + Environment.NewLine +
            "            \"name\": \"main_window\"," + Environment.NewLine +
            "            \"width\": 500," + Environment.NewLine +
            "            \"height\": 500" + Environment.NewLine +
            "        }," + Environment.NewLine +
            "        \"image\": {" + Environment.NewLine +
            "            \"src\": \"Images/Sun.png\"," + Environment.NewLine +
            "            \"name\": \"sun1\"," + Environment.NewLine +
            "            \"hOffset\": 250," + Environment.NewLine +
            "            \"vOffset\": 250," + Environment.NewLine +
            "            \"alignment\": \"center\"" + Environment.NewLine +
            "        }," + Environment.NewLine +
            "        \"text\": {" + Environment.NewLine +
            "            \"data\": \"Click Here\"," + Environment.NewLine +
            "            \"size\": 36," + Environment.NewLine +
            "            \"style\": \"bold\"," + Environment.NewLine +
            "            \"name\": \"text1\"," + Environment.NewLine +
            "            \"hOffset\": 250," + Environment.NewLine +
            "            \"vOffset\": 100," + Environment.NewLine +
            "            \"alignment\": \"center\"," + Environment.NewLine +
            "            \"onMouseUp\": \"sun1.opacity = (sun1.opacity / 100) * 90;\"" + Environment.NewLine +
            "        }" + Environment.NewLine +
            "    }" + Environment.NewLine +
            "}";

        private static readonly string example4Minified =
            "{\"menu\":{\"header\":\"SVG Viewer\",\"items\":[{\"id\":\"Open\"},{\"id\":\"OpenNew\",\"label\":\"Open New\"},null,{\"id\":\"ZoomIn\",\"label\":\"Zoom In\"},{\"id\":\"ZoomOut\",\"label\":\"Zoom Out\"},{\"id\":\"OriginalView\",\"label\":\"Original View\"},null,{\"id\":\"Quality\"},{\"id\":\"Pause\"},{\"id\":\"Mute\"},null,{\"id\":\"Find\",\"label\":\"Find...\"},{\"id\":\"FindAgain\",\"label\":\"Find Again\"},{\"id\":\"Copy\"},{\"id\":\"CopyAgain\",\"label\":\"Copy Again\"},{\"id\":\"CopySVG\",\"label\":\"Copy SVG\"},{\"id\":\"ViewSVG\",\"label\":\"View SVG\"},{\"id\":\"ViewSource\",\"label\":\"View Source\"},{\"id\":\"SaveAs\",\"label\":\"Save As\"},null,{\"id\":\"Help\"},{\"id\":\"About\",\"label\":\"About Adobe CVG Viewer...\"}]}}";

        private static readonly string example4Formatted =
            "{" + Environment.NewLine +
            "    \"menu\": {" + Environment.NewLine +
            "        \"header\": \"SVG Viewer\"," + Environment.NewLine +
            "        \"items\": [" + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"Open\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"OpenNew\"," + Environment.NewLine +
            "                \"label\": \"Open New\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            null," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"ZoomIn\"," + Environment.NewLine +
            "                \"label\": \"Zoom In\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"ZoomOut\"," + Environment.NewLine +
            "                \"label\": \"Zoom Out\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"OriginalView\"," + Environment.NewLine +
            "                \"label\": \"Original View\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            null," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"Quality\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"Pause\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"Mute\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            null," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"Find\"," + Environment.NewLine +
            "                \"label\": \"Find...\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"FindAgain\"," + Environment.NewLine +
            "                \"label\": \"Find Again\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"Copy\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"CopyAgain\"," + Environment.NewLine +
            "                \"label\": \"Copy Again\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"CopySVG\"," + Environment.NewLine +
            "                \"label\": \"Copy SVG\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"ViewSVG\"," + Environment.NewLine +
            "                \"label\": \"View SVG\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"ViewSource\"," + Environment.NewLine +
            "                \"label\": \"View Source\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"SaveAs\"," + Environment.NewLine +
            "                \"label\": \"Save As\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            null," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"Help\"" + Environment.NewLine +
            "            }," + Environment.NewLine +
            "            {" + Environment.NewLine +
            "                \"id\": \"About\"," + Environment.NewLine +
            "                \"label\": \"About Adobe CVG Viewer...\"" + Environment.NewLine +
            "            }" + Environment.NewLine +
            "        ]" + Environment.NewLine +
            "    }" + Environment.NewLine +
            "}";

        #endregion

        [Fact]
        public void Format_JsonIsNull_ThrowsArgumentNullException()
        {
            Action act = () => JsonFormatter.Format(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Format_JsonIsEmptyString_ReturnsEmptyString()
        {
            JsonFormatter.Format(String.Empty).Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(Format_JsonIsValidButUnformatted_ReturnsFormattedJson_TestCaseData))]
        public void Format_JsonIsValidButUnformatted_ReturnsFormattedJson(string json, string formattedJson)
        {
            JsonFormatter.Format(json).Should().Be(formattedJson);
        }

        private static IEnumerable<object[]> Format_JsonIsValidButUnformatted_ReturnsFormattedJson_TestCaseData()
        {
            yield return new object[] { example1Minified, example1Formatted };
            yield return new object[] { example2Minified, example2Formatted };
            yield return new object[] { example3Minified, example3Formatted };
            yield return new object[] { example4Minified, example4Formatted };
        }

        [Fact]
        public void Minify_JsonIsNull_ThrowsArgumentNullException()
        {
            Action act = () => JsonFormatter.Minify(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Minify_JsonIsEmpty_ReturnsEmptyString()
        {
            JsonFormatter.Minify(String.Empty).Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(Minify_JsonIsValidButNotMinified_ReturnsMinifiedJson_TestCaseData))]
        public void Minify_JsonIsValidButNotMinified_ReturnsMinifiedJson(string json, string minifiedJson)
        {
            JsonFormatter.Minify(json).Should().Be(minifiedJson);
        }

        private static IEnumerable<object> Minify_JsonIsValidButNotMinified_ReturnsMinifiedJson_TestCaseData()
        {
            yield return new object[] { example1Formatted, example1Minified };
            yield return new object[] { example2Formatted, example2Minified };
            yield return new object[] { example3Formatted, example3Minified };
            yield return new object[] { example4Formatted, example4Minified };
        }
    }
}
