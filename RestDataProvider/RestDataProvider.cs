using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;
using Models;

namespace RESTDataProvider
{
    public class RestDataProvider2 : IDataProvider
    {
        public List<University> GetAllUniversities()
        {
            return new List<University>();
        }
        public void CreateNewUniversity(University university)
        {
        }
        public void EditUniversity(University university)
        {
        }
        public void RemoveUniversity(int id)
        {
        }

        public List<Department> GetAllDepartments(int id)
        {
            return new List<Department>();
        }
        public void CreateNewDepartment(Department department)
        {
        }
        public void EditDepartment(Department department)
        {
        }
        public void RemoveDepartment(int id)
        {
        }

        public List<Student> GetAllStudents(int id)
        {
            return new List<Student>();
        }
        public void CreateNewStudent(Student student)
        {
        }
        public void EditStudent(Student student)
        {
        }
        public void RemoveStudent(int id)
        {
        }

        public List<Teacher> GetAllTeachers(int id)
        {
            return new List<Teacher>();
        }
        public void CreateNewTeacher(Teacher teacher)
        {
        }
        public void EditTeacher(Teacher teacher)
        {
        }
        public void RemoveTeacher(int id)
        {
        }
    }
}
