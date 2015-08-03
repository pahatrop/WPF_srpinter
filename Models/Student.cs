using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public int Cource { get; set; }
        public string Type { get; set; }
        public int Parent { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public int Sex { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string RealAvatar;
        public Student()
        { 
        }
        public Student(int id, string firstname, string lastname, string middlename, int cource, string type, int parent, string phone, string passport, int sex, string birthdate, string address, string avatar = "Default")
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
            Cource = cource;
            Type = type;
            Parent = parent;
            Phone = phone;
            Passport = passport;
            Sex = sex;
            BirthDate = birthdate;
            Address = address;
            Avatar = avatar;
        }
    }
}
