using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Workshop
{
    public class CustomStack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Default size of internal array
        /// </summary>
        private const int defaultSize = 4;

        /// <summary>
        /// Internal array
        /// </summary>
        private T[] innerArr;

        /// <summary>
        /// Number of elements in the stack
        /// </summary>
        public int Count { get; private set; } = 0;

        public CustomStack()
        {
            innerArr = new T[defaultSize];    
        }

        public void Push(T element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }
            innerArr[Count] = element;
            Count++;
        }

        public T Peek()
        {
            CheckIfEmpty();
            return innerArr[Count - 1];
        }

        

        public T Pop()
        {
            CheckIfEmpty();
            Count--;
            T tempElement = innerArr[Count];
            innerArr[Count] = default;
            return tempElement;
        }

        public void Foreach(Action<T> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(innerArr[i]);
            }
        }

        private void Grow()
        {
            T[] tempArr = new T[innerArr.Length * 2];
            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }

        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return innerArr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
