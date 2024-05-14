namespace DataReaderDemo;

internal class DoOperations
{
    StudentOperations studentOperations = new StudentOperations();
    public void DoAddStudent()
    {
        string name = Utility.ReadStringFromConsole("Enter Student Name :");
        int age = Utility.ReadInt32FromConsole("Enter Student Age :");

        string query = $"INSERT INTO Students(Name, Age) VALUES('{name}', {age})";

        try
        {

            studentOperations.ActionQuery(query);
            Console.WriteLine("Student created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }

    }



    public void DoGetStudents()
    {
        List<Student> students;

        try
        {
            students = studentOperations.GetStudents();

            if (students.Count > 0)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine($"Id : {student.Id}");
                    Console.WriteLine($"Name : {student.Name}");
                    Console.WriteLine($"Age : {student.Age}");
                    Console.WriteLine("==========================");
                }
            }
            else
            {
                Console.WriteLine("There is no students to display.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public void DoDeleteStudent()
    {
        int studentId = Utility.ReadInt32FromConsole("Enter the Student Id :");
        string deleteQuery = $"DELETE FROM Students WHERE Id ={studentId}";

        try
        {
            studentOperations.ActionQuery(deleteQuery);
            Console.WriteLine("Deleted Successfully.");
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }

    public void DoUpdateStudent()
    {
        int studentId = Utility.ReadInt32FromConsole("Enter the student Id you want to update!");

        try
        {

            string studentName = Utility.ReadStringFromConsole("Enter student new name : ");
            int studentAge = Utility.ReadInt32FromConsole("Enter Student new Age : ");
            string updateQuery = $"UPDATE Students SET Name = '{studentName}',Age={studentAge} WHERE Id = {studentId}";
            studentOperations.ActionQuery(updateQuery);



        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

    }
}
