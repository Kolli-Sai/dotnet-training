using System;
using System.Collections;

namespace CollectionsPractice
{
    public class QueueDemo
    {
        Queue queue = new Queue();

        // Method to enqueue an item into the queue
        public void Enqueue(object item)
        {
            queue.Enqueue(item);
        }

        // Method to dequeue an item from the queue
        public object Dequeue()
        {
            return queue.Dequeue();
        }

        // Method to peek at the item at the front of the queue without removing it
        public object Peek()
        {
            return queue.Peek();
        }

        // Method to check if the queue contains a specific item
        public bool Contains(object item)
        {
            return queue.Contains(item);
        }

        // Method to clear all items from the queue
        public void Clear()
        {
            queue.Clear();
        }

        // Method to get the number of items in the queue
        public int Count()
        {
            return queue.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
}
