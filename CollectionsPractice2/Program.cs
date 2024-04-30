
using CollectionsPractice2;

class Program
{
    static void Stack()
    {
        StackDemo stackDemo = new StackDemo();
        stackDemo.Add("sai");
        stackDemo.Add("vamsi");
        stackDemo.Add("kolli");
        stackDemo.Remove();
        stackDemo.Peek();
        stackDemo.GetCount();
        stackDemo.Contains("sai");
        stackDemo.Clear();
    }

    static void Queue()
    {
        QueueDemo queueDemo = new QueueDemo();
        queueDemo.Enqueue("sai");
        queueDemo.Enqueue("vamsi");
        queueDemo.Enqueue("kolli");
        queueDemo.Dequeue();
        queueDemo.Peek();
        queueDemo.Count();
        queueDemo.Contains("sai");
        queueDemo.Clear();

    }

    static void Hashtable()
    {
        HashTableDemo hashTableDemo = new HashTableDemo();
        hashTableDemo.Add("age", "21");
        hashTableDemo.Add("name", "sai");
        hashTableDemo.Add("sname", "kolli");
        hashTableDemo.Remove("sname");
        hashTableDemo.ContainsKey("sname");
        hashTableDemo.ContainsValue("sai");
        hashTableDemo.GetKeys();
        hashTableDemo.GetValues();
        hashTableDemo.Clear();
    }

    static void SortedList()
    {
        SortedListDemo sortedListDemo = new SortedListDemo();

        sortedListDemo.Add("name", "sai");
        sortedListDemo.Add("age", "21");
        sortedListDemo.Add("sname", "kolli");

        sortedListDemo.Remove("sname");
        sortedListDemo.ContainsKey("sname");
        sortedListDemo.ContainsValue("sai");
        sortedListDemo.GetKeys();
        sortedListDemo.GetValues();
        sortedListDemo.Clear();
    }
    public static void Main(string[] args)
    {
        // Stack();
        // Queue();
        // Hashtable();
        SortedList();
    }
}
