using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Patient
    {
        public Patient()
        {

        }
        public Patient(string name, string login)
        {
            Name = name;
            Login = login;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Login { get; set; }
    }
}
