using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    /// <summary>
    /// LIFO type data stucture for any kind of data type.
    /// </summary>
    /// <typeparam name="T"> Type can be anything </typeparam>
    public class MyStack<T>
    {
        /// <summary>
        /// Variable used for storing data and simulating stack.
        /// </summary>
        private readonly List<T> arr;
        public MyStack()
        {
            arr = new List<T>();
        }

        /// <summary>
        /// Returns the size of stack.
        /// </summary>
        /// <returns>
        /// The amount of elements in the stack
        /// </returns>
        public int Size()
        {
            return arr.Count;
        }

        /// <summary>
        /// Returns whether stack is empty.
        /// </summary>
        /// <returns>
        /// True if there are no elements in the stack, false otherwise.
        /// </returns>
        public bool IsEmpty()
        {
            return Size() == 0;
        }

        /// <summary>
        /// Removes the element on the top of stack and returns it.
        /// </summary>
        /// <returns> The last element added </returns>
        public T Pop()
        {
            if (IsEmpty()) return default;
            int index = arr.Count - 1;
            T retVal = arr[index];
            arr.RemoveAt(index);
            return retVal;
        }

        /// <summary>
        /// Adds passed element to the stack.
        /// </summary>
        /// <param name="elem"> Element to be added in stack </param>
        public void Push(T elem)
        {
            arr.Add(elem);
        }

        /// <summary>
        /// Removes all elements from stack.
        /// </summary>
        public void Flush()
        {
            arr.Clear();
        }
    }

}
