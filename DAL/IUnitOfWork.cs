using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        ContextRepository<User> Users { get; }  //получение доступа к репозиториям
        ContextRepository<Doctor> Doctors { get; }
        ContextRepository<Patient> Patients { get; }

        ContextRepository<Appoinment> Appoinments { get; }
        void Save();
        void Dispose();
    }
}
