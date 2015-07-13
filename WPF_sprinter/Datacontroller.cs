using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_sprinter
{
    public class DataController
    {
        public IDataProvider dataProvider;

        public DataController(IDataProvider dp)
        {
            dataProvider = dp;
        }

        public List<University> GetAllUniversities()
        {
            List<University> univers = dataProvider.GetAllUniversities();
            return univers;
        }
        public void CreateNewUniversity(University university)
        {
            dataProvider.CreateNewUniversity(university);
        }
        public void EditUniversity(University university)
        {
            dataProvider.EditUniversity(university);
        }
        public void RemoveUniversity(int id)
        {
            dataProvider.RemoveUniversity(id);
        }

        public List<Department> GetAllDepartments(int id)
        {
            return dataProvider.GetAllDepartments(id);
        }
        public void CreateNewDepartment(Department department)
        {
            dataProvider.CreateNewDepartment(department);
        }
        public void EditDepartment(Department department)
        {
            dataProvider.EditDepartment(department);
        }
        public void RemoveDepartment(int id)
        {
            dataProvider.RemoveDepartment(id);
        }

        public List<Student> GetAllStudents(int id)
        {
            return dataProvider.GetAllStudents(id);
        }
        public void CreateNewStudent(Student student)
        {
            dataProvider.CreateNewStudent(student);
        }
        public void EditStudent(Student student)
        {
            dataProvider.EditStudent(student);
        }
        public void RemoveStudent(int id)
        {
            dataProvider.RemoveStudent(id);
        }

        public List<Teacher> GetAllTeachers(int id)
        {
            return dataProvider.GetAllTeachers(id);
        }
        public void CreateNewTeacher(Teacher teacher)
        {
            dataProvider.CreateNewTeacher(teacher);
        }
        public void EditTeacher(Teacher teacher)
        {
            dataProvider.EditTeacher(teacher);
        }
        public void RemoveTeacher(int id)
        {
            dataProvider.RemoveTeacher(id);
        }

    }
}
