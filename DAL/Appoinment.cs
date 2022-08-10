using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Appoinment
    {
        public Appoinment() { }
        public Appoinment(Doctor doctor, Patient patient) {
            Doctor = doctor;
            Patient = patient;
        }

        public int Id;
        public Doctor Doctor;
        public Patient Patient;
    }
}
