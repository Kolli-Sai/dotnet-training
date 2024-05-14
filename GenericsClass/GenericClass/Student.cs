namespace GenericsClass;

public class Student<T,U,V>
{
    public T Id { get; set;}
    public U Name { get; set;}
    public V Savings { get; set;}

    public Student(T id,U name,V savings){
        Id = id;
        Name = name;
        Savings = savings;
    }
}
