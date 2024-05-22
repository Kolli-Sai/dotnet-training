using System;
using System.Collections;

namespace CollectionsPractice
{
    public class HashtableDemo
    {
        Hashtable hashtable = new Hashtable();

        // Method to add key-value pairs to the hashtable
        public void Add<T, U>(T key, U value)
        {
            if (key != null) // Check for nullability
                hashtable.Add(key, value);
            else
                throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        }

        // Method to remove a key-value pair from the hashtable
        public void Remove<T>(T key)
        {
            if (key != null) // Check for nullability
                hashtable.Remove(key);
            else
                throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        }

        // Method to get the value associated with a key from the hashtable
        public object Get<T>(T key)
        {
            if (key != null) // Check for nullability
                return hashtable[key];
            else
                throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        }

        // Method to check if the hashtable contains a specific key
        public bool ContainsKey<T>(T key)
        {
            if (key != null) // Check for nullability
                return hashtable.ContainsKey(key);
            else
                throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        }
    }

  
}
