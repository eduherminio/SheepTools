using System.Collections.Generic;

namespace SheepTools.Model
{
    /// <summary>
    /// Node record class
    /// <See cref="TreeNode{TKey}"/> con TKey: string
    /// </summary>
    public record Node : TreeNode<string>
    {
        /// <inheritdoc/>
        public Node(string id) : base(id)
        {
        }

        /// <inheritdoc/>
        public Node(string id, Node child) : base(id, child)
        {
        }

        /// <inheritdoc/>
        public Node(string id, IEnumerable<Node> children) : base(id, children)
        {
        }

        /// <inheritdoc/>
        public Node(Node parent, string id) : base(parent, id)
        {
        }
    }
}
