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
        public void ForEachList()
        {
            // Arrange
            var mock = new Mock<EnumerableExtensionsTest>();
            IEnumerable<EnumerableExtensionsTest> list = new List<EnumerableExtensionsTest> { mock.Object, mock.Object, mock.Object };

            // Act
            list.ForEach(str => str.Foo());

            // Assert
            mock.Verify(m => m.Foo(), Times.Exactly(list.Count()));
        }

        [Fact]
        public void ForEachEnumerable()
        {
            // Arrange
            var mock = new Mock<EnumerableExtensionsTest>();
            var enumerable = new HashSet<EnumerableExtensionsTest> { mock.Object, mock.Object, mock.Object };

            // Act
            enumerable.ForEach(str => str.Foo());

            // Assert
            mock.Verify(m => m.Foo(), Times.Exactly(enumerable.Count));
        }

        [Fact]
        public void IsNullOrEmpty()
        {
            var emptyEnumerable = Enumerable.Empty<double>();
            Assert.True(emptyEnumerable.IsNullOrEmpty());

            IEnumerable<double>? nullEnumerable = null;
            Assert.True(nullEnumerable.IsNullOrEmpty());

            var notNullOrEmptyEnumerable = new List<double> { Math.PI };
            Assert.False(notNullOrEmptyEnumerable.IsNullOrEmpty());
        }
    }
}
