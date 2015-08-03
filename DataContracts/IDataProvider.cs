using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataContracts
{
    public interface IDataProvider
    {
        List<University> GetAllUniversities();
        void CreateNewUniversity(University university);
        void RemoveUniversity(int id);
        void EditUniversity(University university);

        void CreateNewDepartment(Department dep);
        void RemoveDepartment(int id);
        List<Department> GetAllDepartments(int univerId);
        void EditDepartment(Department dep);

        void RemoveStudent(int id);
        void CreateNewStudent(Student st);
        void EditStudent(Student st);
        List<Student> GetAllStudents(int id);

        List<Teacher> GetAllTeachers(int id);
        void CreateNewTeacher(Teacher te);
        void RemoveTeacher(int id);
        void EditTeacher(Teacher te);

        string SendImage(string image, int id, int type);
    }
}
