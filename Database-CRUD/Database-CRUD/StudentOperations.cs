using System.Data.SqlClient;

namespace Database_CRUD;

internal class StudentOperations
{
    static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students-Management;Integrated Security=True;Pooling=False;";

    public void CreateStudent(Student newStudent)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = $"INSERT INTO Students(Name, Age) VALUES(@Name, @Age)";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Name", newStudent.Name);
        command.Parameters.AddWithValue("@Age", newStudent.Age);

        try
        {
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected <= 0)
            {
                throw new Exception("Failed to create new student.");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }


    public Student GetStudent(int studentId)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string query = $"SELECT * FROM Students WHERE Id = @StudentId";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@StudentId", studentId);
        Student student = null;
        SqlDataReader dataReader = null;

        try
        {
            connection.Open();
            dataReader = command.ExecuteReader();
            if (dataReader != null && dataReader.Read())
            {
                student = new Student
                {
                    Id = Convert.ToInt32(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                    Age = Convert.ToInt32(dataReader["Age"])
                };
            }
            else
            {
                throw new Exception($"Failed to get the student with Id {studentId}");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            dataReader.Close();
            connection.Close();
        }

        return student;
    }

    public List<Student> GetStudents()
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = $"SELECT * FROM Students;";
        SqlCommand command = new SqlCommand(query, connection);
        List<Student> students = new List<Student>();
        Student student = null;
        SqlDataReader dataReader = null;

        try
        {
            connection.Open();
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                student = new Student
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Name = dataReader["Name"].ToString(),
                    Age = Convert.ToInt32(dataReader["Age"].ToString())
                };
                students.Add(student);
            }



        }
        catch (Exception ex)
        {

            throw;
        }
        finally
        {
            dataReader.Close();
            connection.Close();

        }

        return students;

    }

    public void UpdateStudent(Student student)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string updateQuery = $"UPDATE Students SET Name = '{student.Name}',Age={student.Age} WHERE Id = {student.Id}";
        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
        try
        {
            connection.Open();
            int rowsEffected = updateCommand.ExecuteNonQuery();
            if (rowsEffected <= 0)
            {
                throw new Exception($"Failed to Update student with Id {student.Id}");
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            connection.Close();
        }
    }


    public void DeleteStudent(int studentId)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string deleteQuery = $"DELETE FROM Students WHERE Id =@StudentId";



        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
        deleteCommand.Parameters.AddWithValue("@StudentId", studentId);


        try
        {
            connection.Open();
            int rowsEffected = deleteCommand.ExecuteNonQuery();
            if (rowsEffected <= 0)
            {
                throw new Exception($"Failed to Deleted Student Id {studentId}");
            }


        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }

    }
}
