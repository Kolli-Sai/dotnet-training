using System.Collections;

namespace CollectionsPractice2;

public class SortedListDemo
{
    SortedList sortedList = new SortedList();

        public void Add(string key, string value)
        {
            sortedList.Add(key, value);
        }

        public void Remove(string key)
        {
            sortedList.Remove(key);
        }

        public void Count()
        {
            Console.WriteLine($"{sortedList.Count} elements are there in the sorted list.");
        }

        public void ContainsKey(string key)
        {
            Console.WriteLine(sortedList.ContainsKey(key) ? $"{key} key is present." : $"{key} key is not present.");
        }

        public void ContainsValue(string value)
        {
            Console.WriteLine(sortedList.ContainsValue(value) ? $"{value} value is present." : $"{value} value is not present.");
        }

        public void Clear()
        {
            sortedList.Clear();
            Console.WriteLine("Sorted list cleared.");
        }

        public void GetKeys()
        {
            foreach (var key in sortedList.Keys)
            {
                Console.WriteLine(key);
            }
        }

        public void GetValues()
        {
            foreach (var value in sortedList.Values)
            {
                Console.WriteLine(value);
            }
        }
}
