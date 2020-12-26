namespace _02._AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int CountNodes()
        {
            return this.root != null ? this.root.Count : 0;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Clear()
        {
            root = null;
        }

        public void Insert(T element)
        {
            root = Insert(root, element);
        }

        private Node<T> Insert(Node<T> node, T element)
        {
            if (node == null)
            {
                return new Node<T>(element);
            }

            var comp = element.CompareTo(node.Element);

            if (comp > 0)
            {
                node.Right = Insert(node.Right, element);
            }

            if (comp < 0)
            {
                node.Left = Insert(node.Left, element);
            }

            node = Skew(node);
            node = Split(node);

            node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

            return node;
        }

        private int GetCount(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private Node<T> Split(Node<T> node)
        {
            if (node.Level == node.Right?.Right?.Level)
            {
                var temp = node.Right;
                node.Right = temp.Left;
                temp.Left = node;

                node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);
                temp.Level = Level(temp.Right) + 1;
                return temp;
            }
            else
            {
                return node;
            }
        }

        private int Level(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Level;
        }

        private Node<T> Skew(Node<T> node)
        {
            if (node.Level == node.Left?.Level)
            {
                var temp = node.Left;
                node.Left = temp.Right;
                temp.Right = node;

                node.Count = 1 + GetCount(node.Left) + GetCount(node.Right);

                return temp;
            }

            return node;
        }

        public bool Search(T element)
        {
            return Search(this.root, element);
        }

        private bool Search(Node<T> node, T element)
        {
            if (node == null)
            {
                return false;
            }

            var comp = element.CompareTo(node.Element);

            if (comp > 0)
            {
                return Search(node.Right, element);
            }

            if (comp < 0)
            {
                return Search(node.Left, element);
            }

            return true;
        }

        public void InOrder(Action<T> action)
        {
            VisitInOrder(this.root, action);
        }

        private void VisitInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            VisitInOrder(node.Left, action);
            action(node.Element);
            VisitInOrder(node.Right, action);
        }

        public void PreOrder(Action<T> action)
        {
            VisitPreOrder(this.root, action);
        }

        private void VisitPreOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            action(node.Element);
            VisitPreOrder(node.Left, action);
            VisitPreOrder(node.Right, action);
        }

        public void PostOrder(Action<T> action)
        {
            VisitPostOrder(this.root, action);
        }

        private void VisitPostOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            VisitPostOrder(node.Left, action);
            VisitPostOrder(node.Right, action);
            action(node.Element);
        }
    }
}