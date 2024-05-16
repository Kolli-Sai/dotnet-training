using System;
using System.Collections;

namespace CollectionsPractice
{
    public class StackDemo
    {
        Stack stack = new Stack();

        // Method to push an element onto the stack
        public void Push(object item)
        {
            stack.Push(item);
        }

        // Method to pop the top element from the stack
        public object Pop()
        {
            return stack.Pop();
        }

        // Method to peek at the top element of the stack without removing it
        public object Peek()
        {
            return stack.Peek();
        }

        // Method to check if the stack contains a specific item
        public bool Contains(object item)
        {
            return stack.Contains(item);
        }

        // Method to clear all elements from the stack
        public void Clear()
        {
            stack.Clear();
        }

        // Method to get the number of elements in the stack
        public int Count()
        {
            return stack.Count;
        }
    }

   
}
