using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MDoctor
    {

        public MDoctor()
        {

        }
        public MDoctor(string name, string cabinet)
        {
            Name = name;
            Cabinet = cabinet;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cabinet { get; set; }
    }
}
