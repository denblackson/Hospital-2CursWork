using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL
{
    public class PatientOperations
    {

        IMapper SubjectToM = new MapperConfiguration(cfg => cfg.CreateMap<Patient, MPatient>()).CreateMapper();
        private readonly UnitOfWork _uow;

        public PatientOperations(UnitOfWork uow)
        {
            this._uow = uow;
        }

        public PatientOperations()
        {
            AppoinmentContext context = new AppoinmentContext();
            _uow = new UnitOfWork(context, new ContextRepository<User>(context), new ContextRepository<Doctor>(context), new ContextRepository<Patient>(context), new ContextRepository<Appoinment>(context));
        }

        public List<MPatient> GetPatients()
        {
            return SubjectToM.Map<IEnumerable<Patient>, List<MPatient>>(_uow.Patients.Get());

        }

        public MPatient GetpatientByID(int id)
        {
            return SubjectToM.Map<Patient, MPatient>(_uow.Patients.GetOne(x => (x.Id == id)));

        }

        public void AddPatient(MPatient patient)
        {
            _uow.Patients.Create(new Patient { Name = patient.Name , Login = patient.Login});
            _uow.Save();
        }

        public void DeletePatientByID(int id)
        {
            _uow.Patients.Remove(_uow.Patients.FindById(id));
            _uow.Save();
        }

    }
}
