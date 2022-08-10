using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MAppoinment
    {
        public MAppoinment() { }
        public MAppoinment(MDoctor doctor,MPatient patient)
        {
            Doctor = doctor;
            Patient = patient;
        }

        public int Id;
        public MDoctor Doctor;
        public MPatient Patient;
    }
}
