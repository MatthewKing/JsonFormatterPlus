namespace JsonFormatterPlus.Tests
{
    using System;
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
    }
}
