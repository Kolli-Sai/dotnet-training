using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB_Practice
{
    internal class StudentOperations
    {
       static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees;Integrated Security=True;Pooling=False;";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;
        SqlDataReader dataReader;
        public void CreateNewStudent(Student newStudent)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO Students(Id,Name) VALUES('{newStudent.Id}','{newStudent.Name}')";
                command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();


                connection.Close();
            }
            catch (Exception)
            {

               throw;
            }
            

        }
    }
}
