namespace DB_Practice;



internal class Program
{
    
    static void Main(string[] args)
    {
        StudentOperations studentOperations = new StudentOperations();
        Student student1 = new Student(3,"sai");
        studentOperations.CreateNewStudent(student1);
    }
}
