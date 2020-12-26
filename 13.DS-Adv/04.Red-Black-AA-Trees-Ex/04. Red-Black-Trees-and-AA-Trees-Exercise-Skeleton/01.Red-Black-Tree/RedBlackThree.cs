namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T> 
        : IBinarySearchTree<T> where T : IComparable
    {
        const bool Red = true;
        const bool Black = false;
        private Node root;

        public RedBlackTree()
        {
        }

        public int Count { get => this.root != null ? this.root.Count : 0; }

        public void Insert(T element)
        {
            this.root = Insert(element, this.root);
            this.root.Color = Black;
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                return new Node(element) { Count = 1 };
            }

            var comp = element.CompareTo(node.Value);

            if (comp > 0)
            {
                node.Right = Insert(element, node.Right);
            }
            else if (comp < 0)
            {
                node.Left = Insert(element, node.Left);
            }

            if (this.IsRed(node.Right) && !this.IsRed(node.Left))
                node = this.RotateLeft(node);
            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
                node = this.RotateRight(node);
            if (this.IsRed(node.Left) && this.IsRed(node.Right))
                this.FlipColors(node);

            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

            return node;
        }

        private void FlipColors(Node node)
        {
            node.Color = Red;
            node.Left.Color = Black;
            node.Right.Color = Black;
        }

        private Node RotateRight(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            temp.Color = node.Color;
            node.Color = Red;
            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

            return temp;
        }

        private Node RotateLeft(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            temp.Color = node.Color;
            node.Color = Red;
            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

            return temp;
        }

        private int GetCount(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private bool IsRed(Node node)
        {
            return node != null && node.Color == Red;
        }

        public T Select(int rank)
        {
            var node = Select(rank, this.root);

            if (node == null)
            {
                throw new IndexOutOfRangeException();
            }

            return node.Value;
        }

        private Node Select(int rank, Node node)
        {
            if (node == null)
            {
                return null;
            }

            var leftCount = GetCount(node.Left);

            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return Select(rank, node.Left);
            }

            return Select(rank - (leftCount + 1), node.Right);
        }

        public int Rank(T element)
        {
            return Rank(element, this.root);
        }

        private int Rank(T element, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            var comp = element.CompareTo(node.Value);

            if (comp < 0)
            {
                return this.Rank(element, node.Left);
            }

            if (comp > 0)
            {
                return 1 + GetCount(node.Left) + Rank(element, node.Right);
            }

            return GetCount(node.Left);
        }

        private T[] RankSnapshot()
        {
            T[] snapshot = new T[this.Count];
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(this.root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var nodeRank = this.Rank(node.Value);
                snapshot[nodeRank] = node.Value;
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return snapshot;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var startRank = Rank(startRange);
            var endRank = Rank(endRange);
            var snapshot = RankSnapshot();
            for (int i = startRank; i <= endRank; i++)
            {
                yield return snapshot[i];
            }
        }

        public bool Contains(T element)
        {
            var node = FindElement(element);
            return node != null;
        }

        private Node FindElement(T element)
        {
            var current = this.root;

            while (current != null)
            {
                var comp = current.Value.CompareTo(element);

                if (comp > 0 )
                {
                    current = current.Left;
                }
                else if (comp < 0 )
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindElement(element);
            var tree = new RedBlackTree<T>();
            tree.root = node;
            return tree;
        }

        public void DeleteMin()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = DeleteMin(this.root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteMin(node.Left);
            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);
            return node;
        }

        public void DeleteMax()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = DeleteMax(this.root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = DeleteMax(node.Right);
            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);
            return node;
        }

        public void Delete(T element)
        {
            this.root = Delete(element, this.root);
        }

        private Node Delete(T element, Node node)
        {
            if (node == null)
            {
                return null;
            }

            var comp = element.CompareTo(node.Value);

            if (comp > 0)
            {
                node.Right = Delete(element, node.Right);
            }
            else if (comp < 0)
            {
                node.Left = Delete(element, node.Left);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }

                if (node.Left == null)
                {
                    return node.Right;
                }

                Node temp = node;
                node = FindMin(temp.Right);
                node.Right = DeleteMin(temp.Right);
                node.Left = temp.Left;
            }

            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

            return node;
        }

        private Node FindMin(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return FindMin(node.Left);
        }

        public T Ceiling(T element)
        {
            return Select(Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return Select(Rank(element) - 1);
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(action, node.Left);
            action(node.Value);
            EachInOrder(action, node.Right);
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Count { get; set; }
            public bool Color { get; set; }
        }
    }
}