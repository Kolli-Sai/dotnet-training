using System.Collections;

namespace CollectionsPractice2;

public class StackDemo
{
    Stack stack = new Stack();
    public void Add(string name){
        stack.Push(name);
        System.Console.WriteLine($"{name} added to stack.");
    }

    public void Remove(){
        System.Console.WriteLine($"Removed item from stack : {stack.Pop()}");
    }

    public void Peek(){
        System.Console.WriteLine($"{stack.Peek()} was at the top of the stack.");
    }

    public void GetCount(){
        System.Console.WriteLine($"{stack.Count} elements are there in stack.");
    }

    public void Clear(){
        stack.Clear();
        System.Console.WriteLine("stack cleared.");
    }

    public void Contains(string name){
        System.Console.WriteLine(stack.Contains(name) ? $"{name} was there in stack.":$"{name} was not found.");
    }
}
