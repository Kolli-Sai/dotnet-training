using System.Data;
using System.Data.SqlClient;

namespace DatasetsDemo;

internal class StudentOperations
{
    static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students-Management;Integrated Security=True;Pooling=False;";
    DataSet dataSet = new DataSet();
    SqlDataAdapter dataAdapter;

    public void CreateStudent(Student newStudent)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = $"SELECT * FROM Students";

        dataAdapter = new SqlDataAdapter(query,connection);
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

        try
        {
            connection.Open();
            dataAdapter.Fill(dataSet);
            DataRow newRow = dataSet.Tables[0].NewRow();
            newRow[0] = newStudent.Id;
            newRow[1] = newStudent.Name;
            newRow[2] = newStudent.Age;

            dataSet.Tables[0].Rows.Add(newRow);

            dataAdapter.Update(dataSet);

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
        string query = $"SELECT * FROM Students ";

        SqlDataAdapter dataAdapter = new SqlDataAdapter(query,connection);
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

        
        Student student = null;

        try
        {
            connection.Open();
            dataAdapter.Fill(dataSet);

            DataTable dataTable = dataSet.Tables[0];

            DataRow studentFound = dataTable.Select("Id = " + studentId)[0];

            if(studentFound != null)
            {
                student = new Student
                {
                    Id = Convert.ToInt32(studentFound[0]),
                    Name = studentFound[1].ToString(),
                    Age = Convert.ToInt32(studentFound[2]),
                };

            }
            else
            {
                throw new Exception($"Student with Id {studentId} Not Found.");
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

        return student;
    }

    public List<Student> GetStudents()
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = $"SELECT * FROM Students;";

        dataAdapter = new SqlDataAdapter(query,connection);
       
        List<Student> students = new List<Student>();
        Student student = null;
       
        try
        {
           
            dataAdapter.Fill(dataSet);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                 student = new Student
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    Age = Convert.ToInt32(row[2])
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
            connection.Close();

        }

        return students;

    }


    public void UpdateStudent(Student student)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string searchQuery = $"SELECT * FROM Students";

        dataAdapter = new SqlDataAdapter(searchQuery,connection);

        SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);


       
        try
        {
            connection.Open();
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
          DataRow studentFound =   dataTable.Select("Id = " + student.Id)[0];
            if (studentFound != null)
            {
                studentFound[1] = student.Name;
                studentFound[2] = student.Age;
                dataAdapter.Update(dataSet);
            }
            else
            {
                throw new Exception("Student not Found!");
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

        string SearchQuery = $"SELECT * FROM Students";

        SqlDataAdapter dataAdapter = new SqlDataAdapter(SearchQuery,connection);

        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);


       


        try
        {
            connection.Open();
            dataAdapter.Fill(dataSet);

            DataTable studentsTable = dataSet.Tables[0];

            DataRow studentFound = studentsTable.Select("Id = " + studentId)[0];

            if (studentFound != null)
            {
                studentFound.Delete();
                dataAdapter.Update(dataSet);
            }
            else
            {
                throw new Exception($"Student with Id {studentId} Not Found!");
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
