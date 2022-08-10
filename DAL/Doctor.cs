using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Doctor
    {

        public Doctor()
        {

        }
        public Doctor(string name, string cabinet)
        {
            Name = name;
            Cabinet = cabinet;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cabinet { get; set; }

    }
}
