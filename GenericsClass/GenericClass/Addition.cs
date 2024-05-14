namespace GenericsClass;

public class Addition<T>
{
    public T firstNumber{ get; set; }
    public T secondNumber{ get; set;}
    public Addition(T firstNumber,T secondNumber){
        this.firstNumber = firstNumber;
        this.secondNumber = secondNumber;
    }
}
