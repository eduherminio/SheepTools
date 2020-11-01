using System;

namespace SheepTools.Model
{
    /// <summary>
    /// Generic node class, with equality operators overridden
    /// <See cref="TreeNode{TKey}"/>
    /// </summary>
    /// <typeparam name="TKey">Generic key</typeparam>
    public class GenericNode<TKey> : IEquatable<GenericNode<TKey>>
        where TKey : notnull
    {
        public TKey Id { get; set; }

        /// <summary>
        /// Identifier cannot have TKey's default value
        /// </summary>
        /// <param name="id"></param>
        public GenericNode(TKey id)
        {
            if (id is null || id.Equals(default(TKey)))
            {
                throw new ArgumentException($"Id cannot be {id} (default value)");
            }

            Id = id;
        }

        #region Equals override

        public bool Equals(GenericNode<TKey>? other)
        {
            if (other is null)
            {
                return false;
            }

            return Id.GetType() == typeof(TKey) && Id.Equals(other.Id);
        }

        public override bool Equals(object? obj)
        {
            if (obj is GenericNode<TKey> other)
            {
                return Equals(other);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(GenericNode<TKey> node1, GenericNode<TKey> node2)
        {
            if (node1 is null)
            {
                return node2 is null;
            }

            return node1.Equals(node2);
        }

        public static bool operator !=(GenericNode<TKey> node1, GenericNode<TKey> node2)
        {
            if (node1 is null)
            {
                return node2 is object;
            }

            return !node1.Equals(node2);
        }

        #endregion
    }
}
