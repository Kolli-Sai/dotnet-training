
using GenericsClass;

Addition<int> addition = new Addition<int>(12, 14);
System.Console.WriteLine(addition.firstNumber);
System.Console.WriteLine(addition.secondNumber);

// we cannot pass different argument type
// Addition<int> addition2= new Addition<int>(12,"sai");

Multiplication<int, float> multiplication = new Multiplication<int, float>(2, 3.5f);
System.Console.WriteLine(multiplication.firstNumber);

// Student class

Student<int, string, int> student1 = new Student<int, string, int>(12, "sai", 200);
Student<int, string, float> student2 = new Student<int, string, float>(12, "vamsi", 200.00f);

System.Console.WriteLine(student1.Name);
System.Console.WriteLine(student2.Name);