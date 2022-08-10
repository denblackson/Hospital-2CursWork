using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;

namespace BLL
{
    public class DoctorOperations
    {

        IMapper SubjectToM = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, MDoctor>()).CreateMapper();
        private readonly UnitOfWork _uow;

        public DoctorOperations(UnitOfWork uow)
        {
            this._uow = uow;
        }

        public DoctorOperations()
        {
            AppoinmentContext context = new AppoinmentContext();
            _uow = new UnitOfWork(context, new ContextRepository<User>(context), new ContextRepository<Doctor>(context), new ContextRepository<Patient>(context), new ContextRepository<Appoinment>(context));
        }

        public List<MDoctor> GetDoctors()
        {
            return SubjectToM.Map<IEnumerable<Doctor>, List<MDoctor>>(_uow.Doctors.Get());

        }

        public MDoctor GetDoctorByID(int id)
        {
            return SubjectToM.Map<Doctor, MDoctor>(_uow.Doctors.GetOne(x => (x.Id == id)));

        }

        public void AddDoctor(MDoctor doctor)
        {
            _uow.Doctors.Create(new Doctor { Name = doctor.Name, Cabinet = doctor.Cabinet });
            _uow.Save();
        }

        public void DeleteDoctorByID(int id)
        {
            _uow.Doctors.Remove(_uow.Doctors.FindById(id));
            _uow.Save();
        }

    }
}
