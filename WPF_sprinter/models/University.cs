﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_sprinter
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Level { get; set; }
        public University()
        {
        }
        public University(int id, string name, string address, int level)
        {
            Id = id;
            Name = name;
            Address = address;
            Level = level;
        }
    }
}
