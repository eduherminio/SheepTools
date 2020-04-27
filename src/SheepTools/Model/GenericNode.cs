using System;

namespace SheepTools.Model
{
    /// <summary>
    /// Generic node class, with equality operators overriden
    /// <See cref="TreeNode{TKey}"/>
    /// </summary>
    /// <typeparam name="TKey">Generic key</typeparam>
    public class GenericNode<TKey> : IEquatable<GenericNode<TKey>>
    {
        public TKey Id { get; set; }

        /// <summary>
        /// Identifier cannot be null or default
        /// </summary>
        /// <param name="id"></param>
        public GenericNode(TKey id)
        {
            if (id == null || id.Equals(default(TKey)))
            {
                throw new ArgumentException($"Id cannot be {(id == null ? "null" : id.ToString())}");
            }

            Id = id;
        }

        #region Equals override

        public bool Equals(GenericNode<TKey> other)
        {
            if (other == null)
            {
                return false;
            }

            return Id.GetType() == typeof(TKey) && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is GenericNode<TKey>))
            {
                return false;
            }

            return Equals((GenericNode<TKey>)obj);
        }

        public override int GetHashCode()
        {
#if !NETSTANDARD2_0
            return HashCode.Combine(Id);
#else
            return Id.GetHashCode();
#endif
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
