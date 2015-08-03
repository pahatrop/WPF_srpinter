using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Specialty { get; set; }
        public int Parent { get; set; }
        public string Avatar { get; set; }
        public string RealAvatar { get; set; }
        public Teacher()
        {
        }
        public Teacher(int id, string firstname, string lastname, string middlename, string specialty, int university, string avatar = "default")
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
            Specialty = specialty;
            Parent = university;
            Avatar = avatar;
        }
    }
}
