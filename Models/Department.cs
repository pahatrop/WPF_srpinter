using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public string Identification { get { return "Department"; } }
        public Department()
        {
        }
        public Department(int id, string name, int university)
        {
            Id = id;
            Name = name;
            Parent = university;
        }
    }
}
