using Microsoft.AspNetCore.Mvc;

namespace CRUD_Web_Api.Models
{

    public interface IStudentOperations
    {
        public void CreateStudent(Student newStudent);
        public Student GetStudent(int id);
        public List<Student> GetStudents();
        public void DeleteStudent(int id);
        public void UpdateStudent(Student newStudent, int id);
    }
    public class StudentOperations : IStudentOperations
    {
        readonly List<Student> students = [];
        public void CreateStudent( Student newStudent)
        {
            students.Add(new Student()
            {
                Id = newStudent.Id,
                Name = newStudent.Name,
                Age = newStudent.Age,
            });
        }
        public Student GetStudent(int id)
        {
            Student student = null;

            foreach (var item in students)
            {
                if (item.Id == id)
                {
                    student = item;
                    break;
                }
            }
            return student;
        }
        public List<Student> GetStudents()
        {
            return students;
        }
        public void DeleteStudent(int id)
        {
            foreach (var item in students)
            {
                if (item.Id == id)
                {
                    students.Remove(item);

                }
            }
        }
        public void UpdateStudent( Student newStudent, int id)
        {

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students[i] = newStudent;
                }
            }
        }
    }
}
