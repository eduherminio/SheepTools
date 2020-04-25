using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SheepTools.Test.Extensions
{
    public class CollectionExtensionsTest
    {
        [Fact]
        public void AddRange()
        {
            // Arrange
            var existingCollection = new List<int> { 1, 2, 3 };
            var initialCollection = existingCollection.ToList();
            var itemsToAdd = new List<int> { 4, 5, 6 };

            // Act
            existingCollection.AddRange(itemsToAdd);

            // Assert
            Assert.Equal(initialCollection.Concat(itemsToAdd).ToList(), existingCollection);
        }

        [Fact]
        public void RemoveRange()
        {
            // Arrange
            var existingCollection = new List<int> { 1, 2, 3, 4, 5, 6 };
            var initialCollection = existingCollection.ToList();
            var evens = existingCollection.Where(n => n % 2 == 0).ToList();

            // Act
            existingCollection.RemoveAll(n => n % 2 == 0);

            // Assert
            Assert.Equal(initialCollection.Except(evens).ToList(), existingCollection);
        }
    }
}
