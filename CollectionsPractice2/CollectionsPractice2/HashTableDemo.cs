using System.Collections;

namespace CollectionsPractice2;

public class HashTableDemo
{
    Hashtable hashtable= new Hashtable();

    public void Add(string key,string value){
        hashtable.Add(key,value);

    }

    public void Remove(string key){
        hashtable.Remove(key);
    }

    public void Count(){
        System.Console.WriteLine($"{hashtable.Count} elements was there in hashtable.");
    }

    public void ContainsKey(string key){
        System.Console.WriteLine(hashtable.Contains(key) ? $"{key} key was there.":$"{key} key was not there.");
    }

    public void ContainsValue(string value){
        System.Console.WriteLine(hashtable.ContainsValue(value) ? $"{value} value was there":$"{value} value was not there.");
    }

    public void Clear(){
        hashtable.Clear();
        
        System.Console.WriteLine("hashtable cleared.");
    }

    public void GetKeys(){
        foreach (string key in hashtable.Keys)
        {
            System.Console.WriteLine(key);
        }
    }

    public void GetValues(){
        foreach (string key in hashtable.Values){
            System.Console.WriteLine(key);
        }
    }
}
