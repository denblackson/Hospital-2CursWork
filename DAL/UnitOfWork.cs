using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly AppoinmentContext _db;

        public UnitOfWork(AppoinmentContext db, ContextRepository<User> userRepository,
            ContextRepository<Doctor> doctorRepository, ContextRepository<Patient> patientRepository, ContextRepository<Appoinment> appoinmentRepository)
        {
            _db = db;

            Users = userRepository;
            Patients = patientRepository;
            Doctors = doctorRepository;
            Appoinments = appoinmentRepository;
        }


        public ContextRepository<User> Users { get; } //получение репозиториев 

        public ContextRepository<Doctor> Doctors { get; }

        public ContextRepository<Patient> Patients { get; }

        public ContextRepository<Appoinment> Appoinments { get; }


        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed;


        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _db.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
