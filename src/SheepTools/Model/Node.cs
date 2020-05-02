using System.Collections.Generic;

namespace SheepTools.Model
{
    /// <summary>
    /// Node class, with equality operators overriden
    /// <See cref="TreeNode{TKey}"/> con TKey: string
    /// </summary>
    public class Node : TreeNode<string>
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
