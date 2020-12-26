using SheepTools.Extensions;
using System;
using Xunit;

namespace SheepTools.Test.Extensions
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("", true)]
        [InlineData(null, false)]
        [InlineData(" ", false)]
        [InlineData(".", false)]
        public void IsEmpty(string? input, bool expected)
        {
            Assert.Equal(expected, input.IsEmpty());
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("  ", true)]
        [InlineData("\r", true)]
        [InlineData("\n", true)]
        [InlineData("\r\n", true)]
        [InlineData("/t", false)]
        [InlineData("\u0000", false)]
        [InlineData("\u001F", false)]
        [InlineData("\u200B", false)]
        [InlineData(".", false)]
        public void IsWhiteSpace(string? input, bool expected)
        {
            Assert.Equal(expected, input.IsWhiteSpace());
        }

        [Theory]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData(" ", true)]
        [InlineData(" true", true)]
        [InlineData("true ", true)]
        [InlineData(" true ", true)]
        [InlineData("tr ue", true)]
        [InlineData("false", false)]
        public void HasWhiteSpaces(string? input, bool expected)
        {
            Assert.Equal(expected, input.HasWhiteSpaces());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("1", "1")]
        [InlineData("123", "123")]
        [InlineData("12345", "12345")]
        [InlineData("123456879", "12345")]
        public void Truncate(string? input, string? expected)
        {
            Assert.Equal(expected, input.Truncate(5));
        }

        [Theory]
        [InlineData("abcde", "edcba")]
        [InlineData("  12 34 ", " 43 21  ")]
        [InlineData("", "")]
        public void ReverseString(string input, string expected)
        {
            Assert.Equal(expected, input.ReverseString());
        }
    }
}
