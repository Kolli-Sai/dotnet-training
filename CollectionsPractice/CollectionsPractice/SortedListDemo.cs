using System;
using System.Collections;

namespace CollectionsPractice
{
    public class SortedListDemo
    {
        SortedList sortedList = new SortedList();

        // Method to add key-value pairs to the sorted list
        public void Add<T, U>(T key, U value)
        {
            if (key != null) // Check for nullability
                sortedList.Add(key, value);
            else
                throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        }

        // Method to remove a key-value pair from the sorted list
        public void Remove<T>(T key)
        {
            if (key != null) // Check for nullability
                sortedList.Remove(key);
            else
                throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        }

        // Method to get the value associated with a key from the sorted list
        public object Get<T>(T key)
        {
            if (key != null) // Check for nullability
                return sortedList[key];
            else
                throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        }

        // Method to check if the sorted list contains a specific key
        public bool ContainsKey<T>(T key)
        {
            if (key != null) // Check for nullability
                return sortedList.ContainsKey(key);
            else
                throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        }

        // Method to get the index of a specific key in the sorted list
        public int IndexOfKey<T>(T key)
        {
            if (key != null) // Check for nullability
                return sortedList.IndexOfKey(key);
            else
                throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        }

       
    }

   
}
