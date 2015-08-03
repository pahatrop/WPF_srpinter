using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Language
    {
        public string Key;
        public string Value;
        public Language(string k, string v)
        {
            Key = k;
            Value = v;
        }
    }
}
