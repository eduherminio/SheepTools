using Moq;
using SheepTools.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SheepTools.Test.Extensions
{
    public class EnumerableExtensionsTest
    {
        protected virtual void Foo() => throw new NotSupportedException();

        [Fact]
        public void ForEach()
        {
            var mock = new Mock<EnumerableExtensionsTest>();
            var enumerable = new List<EnumerableExtensionsTest> { mock.Object, mock.Object, mock.Object };

            enumerable.ForEach(str => str.Foo());

            mock.Verify(m => m.Foo(), Times.Exactly(enumerable.Count));
        }

        [Fact]
        public void IsNullOrEmpty()
        {
            var emptyEnumerable = Enumerable.Empty<double>();
            Assert.True(emptyEnumerable.IsNullOrEmpty());

            IEnumerable<double> nullEnumerable = null;
            Assert.True(nullEnumerable.IsNullOrEmpty());

            var notNullOrEmptyEnumerable = new List<double> { Math.PI };
            Assert.False(notNullOrEmptyEnumerable.IsNullOrEmpty());
        }
    }
}
