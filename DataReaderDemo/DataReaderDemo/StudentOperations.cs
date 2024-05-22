using System.Data.SqlClient;

namespace DataReaderDemo;

internal class StudentOperations
{
    static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students-Management;Integrated Security=True;Pooling=False;";

   
    public void ActionQuery(string query)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand(query, connection);
        try
        {
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if(rowsAffected <= 0)
            {
                throw new Exception("failed to execute the query.");
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            connection.Close() ;
        }


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


}
