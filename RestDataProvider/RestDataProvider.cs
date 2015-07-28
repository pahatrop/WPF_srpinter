using System;
using System.Collections.Generic;
using System.Text;
using DataContracts;
using Models;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace RESTDataProvider
{
    public class RestDataProvider2 : IDataProvider
    {
        
        private static string host = "http://192.168.2.74:8888"; // REST server

        private static void PostHandler(string url, string data)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(data);
            req.ContentLength = sentData.Length;
            System.IO.Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
        }

        public static string GET(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string data = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        public List<University> GetAllUniversities()
        {
            string result;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host + "/api/get?request=University");
                if (request != null)
                {
                        using (var response = request.GetResponse())
                        {
                            using (var responseStream = response.GetResponseStream())
                            {
                                using (var stream = new StreamReader(responseStream))
                                {
                                    result = stream.ReadToEnd();
                                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<University>));
                                    MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(result));
                                    List<University> mm = (List<University>)js.ReadObject(ms);
                                    response.Dispose();
                                    response.Close();
                                    stream.Close();
                                    return mm;
                                }
                            }
                        }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void CreateNewUniversity(University university)
        {
            PostHandler(host + "/api/create", "queryName=University&name=" + university.Name + "&address=" + university.Address + "&level=" + university.Level);
        }
        public void EditUniversity(University university)
        {
            PostHandler(host + "/api/edit", "queryName=University&id=" + university.Id + "&name=" + university.Name + "&address=" + university.Address + "&level=" + university.Level);
        }
        public void RemoveUniversity(int id)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(host + "/api/remove?request=University&id="+id);
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
            string address;
            if(id==-1)
            {
                address = host + "/api/get?request=Department";
            }
            else
            {
                address = host + "/api/get?request=Department&id="+id;
            }
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(address);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                result = stream.ReadToEnd();
                if (result == "[]") return new List<Department>();
            }
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Department>));
            MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(result));
            List<Department> mm = (List<Department>)js.ReadObject(ms);
            return mm;
        }
        public void CreateNewDepartment(Department department)
        {
            PostHandler(host + "/api/create", "queryName=Department&Name=" + department.Name + "&Parent=" + department.Parent);
        }
        public void EditDepartment(Department department)
        {
            PostHandler(host + "/api/edit", "queryName=Department&id=" + department.Id + "&Name=" + department.Name + "&Parent=" + department.Parent);
        }
        public void RemoveDepartment(int id)
        {
        }

        public List<Student> GetAllStudents(int id)
        {
            string result;
            string address;
            if (id == -1)
            {
                address = host + "/api/get?request=Student";
            }
            else
            {
                address = host + "/api/get?request=Student&id=" + id;
            }
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(address);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                result = stream.ReadToEnd();
            }
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Student>));
            MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(result));
            List<Student> mm = (List<Student>)js.ReadObject(ms);
            return mm;
        }
        public void CreateNewStudent(Student student)
        {
            PostHandler(host + "/api/create", "queryName=Student&Firstname="+student.Firstname+"&Lastname="+student.Lastname+"&Middlename="+student.Middlename+"&Cource="+student.Cource+"&Type="+student.Type+"&Parent="+student.Parent+"&Avatar="+student.Avatar);
        }
        public void EditStudent(Student student)
        {
            PostHandler(host + "/api/edit", "queryName=Student&id="+student.Id+"&Firstname=" + student.Firstname + "&Lastname=" + student.Lastname + "&Middlename=" + student.Middlename + "&Cource=" + student.Cource + "&Type=" + student.Type + "&Parent=" + student.Parent + "&Avatar=" + student.Avatar);
        }
        public void RemoveStudent(int id)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(host + "/api/remove?request=Student&id=" + id);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(
            resp.GetResponseStream(), Encoding.UTF8))
            {
                stream.ReadToEnd();
            }
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
