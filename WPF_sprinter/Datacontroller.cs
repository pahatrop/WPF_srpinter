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

        private int t = 2000;

        public List<University> GetAllUniversities()
        {
            System.Threading.Thread.Sleep(t);
            List<University> univers = dataProvider.GetAllUniversities();
            return univers;
        }
        public void CreateNewUniversity(University university)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.CreateNewUniversity(university);
        }
        public void EditUniversity(University university)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.EditUniversity(university);
        }
        public void RemoveUniversity(int id)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.RemoveUniversity(id);
        }

        public List<Department> GetAllDepartments(int id)
        {
            System.Threading.Thread.Sleep(t);
            return dataProvider.GetAllDepartments(id);
        }
        public void CreateNewDepartment(Department department)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.CreateNewDepartment(department);
        }
        public void EditDepartment(Department department)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.EditDepartment(department);
        }
        public void RemoveDepartment(int id)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.RemoveDepartment(id);
        }

        public List<Student> GetAllStudents(int id)
        {
            System.Threading.Thread.Sleep(t);
            return dataProvider.GetAllStudents(id);
        }
        public void CreateNewStudent(Student student)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.CreateNewStudent(student);
        }
        public void EditStudent(Student student)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.EditStudent(student);
        }
        public void RemoveStudent(int id)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.RemoveStudent(id);
        }

        public List<Teacher> GetAllTeachers(int id)
        {
            System.Threading.Thread.Sleep(t);
            return dataProvider.GetAllTeachers(id);
        }
        public void CreateNewTeacher(Teacher teacher)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.CreateNewTeacher(teacher);
        }
        public void EditTeacher(Teacher teacher)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.EditTeacher(teacher);
        }
        public void RemoveTeacher(int id)
        {
            System.Threading.Thread.Sleep(t);
            dataProvider.RemoveTeacher(id);
        }

    }
}
