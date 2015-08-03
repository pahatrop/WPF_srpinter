using System;
using System.Collections.Generic;
using System.Text;
using DataContracts;
using Models;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using RestDataProvider;

namespace RESTDataProvider
{
    public class RestDataProvider2 : IDataProvider
    {
        private static void PostHandler(string url, string data)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.Timeout = CommonSettings.GetTimeOut();
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.UTF8.GetBytes(data);
            req.ContentLength = sentData.Length;
            System.IO.Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
        }

        public static string GetHandler(string url)
        {
            string data = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ProtocolVersion = HttpVersion.Version10;
                request.Timeout = CommonSettings.GetTimeOut();
                request.KeepAlive = false;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                data = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                return data;
            }
            catch (Exception e)
            {
                MessageBox.Show("When you connect to the server had problems! Restart the application and try again.");
                return data;
            }
            return null;
        }

        public static string UploadFile(string url, string file)
        {
            WebClient wc = new WebClient();
            byte[] barray = Encoding.UTF8.GetBytes(url);
            string str = Encoding.UTF8.GetString(barray);
            byte[] responseArray = wc.UploadFile(str, "post", file);
            string respon = Encoding.UTF8.GetString(responseArray);
            return respon;
        }

        public List<University> GetAllUniversities()
        {
            string result = GetHandler(CommonSettings.GetAllUniversitiesString());
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<University>));
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(result));
            List<University> mm = (List<University>)js.ReadObject(ms);
            return mm;
        }
        public void CreateNewUniversity(University university)
        {
            PostHandler(CommonSettings.CreateNewUniversityUrlString(), CommonSettings.CreateNewUniversityDataString(university));
        }
        public void EditUniversity(University university)
        {
            PostHandler(CommonSettings.EditUniversityUrlString(), CommonSettings.EditUniversityDataString(university));
        }
        public void RemoveUniversity(int id)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(CommonSettings.RemoveUniversityString(id));
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                stream.ReadToEnd();
            }
        }

        public List<Department> GetAllDepartments(int id = -1)
        {
            string result;
            string address = CommonSettings.GetAllDepartmentsString(id);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(address);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                result = stream.ReadToEnd();
                if (result == "[]") return new List<Department>();
            }
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Department>));
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(result));
            List<Department> mm = (List<Department>)js.ReadObject(ms);
            resp.Close();
            return mm;
        }
        public void CreateNewDepartment(Department department)
        {
            PostHandler(CommonSettings.CreateNewDepartmentUrlString(),CommonSettings.CreateNewDepartmentDataString(department));
        }
        public void EditDepartment(Department department)
        {
            PostHandler(CommonSettings.EditDepartmentUrlString(),CommonSettings.EditDepartmentDataString(department));
        }
        public void RemoveDepartment(int id)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(CommonSettings.RemoveDepartmentString(id));
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                stream.ReadToEnd();
            }
        }

        public List<Student> GetAllStudents(int id = -1)
        {
            string result;
            string address = CommonSettings.GetAllStudentsString(id);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(address);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                result = stream.ReadToEnd();
            }
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Student>));
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(result));
            List<Student> mm = (List<Student>)js.ReadObject(ms);
            resp.Close();
            foreach (Student student in mm)
            {
                student.RealAvatar = student.Avatar;
                student.Avatar = CommonSettings.Host + student.Avatar;
            }
            return mm;
        }
        public void CreateNewStudent(Student student)
        {
            if (student.Avatar == "default")
            {
                student.Avatar = CommonSettings.GetDefaultAvatar(student.Sex);
            }
            PostHandler(CommonSettings.CreateNewStudentUrlString(), CommonSettings.CreateNewStudentDataString(student));
        }
        public void EditStudent(Student student)
        {
            PostHandler(CommonSettings.EditStudentUrlString(),CommonSettings.EditStudentDataString(student));
        }
        public void RemoveStudent(int id)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(CommonSettings.RemoveStudentString(id));
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                stream.ReadToEnd();
            }
        }

        public List<Teacher> GetAllTeachers(int id)
        {
            string result;
            string address = CommonSettings.GetAllTeachersString(id);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(address);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                result = stream.ReadToEnd();
                if (result == "[]") return new List<Teacher>();
            }
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Teacher>));
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(result));
            List<Teacher> mm = (List<Teacher>)js.ReadObject(ms);
            resp.Close();
            foreach (Teacher teacher in mm)
            {
                teacher.RealAvatar = teacher.Avatar;
                teacher.Avatar = CommonSettings.Host + teacher.Avatar;
            }
            return mm;
        }
        public void CreateNewTeacher(Teacher teacher)
        {
            if (teacher.Avatar == "default")
            {
                teacher.Avatar = CommonSettings.GetDefaultAvatar(0);
            }
            PostHandler(CommonSettings.CreateNewTeacherUrlString(), CommonSettings.CreateNewTeacherDataString(teacher));
        }
        public void EditTeacher(Teacher teacher)
        {
            PostHandler(CommonSettings.EditTeacherUrlString(), CommonSettings.EditTeacherDataString(teacher));
        }
        public void RemoveTeacher(int id)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(CommonSettings.RemoveTeacherString(id));
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                stream.ReadToEnd();
            }
        }

        public string SendImage(string image, int id, int type)
        {
            string resp = UploadFile(CommonSettings.UploadImageToServerUrl(id, type),image);
            return resp;
        }
    }
}
