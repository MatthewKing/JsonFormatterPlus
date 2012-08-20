namespace JsonFormatterPlus.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    internal sealed class JsonFormatterTests
    {
        [Test]
        public void Format_JsonIsNull_ThrowsArgumentNullException()
        {
            const string message = "json should not be null.";
            Assert.That(() => JsonFormatter.Format(null),
                Throws.TypeOf<ArgumentNullException>()
                      .And.Message.Contains(message));
        }

        [Test]
        public void Format_JsonIsEmptyString_ReturnsEmptyString()
        {
            Assert.That(JsonFormatter.Format(String.Empty), Is.Empty);
        }

        [TestCaseSource("ValidJsonTestCaseData")]
        public string Format_JsonIsValidButUnformatted_ReturnsFormattedJson(string json)
        {
            return JsonFormatter.Format(json);
        }

        private static IEnumerable<TestCaseData> ValidJsonTestCaseData()
        {
            // Source data from JSON.ORG: http://json.org/example.html
            // Expected output using JSONLint's formatter: http://jsonlint.com/

            string input1 = "{\"glossary\":{\"title\":\"example glossary\",\"GlossDiv\":{\"title\":\"S\",\"GlossList\":{\"GlossEntry\":{\"ID\":\"SGML\",\"SortAs\":\"SGML\",\"GlossTerm\":\"Standard Generalized Markup Language\",\"Acronym\":\"SGML\",\"Abbrev\":\"ISO 8879:1986\",\"GlossDef\":{\"para\":\"A meta-markup language,used to create markup languages such as DocBook.\",\"GlossSeeAlso\":[\"GML\",\"XML\"]},\"GlossSee\":\"markup\"}}}}}";
            string expectedOutput1 =
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

            string input2 = "{\"menu\":{\"id\":\"file\",\"value\":\"File\",\"popup\":{\"menuitem\":[{\"value\":\"New\",\"onclick\":\"CreateNewDoc()\"},{\"value\":\"Open\",\"onclick\":\"OpenDoc()\"},{\"value\":\"Close\",\"onclick\":\"CloseDoc()\"}]}}}";
            string expectedOutput2 =
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

            yield return new TestCaseData(input1).Returns(expectedOutput1);
            yield return new TestCaseData(input2).Returns(expectedOutput2);
        }

        [Test]
        public void Minify_JsonIsNull_ThrowsArgumentNullException()
        {
            const string message = "json should not be null.";
            Assert.That(() => JsonFormatter.Format(null),
                Throws.TypeOf<ArgumentNullException>()
                      .And.Message.Contains(message));
        }

        [Test]
        public void Minify_JsonIsEmpty_ReturnsEmptyString()
        {
            Assert.That(JsonFormatter.Minify(String.Empty), Is.Empty);
        }

        [TestCaseSource("MinifyTestCaseData")]
        public string Minify_JsonIsValidButNotMinified_ReturnsMinifiedJson(string json)
        {
            return JsonFormatter.Minify(json);
        }

        private static IEnumerable<TestCaseData> MinifyTestCaseData()
        {
            string input1 =
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
                "                        \"para\": \"A meta-markup language, used to create markup languages such as DocBook.\"," + Environment.NewLine +
                "                        \"GlossSeeAlso\": [\"GML\", \"XML\"]" + Environment.NewLine +
                "                    }," + Environment.NewLine +
                "                    \"GlossSee\": \"markup\"" + Environment.NewLine +
                "                }" + Environment.NewLine +
                "            }" + Environment.NewLine +
                "        }" + Environment.NewLine +
                "    }" + Environment.NewLine +
                "}";
            string expectedOutput1 = "{\"glossary\":{\"title\":\"example glossary\",\"GlossDiv\":{\"title\":\"S\",\"GlossList\":{\"GlossEntry\":{\"ID\":\"SGML\",\"SortAs\":\"SGML\",\"GlossTerm\":\"Standard Generalized Markup Language\",\"Acronym\":\"SGML\",\"Abbrev\":\"ISO 8879:1986\",\"GlossDef\":{\"para\":\"A meta-markup language, used to create markup languages such as DocBook.\",\"GlossSeeAlso\":[\"GML\",\"XML\"]},\"GlossSee\":\"markup\"}}}}}";

            string input2 =
                "{\"menu\": {" + Environment.NewLine +
                "  \"id\": \"file\"," + Environment.NewLine +
                "  \"value\": \"File\"," + Environment.NewLine +
                "  \"popup\": {" + Environment.NewLine +
                "    \"menuitem\": [" + Environment.NewLine +
                "      {\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"}," + Environment.NewLine +
                "      {\"value\": \"Open\", \"onclick\": \"OpenDoc()\"}," + Environment.NewLine +
                "      {\"value\": \"Close\", \"onclick\": \"CloseDoc()\"}" + Environment.NewLine +
                "    ]" + Environment.NewLine +
                "  }" + Environment.NewLine +
                "}}";
            string expectedOutput2 = "{\"menu\":{\"id\":\"file\",\"value\":\"File\",\"popup\":{\"menuitem\":[{\"value\":\"New\",\"onclick\":\"CreateNewDoc()\"},{\"value\":\"Open\",\"onclick\":\"OpenDoc()\"},{\"value\":\"Close\",\"onclick\":\"CloseDoc()\"}]}}}";

            yield return new TestCaseData(input1).Returns(expectedOutput1);
            yield return new TestCaseData(input2).Returns(expectedOutput2);
        }
    }
}
