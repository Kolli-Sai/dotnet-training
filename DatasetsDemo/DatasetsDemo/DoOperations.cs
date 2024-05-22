namespace DatasetsDemo;

internal class DoOperations
{
    StudentOperations studentOperations = new StudentOperations();
    public void DoAddStudent()
    {
        string name = Utility.ReadStringFromConsole("Enter Student Name :");
        int age = Utility.ReadInt32FromConsole("Enter Student Age :");
        Student student = new Student();
        student.Name = name;
        student.Age = age;
        try
        {

            studentOperations.CreateStudent(student);
            Console.WriteLine("Student created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }

    }

    public void DoGetStudent()
    {
        int studentId = Utility.ReadInt32FromConsole("Enter the Student Id:");
        try
        {
            Student student = studentOperations.GetStudent(studentId);

            if (student != null)
            {
                Console.WriteLine($"Id : {student.Id}");
                Console.WriteLine($"Name : {student.Name}");
                Console.WriteLine($"Age : {student.Age}");
            }
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
        try
        {
            studentOperations.DeleteStudent(studentId);
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
        Student studentFound = studentOperations.GetStudent(studentId);
        try
        {
            if (studentFound != null)
            {
                string studentName = Utility.ReadStringFromConsole("Enter student new name : ");
                int studentAge = Utility.ReadInt32FromConsole("Enter Student new Age : ");

                Student updatedStudent = new Student
                {
                    Id = studentId,
                    Name = studentName,
                    Age = studentAge
                };

                studentOperations.UpdateStudent(updatedStudent);


            }
            else
            {
                Console.WriteLine("Student Not found.");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

    }
}
