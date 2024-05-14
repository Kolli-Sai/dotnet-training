using System.Collections;

namespace CollectionsPractice2;

public class QueueDemo
{
    Queue queue = new Queue();

    public void Enqueue(string name)
    {
        queue.Enqueue(name);
        System.Console.WriteLine($"{name} was added to queue.");
    }

    public void Dequeue()
    {
        System.Console.WriteLine($"{queue.Dequeue()} was removed from the queue.");
    }

    public void Peek()
    {
        System.Console.WriteLine($"{queue.Peek()} was at the front of the queue.");
    }

    public void Count()
    {
        System.Console.WriteLine($"{queue.Count} elements present in the queue.");
    }

    public void Contains(string name)
    {
        System.Console.WriteLine(queue.Contains(name) ? $"{name} was there." : $"{name} was not there.");
    }

    public void Clear(){
        queue.Clear();
        System.Console.WriteLine("queue cleared.");
    }
}
