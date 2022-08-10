using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MPatient
    {
        public MPatient()
        {

        }
        public MPatient(string name, string login)
        {
            Name = name;
            Login = login;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Login { get; set; }

        //public string toString1()
        //{
        //    return Id + " " + Name + " " + Login;
        //}
    }
}
 
