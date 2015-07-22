using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataContracts;
using System.Windows;

namespace WPF_sprinter
{
    public class DataController
    {
        public IDataProvider dataProvider;

        public DataController(IDataProvider dp)
        {
            dataProvider = dp;
        }

        private int t = 0;

        public async Task GetAllUniversities(Action<List<University>> action)
        {
            //System.Threading.Thread.Sleep(1000);
            List<University> univers = dataProvider.GetAllUniversities();
            foreach (University univer in univers)
            {
                univer.Departments = GetAllDepartments(univer.Id);
            }
            action(univers);
        }
        public async Task CreateNewUniversity(Action action, University university)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.CreateNewUniversity(university);
            action();
        }
        public async Task EditUniversity(Action action, University university)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.EditUniversity(university);
            action();
        }
        public async Task RemoveUniversity(Action action, int id)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.RemoveUniversity(id);
            action();
        }

        public async Task<List<Department>> GetAllDepartments(Action<List<Department>> action, int id)
        {
            System.Threading.Thread.Sleep(5000);
            List<Department> departments = dataProvider.GetAllDepartments(id);
            action(departments);
            return departments;
        }
        public List<Department> GetAllDepartments(int id)
        {
            List<Department> departments = dataProvider.GetAllDepartments(id);
            return departments;
        }
        public async Task CreateNewDepartment(Action action, Department department)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.CreateNewDepartment(department);
            action();
        }
        public async Task EditDepartment(Action action, Department department)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.EditDepartment(department);
            action();
        }
        public async Task RemoveDepartment(Action action, int id)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.RemoveDepartment(id);
            action();
        }

        public async Task GetAllStudents(Action<List<Student>> action, int id)
        {
            //System.Threading.Thread.Sleep(t);
            List<Student> students = dataProvider.GetAllStudents(id);
            action(students);
        }
        public async Task CreateNewStudent(Action action, Student student)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.CreateNewStudent(student);
            action();
        }
        public async Task EditStudent(Action action, Student student)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.EditStudent(student);
            action();
        }
        public async Task RemoveStudent(Action action, int id)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.RemoveStudent(id);
            action();
        }

        public async Task GetAllTeachers(Action<List<Teacher>> action, int id)
        {
            //System.Threading.Thread.Sleep(t);
            List<Teacher> teachers = dataProvider.GetAllTeachers(id);
            action(teachers);
        }
        public async Task CreateNewTeacher(Action action, Teacher teacher)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.CreateNewTeacher(teacher);
            action();
        }
        public async Task EditTeacher(Action action, Teacher teacher)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.EditTeacher(teacher);
            action();
        }
        public async Task RemoveTeacher(Action action, int id)
        {
            //System.Threading.Thread.Sleep(t);
            dataProvider.RemoveTeacher(id);
            action();
        }

    }
}
