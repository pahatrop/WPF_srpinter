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
        public int University { get; set; }
        public Department()
        {
        }
        public Department(int id, string name, int university)
        {
            Id = id;
            Name = name;
            University = university;
        }
    }
}
