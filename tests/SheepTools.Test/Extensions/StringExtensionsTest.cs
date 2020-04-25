using Castle.DynamicProxy.Generators.Emitters;
using SheepTools.Extensions;
using System;
using System.Collections.Generic;
using System.Resources;
using Xunit;

namespace SheepTools.Test.Extensions
{
    public class StringExtensionsTest
    {
        [Fact]
        public void IsEmpty()
        {
            var dictionary = new List<Tuple<string, bool>>
            {
                new Tuple<string, bool>(string.Empty, true),
                new Tuple<string, bool>(null, false),
                new Tuple<string, bool>(" ", false),
            };

            foreach (var entry in dictionary)
            {
                Assert.Equal(entry.Item2, entry.Item1.IsEmpty());
            }
        }

        [Fact]
        public void HasWhiteSpaces()
        {
            var dictionary = new List<Tuple<string, bool>>
            {
                new Tuple<string, bool>(string.Empty, false),
                new Tuple<string, bool>(null, false),
                new Tuple<string, bool>(" ", true),
                new Tuple<string, bool>(" true", true),
                new Tuple<string, bool>("true ", true),
                new Tuple<string, bool>(" true ", true),
                new Tuple<string, bool>("tr ue", true),
                new Tuple<string, bool>("false", false),
            };

            foreach (var entry in dictionary)
            {
                Assert.Equal(entry.Item2, entry.Item1.HasWhiteSpaces());
            }
        }

        [Fact]
        public void Truncate()
        {
            var dictionary = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(string.Empty, string.Empty),
                new Tuple<string, string>(null, null),
                new Tuple<string, string>("1", "1"),
                new Tuple<string, string>("123", "123"),
                new Tuple<string, string>("12345", "12345"),
                new Tuple<string, string>("123456879", "12345")
            };

            foreach (var entry in dictionary)
            {
                Assert.Equal(entry.Item2, entry.Item1.Truncate(5));
            }
        }
    }
}
