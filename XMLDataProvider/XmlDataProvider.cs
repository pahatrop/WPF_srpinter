using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows;
using System.Threading;
using Models;
using DataContracts;

namespace XMLDataProvider
{
    public class XmlDataProvider : IDataProvider
    {
        private static string fs_xml_file_Universities = "Universities.xml";
        private static string fs_xml_file_Departments = "Departments.xml";
        private static string fs_xml_file_Students = "Students.xml";
        private static string fs_xml_file_Teachers = "Teachers.xml";

        private static string xml_root_Universities = "ArrayOfUniversity";
        private static string xml_root_Departments = "ArrayOfDepartment";
        private static string xml_root_Students = "ArrayOfStudent";
        private static string xml_root_Teachers = "ArrayOfTeacher";

        private int AutoIncrementIndex()
        {
            Random rnd = new Random();
            return rnd.Next(11, 9999999);
        }

        public List<University> GetAllUniversities()
        {
            try
            {
                List<University> universities = new List<University>();
                XmlSerializer mySerializer = new XmlSerializer(typeof(University[]), new XmlRootAttribute(xml_root_Universities));
                University[] r;
                using (FileStream myFileStream = new FileStream(fs_xml_file_Universities, FileMode.Open))
                {
                    r = (University[])mySerializer.Deserialize(myFileStream);
                    myFileStream.Close();
                }
                foreach (University university in r)
                {
                    universities.Add(university);
                }
                return universities;
            }
            catch(FileNotFoundException e)
            {
                string[] lines = { "<?xml version=\"1.0\" encoding=\"utf-8\"?>", "<"+xml_root_Universities+" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", "</"+xml_root_Universities+">" };
                System.IO.File.WriteAllLines(fs_xml_file_Universities, lines);
                return GetAllUniversities();
            }
            catch(IOException e)
            {
                return GetAllUniversities();
            }
        }
        public void CreateNewUniversity(University university)
        {
            List<University> universities = GetAllUniversities();
            if (university.Id == -1) university.Id = AutoIncrementIndex();
            universities.Add(university);
            TextWriter writer = new StreamWriter(fs_xml_file_Universities);
            XmlSerializer serializer = new XmlSerializer(typeof(List<University>));
            serializer.Serialize(writer, universities);
            writer.Close();
        }
        public void RemoveUniversity(int id)
        {
            List<University> TempUniversities = new List<University>();
            List<University> universities = GetAllUniversities();
            foreach(University university in universities)
            {
                if (university.Id != id) TempUniversities.Add(university);
            }
            TextWriter writer = new StreamWriter(fs_xml_file_Universities);
            XmlSerializer serializer = new XmlSerializer(typeof(List<University>));
            serializer.Serialize(writer, TempUniversities);
            writer.Close();
        }
        public void EditUniversity(University university)
        {
            RemoveUniversity(university.Id);
            CreateNewUniversity(university);
        }

        public List<Department> GetAllDepartments(int id = -1)
        {
            try
            {
                List<Department> departments = new List<Department>();
                XmlSerializer mySerializer = new XmlSerializer(typeof(Department[]), new XmlRootAttribute(xml_root_Departments));
                Department[] r;
                using (FileStream myFileStream = new FileStream(fs_xml_file_Departments, FileMode.Open))
                {
                    r = (Department[])mySerializer.Deserialize(myFileStream);
                }
                foreach (Department department in r)
                {
                    if(department.University==id || id == -1) departments.Add(department);
                }
                return departments;
            }
            catch (FileNotFoundException e)
            {
                string[] lines = { "<?xml version=\"1.0\" encoding=\"utf-8\"?>", "<" + xml_root_Departments + " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", "</" + xml_root_Departments + ">" };
                System.IO.File.WriteAllLines(fs_xml_file_Departments, lines);
                return GetAllDepartments(id);
            }
            catch(IOException e)
            {
                return GetAllDepartments(id);
            }
        }
        public void CreateNewDepartment(Department department)
        {
            List<Department> departments = GetAllDepartments();
            if (department.Id == -1) department.Id = AutoIncrementIndex();
            departments.Add(department);
            TextWriter writer = new StreamWriter(fs_xml_file_Departments);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Department>));
            serializer.Serialize(writer, departments);
            writer.Close();
        }
        public void RemoveDepartment(int id)
        {
            List<Department> TempDepartments = new List<Department>();
            List<Department> departments = GetAllDepartments();
            foreach (Department department in departments)
            {
                if (department.Id != id) TempDepartments.Add(department);
            }
            TextWriter writer = new StreamWriter(fs_xml_file_Departments);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Department>));
            serializer.Serialize(writer, TempDepartments);
            writer.Close();
        }
        public void EditDepartment(Department department)
        {
            RemoveDepartment(department.Id);
            CreateNewDepartment(department);
        }

        public List<Student> GetAllStudents(int id = -1)
        {
            try
            {
                List<Student> students = new List<Student>();
                XmlSerializer mySerializer = new XmlSerializer(typeof(Student[]), new XmlRootAttribute(xml_root_Students));
                Student[] r;
                using (FileStream myFileStream = new FileStream(fs_xml_file_Students, FileMode.Open))
                {
                    r = (Student[])mySerializer.Deserialize(myFileStream);
                }
                foreach (Student student in r)
                {
                    if(student.Department==id || id==-1) students.Add(student);
                }
                return students;
            }
            catch (FileNotFoundException e)
            {
                string[] lines = { "<?xml version=\"1.0\" encoding=\"utf-8\"?>", "<" + xml_root_Students + " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", "</" + xml_root_Students + ">" };
                System.IO.File.WriteAllLines(fs_xml_file_Students, lines);
                return GetAllStudents(id);
            }
            catch(IOException e)
            {
                return GetAllStudents();
            }
        }
        public void CreateNewStudent(Student student)
        {
            List<Student> students = GetAllStudents();
            if (student.Id == -1) student.Id = AutoIncrementIndex();
            students.Add(student);
            TextWriter writer = new StreamWriter(fs_xml_file_Students);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            serializer.Serialize(writer, students);
            writer.Close();
        }
        public void RemoveStudent(int id)
        {
            List<Student> TempStudents = new List<Student>();
            List<Student> students = GetAllStudents();
            foreach (Student student in students)
            {
                if (student.Id != id) TempStudents.Add(student);
            }
            TextWriter writer = new StreamWriter(fs_xml_file_Students);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            serializer.Serialize(writer, TempStudents);
            writer.Close();
        }
        public void EditStudent(Student student)
        {
            RemoveStudent(student.Id);
            CreateNewStudent(student);
        }

        public List<Teacher> GetAllTeachers(int id = -1)
        {
            try
            {
                List<Teacher> teachers = new List<Teacher>();
                XmlSerializer mySerializer = new XmlSerializer(typeof(Teacher[]), new XmlRootAttribute(xml_root_Teachers));
                Teacher[] r;
                using (FileStream myFileStream = new FileStream(fs_xml_file_Teachers, FileMode.Open))
                {
                    r = (Teacher[])mySerializer.Deserialize(myFileStream);
                }
                foreach (Teacher teacher in r)
                {
                    if(teacher.Department==id || id==-1) teachers.Add(teacher);
                }
                return teachers;
            }
            catch (FileNotFoundException e)
            {
                string[] lines = { "<?xml version=\"1.0\" encoding=\"utf-8\"?>", "<" + xml_root_Teachers + " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", "</" + xml_root_Teachers + ">" };
                System.IO.File.WriteAllLines(fs_xml_file_Teachers, lines);
                return GetAllTeachers();
            }
            catch (IOException e)
            {
                return GetAllTeachers();
            }
        }
        public void CreateNewTeacher(Teacher teacher)
        {
            List<Teacher> teachers = GetAllTeachers();
            if (teacher.Id == -1) teacher.Id = AutoIncrementIndex();
            teachers.Add(teacher);
            TextWriter writer = new StreamWriter(fs_xml_file_Teachers);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Teacher>));
            serializer.Serialize(writer, teachers);
            writer.Close();
        }
        public void RemoveTeacher(int id)
        {
            List<Teacher> TempTeachers = new List<Teacher>();
            List<Teacher> teachers = GetAllTeachers();
            foreach (Teacher teacher in teachers)
            {
                if (teacher.Id != id) TempTeachers.Add(teacher);
            }
            TextWriter writer = new StreamWriter(fs_xml_file_Teachers);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Teacher>));
            serializer.Serialize(writer, TempTeachers);
            writer.Close();
        }
        public void EditTeacher(Teacher teacher)
        {
            RemoveTeacher(teacher.Id);
            CreateNewTeacher(teacher);
        }
        
    }
}
