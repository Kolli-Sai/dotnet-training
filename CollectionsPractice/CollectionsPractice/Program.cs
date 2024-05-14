
using CollectionsPractice;

class Program
{
    public static void Stack()
    {

        StackDemo stackDemo = new StackDemo();

        // Pushing some elements onto the stack
        stackDemo.Push("C#");
        stackDemo.Push("Java");
        stackDemo.Push("Python");
        stackDemo.Push("Ruby");

        // Popping and printing the top element from the stack
        Console.WriteLine("Popped item: " + stackDemo.Pop());

        // Peeking at the top element of the stack
        Console.WriteLine("Top item after pop: " + stackDemo.Peek());

        // Checking if the stack contains a specific item
        Console.WriteLine("Contains 'Java': " + stackDemo.Contains("Java"));

        // Clearing all elements from the stack
        stackDemo.Clear();

        // Getting the number of elements in the stack
        Console.WriteLine("Number of elements in the stack after clearing: " + stackDemo.Count());
    }

    public static void Queue()
    {
        QueueDemo queueDemo = new QueueDemo();

        // Enqueuing some items into the queue
        queueDemo.Enqueue("C#");
        queueDemo.Enqueue("Java");
        queueDemo.Enqueue("Python");
        queueDemo.Enqueue("Ruby");

        // Dequeuing and printing the item at the front of the queue
        Console.WriteLine("Dequeued item: " + queueDemo.Dequeue());

        // Peeking at the item at the front of the queue
        Console.WriteLine("Front item after dequeue: " + queueDemo.Peek());

        // Checking if the queue contains a specific item
        Console.WriteLine("Contains 'Java': " + queueDemo.Contains("Java"));

        // Clearing all items from the queue
        queueDemo.Clear();

        // Getting the number of items in the queue
        Console.WriteLine("Number of items in the queue after clearing: " + queueDemo.Count());
    }

    public static void HashTable()
    {
        HashtableDemo hashtableDemo = new HashtableDemo();

        // Adding some key-value pairs to the hashtable
        hashtableDemo.Add("C", "C#");
        hashtableDemo.Add("J", "Java");
        hashtableDemo.Add("P", "Python");
        hashtableDemo.Add("R", "Ruby");
        hashtableDemo.Add<int, string>(1, "vamsi");

        // Retrieving and printing the value associated with a key
        Console.WriteLine("Value associated with key 'J': " + hashtableDemo.Get("J"));

        // Removing a key-value pair from the hashtable
        hashtableDemo.Remove("P");

        // Checking if the hashtable contains a specific key
        Console.WriteLine("Contains key 'P': " + hashtableDemo.ContainsKey("P"));


    }

    public static void SortedList()
    {
        SortedListDemo sortedListDemo = new SortedListDemo();

        // Adding some key-value pairs to the sorted list
        sortedListDemo.Add("C", "C#");
        sortedListDemo.Add("J", "Java");
        sortedListDemo.Add("P", "Python");
        sortedListDemo.Add("R", "Ruby");

        // Retrieving and printing the value associated with a key
        Console.WriteLine("Value associated with key 'J': " + sortedListDemo.Get("J"));

        // Removing a key-value pair from the sorted list
        sortedListDemo.Remove("P");

        // Checking if the sorted list contains a specific key
        Console.WriteLine("Contains key 'P': " + sortedListDemo.ContainsKey("P"));


    }
    public static void Main(string[] args)
    {
        Stack();
    }
}