using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Level { get; set; }
        public string Identification { get { return "University"; } }
        public List<Department> Departments { get; set; }
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
