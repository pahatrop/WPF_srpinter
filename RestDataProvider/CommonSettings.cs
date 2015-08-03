using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

 
namespace RestDataProvider
{
    public static class CommonSettings
    {
        public static string Host = @"http://192.168.2.74:8888";

        public static int GetTimeOut()
        {
            return 5000;
        }
        public static string GetAllUniversitiesString()
        {
            return Host + "/api/get?request=University";
        }
        public static string RemoveUniversityString(int id)
        {
            return Host + "/api/remove?request=University&id=" + id;
        }
        public static string RemoveDepartmentString(int id)
        {
            return Host + "/api/remove?request=Department&id=" + id;
        }
        public static string CreateNewDepartmentUrlString()
        {
            return Host + "/api/create";
        }
        public static string CreateNewDepartmentDataString(Department department)
        {
            return "queryName=Department&Name=" + department.Name + "&Parent=" + department.Parent;
        }
        public static string GetAllDepartmentsString(int id)
        {
            if (id == -1)
            {
                return Host + "/api/get?request=Department";
            }
            else
            {
                return Host + "/api/get?request=Department&id=" + id;
            }
        }
        public static string CreateNewUniversityUrlString()
        {
            return Host + "/api/create";
        }
        public static string CreateNewUniversityDataString(University university)
        {
            return "queryName=University&name=" + university.Name + "&address=" + university.Address + "&level=" + university.Level;
        }
        public static string EditUniversityUrlString()
        {
            return Host + "/api/edit";
        }
        public static string EditUniversityDataString(University university)
        {
            return "queryName=University&id=" + university.Id + "&name=" + university.Name + "&address=" + university.Address + "&level=" + university.Level;
        }
        public static string EditDepartmentUrlString()
        {
            return Host + "/api/edit";
        }
        public static string EditDepartmentDataString(Department department)
        {
            return "queryName=Department&id=" + department.Id + "&Name=" + department.Name + "&Parent=" + department.Parent;
        }
        public static string GetAllStudentsString(int id)
        {
            if (id == -1)
            {
                return Host + "/api/get?request=Student";
            }
            else
            {
                return Host + "/api/get?request=Student&id=" + id;
            }
        }
        public static string CreateNewStudentUrlString()
        {
            return Host + "/api/create";
        }
        public static string CreateNewStudentDataString(Student student)
        {
            return "queryName=Student&Firstname=" + student.Firstname + "&Lastname=" + student.Lastname + "&Middlename=" + student.Middlename + "&Cource=" + student.Cource.ToString() + "&Type=" + student.Type + "&Parent=" + student.Parent + "&Phone=" + student.Phone + "&Passport=" + student.Passport + "&Sex=" + student.Sex.ToString() + "&BirthDate=" + student.BirthDate + "&Address=" +student.Address + "&Avatar=" + student.Avatar;
        }
        public static string EditStudentUrlString()
        {
            return Host + "/api/edit";
        }
        public static string EditStudentDataString(Student student)
        {
            return "queryName=Student&id=" + student.Id + "&Firstname=" + student.Firstname + "&Lastname=" + student.Lastname + "&Middlename=" + student.Middlename + "&Cource=" + student.Cource + "&Type=" + student.Type + "&Parent=" + student.Parent + "&Phone=" + student.Phone + "&Passport=" + student.Passport + "&Sex=" + student.Sex + "&BirthDate=" + student.BirthDate + "&Address=" + student.Address + "&Avatar=" + student.Avatar;
        }
        public static string RemoveStudentString(int id)
        {
            return Host + "/api/remove?request=Student&id=" + id;
        }
        public static string GetAllTeachersString(int id)
        {
            if (id == -1)
            {
                return Host + "/api/get?request=Teacher";
            }
            else
            {
                return Host + "/api/get?request=Teacher&id=" + id;
            }
        }
        public static string UploadImageToServerUrl(int id, int type)
        {
            return Host + "/upload";
        }
        public static string GetDefaultAvatar(int sex)
        {
            if(sex == 0)
            {
                return "/user_images/default_male.png";
            }
            else
            {
                return "/user_images/default_female.png";
            }
        }
        public static string CreateNewTeacherUrlString()
        {
            return Host + "/api/create";
        }
        public static string CreateNewTeacherDataString(Teacher teacher)
        {
            return "queryName=Teacher&Firstname=" + teacher.Firstname + "&Lastname=" + teacher.Lastname + "&Middlename=" + teacher.Middlename + "&Specialty=" + teacher.Specialty + "&Parent=" + teacher.Parent + "&Avatar=" + teacher.Avatar;
        }
        public static string RemoveTeacherString(int id)
        {
            return Host + "/api/remove?request=Teacher&id=" + id;
        }
        public static string EditTeacherUrlString()
        {
            return Host + "/api/edit";
        }
        public static string EditTeacherDataString(Teacher teacher)
        {
            return "queryName=Teacher&id=" + teacher.Id + "&Firstname=" + teacher.Firstname + "&Lastname=" + teacher.Lastname + "&Middlename=" + teacher.Middlename + "&Specialty=" + teacher.Specialty + "&Parent=" + teacher.Parent + "&Avatar=" + teacher.Avatar;
        }

    }
}
