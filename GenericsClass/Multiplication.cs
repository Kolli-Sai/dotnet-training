namespace GenericsClass;

public class Multiplication<T,U>
{
    public T firstNumber { get; set; }
    public U secondNumber { get; set;}

    public Multiplication(T firstNumber, U secondNumber){
        this.firstNumber = firstNumber;
        this.secondNumber = secondNumber;
    }
}
