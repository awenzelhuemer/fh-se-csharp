using System;
using System.Collections;
using System.Collections.Generic;

namespace Swe4.Collections
{
    public class BinarySearchTree<T> : ICollection<T>
    {
        #region Private Fields

        private Node root;

        #endregion

        #region Public Properties

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        #endregion

        #region Private Methods

        private Comparison<T> comparer;

        public BinarySearchTree(Comparison<T> comparer)
        {
            this.comparer = comparer;
        }

        public BinarySearchTree()
        {
            this.comparer = (T t1, T t2) => ((IComparable<T>)t1).CompareTo(t2);
        }

        private void Add(ref Node node, T item)
        {
            if (node == null)
            {
                node = new Node
                {
                    Value = item
                };
                Count++;
            }
            else if (comparer(item, node.Value) < 0)
            {
                Add(ref node.Left, item);
            }
            else
            {
                Add(ref node.Right, item);
            }
        }

        private bool Contains(Node node, T item)
        {
            if (node == null)
            {
                return false;
            }

            int compareResult = comparer(item, node.Value);
            if (compareResult < 0)
            {
                return Contains(node.Left, item);
            }
            else if (compareResult > 0)
            {
                return Contains(node.Right, item);
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Public Methods

        public void Add(T item) => Add(ref root, item);

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public bool Contains(T item) => Contains(root, item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator() => EnumerateItems(root).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T item) => throw new NotImplementedException();

        #endregion

        #region Private Classes

        // variant 1
        //private class BinarySearchTreeEnumerater : IEnumerator<T>
        //{
        //    #region Private Fields

        //    private readonly Stack<Node> parents = new();
        //    private readonly Node root;
        //    private Node current;

        //    #endregion

        //    #region Public Constructors

        //    public BinarySearchTreeEnumerater(Node root)
        //    {
        //        this.root = root;
        //        Reset();
        //    }

        //    #endregion

        //    #region Public Properties

        //    public T Current => current.Value;

        //    object IEnumerator.Current => Current;

        //    #endregion

        //    #region Private Methods

        //    private void WalkDownLeft(Node node)
        //    {
        //        while (node != null)
        //        {
        //            parents.Push(node);
        //            node = node.Left;
        //        }
        //    }

        //    #endregion

        //    #region Public Methods

        //    public void Dispose()
        //    {
        //    }

        //    public bool MoveNext()
        //    {
        //        if (parents.Count == 0)
        //        {
        //            return false;
        //        }

        //        current = parents.Pop();
        //        WalkDownLeft(current.Right);
        //        return true;
        //    }

        //    public void Reset()
        //    {
        //        parents.Clear();
        //        current = null;
        //        WalkDownLeft(root);
        //    }

        //    #endregion
        //}

        // variant 2
        //private IEnumerable<T> EnumerateItems(Node node)
        //{
        //    if(node == null)
        //    {
        //        yield break;
        //    }

        //    foreach (T item in EnumerateItems(node.Left))
        //    {
        //        yield return item;
        //    }

        //    yield return node.Value;

        //    foreach (T item in EnumerateItems(node.Right))
        //    {
        //        yield return item;
        //    }
        //}

        // variant 3
        private IEnumerable<T> EnumerateItems(Node node)
        {
            Stack<Node> parents = new Stack<Node>();

            while (node != null || parents.Count > 0)
            {
                while(node != null)
                {
                    parents.Push(node);
                    node = node.Left;
                }

                node = parents.Pop();
                yield return node.Value;
                node = node.Right;
            }
        }

        private class Node
        {
            #region Public Fields

            public Node Left;
            public Node Right;
            public T Value;

            #endregion
        }

        #endregion
    }
}