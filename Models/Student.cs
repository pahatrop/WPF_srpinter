﻿using System;
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
        public int Department { get; set; }
        public Student()
        {
        }
        public Student(int id, string firstname, string lastname, string middlename, int cource, string type, int department)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
            Cource = cource;
            Type = type;
            Department = department;
        }
    }
}