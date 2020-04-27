using SheepTools.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace SheepTools.Test.Model
{
    public class NodeTest
    {
        private class CustomNode : TreeNode<DateTime>
        {
            public CustomNode(DateTime id) : base(id)
            {
            }

            public CustomNode(DateTime id, TreeNode<DateTime> child) : base(id, child)
            {
            }
        }

        [Fact]
        public void ShouldNotHaveDefaultOrNullKey()
        {
            Assert.Throws<ArgumentException>(() => new Node(null));
            Assert.Throws<ArgumentException>(() => new CustomNode(default));
        }

        [Fact]
        public void ShouldNotHaveItselfAsChild()
        {
            var customNode = new CustomNode(DateTime.Now);

            Assert.Throws<ArgumentException>(() => new CustomNode(customNode.Id, customNode));
        }

        [Fact]
        public void NodeEqual()
        {
            var a = new Node("#1");
            var b = new Node("#1");
            var c = new Node("");
            var d = new Node("3");

            Assert.Equal(a, b);
            Assert.True(a.Equals(b));
            Assert.True(a == b);
            Assert.NotEqual(a, c);
            Assert.NotEqual(a, d);
            Assert.NotEqual(c, d);
            Assert.True(c != d);

            HashSet<Node> set = new HashSet<Node>() { a };
            Assert.False(set.Add(b));
            Assert.True(set.Add(c));
            Assert.True(set.Add(d));
        }

        [Fact]
        public void CustomNodeEqual()
        {
            DateTime now = DateTime.Now;

            CustomNode a = new CustomNode(now);
            CustomNode b = new CustomNode(now);
            CustomNode c = new CustomNode(DateTime.Now);
            CustomNode d = new CustomNode(now.AddSeconds(1));

            Assert.Equal(a, b);
            Assert.True(a.Equals(b));
            Assert.True(a == b);
            Assert.NotEqual(a, c);
            Assert.NotEqual(a, d);
            Assert.NotEqual(c, d);
            Assert.True(c != d);

            HashSet<CustomNode> set = new HashSet<CustomNode>() { a };
            Assert.False(set.Add(b));
            Assert.True(set.Add(c));
            Assert.True(set.Add(d));
        }

        [Fact]
        public void DescendantsCount()
        {
            var d = new CustomNode(DateTime.Now);
            var c = new CustomNode(DateTime.Now, d);
            var b = new CustomNode(DateTime.Now, c);
            var a = new CustomNode(DateTime.Now, b);

            Assert.Equal(0, d.DescendantsCount());
            Assert.Equal(0, d.GrandChildrenCount());
            Assert.Equal(1, c.DescendantsCount());
            Assert.Equal(1, c.GrandChildrenCount());
            Assert.Equal(2, b.DescendantsCount());
            Assert.Equal(2, b.GrandChildrenCount());
            Assert.Equal(3, a.DescendantsCount());
            Assert.Equal(3, a.GrandChildrenCount());
        }

        /// <summary>
        /// See https://adventofcode.com/2019/day/6, part 1
        /// </summary>
        [Fact]
        public void RelationshipsCount()
        {
            var l = new Node("L");
            var i = new Node("I");
            var h = new Node("H");
            var f = new Node("F");
            var k = new Node("K", l);
            var j = new Node("J", k);
            var g = new Node("G", h);
            var e = new Node("E", f);
            var d = new Node("D", e);
            var c = new Node("C", d);
            var b = new Node("B", c);
            var com = new Node("COM", b);
            b.Children.Add(g);
            e.Children.Add(j);
            d.Children.Add(i);

            var result = com.RelationshipsCount();

            Assert.Equal(42, result);
        }

        /// <summary>
        /// See https://adventofcode.com/2019/day/6, part 2
        /// </summary>
        [Fact]
        public void DistanceTo()
        {
            var f = new Node("F");
            var i = new Node("I");
            var l = new Node("L");
            var e = new Node("E", f);
            var d = new Node("D", e);
            var k = new Node("K", l);
            var j = new Node("J", k);
            e.Children.Add(j);
            d.Children.Add(i);

            var result = d.DistanceTo(k, 0) + d.DistanceTo(i, 0);

            Assert.Equal(4, result);
            Assert.Equal(4, d.DistanceTo(k, 1));

            Assert.Equal(int.MaxValue, k.DistanceTo(d, 0));
            Assert.Equal(int.MaxValue, i.DistanceTo(d, 0));
            Assert.Equal(int.MaxValue, k.DistanceTo(i, 0));
            Assert.Equal(int.MaxValue, i.DistanceTo(k, 0));
        }
    }
}
