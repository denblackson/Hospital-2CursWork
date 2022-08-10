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
   public  class AppoinmentOperations
    {
        IMapper SubjectToM = new MapperConfiguration(cfg => cfg.CreateMap<Appoinment, MAppoinment>()).CreateMapper();
        private readonly UnitOfWork _uow;

        public AppoinmentOperations(UnitOfWork uow)
        {
            this._uow = uow;
        }

        public AppoinmentOperations()
        {
            AppoinmentContext context = new AppoinmentContext();
            _uow = new UnitOfWork(context, new ContextRepository<User>(context), new ContextRepository<Doctor>(context), new ContextRepository<Patient>(context), new ContextRepository<Appoinment>(context));
        }

        public List<Appoinment> GetAppoinments()
        {
            return SubjectToM.Map<IEnumerable<Appoinment>, List<Appoinment>>(_uow.Appoinments.Get());

        }

        public MAppoinment GetAppoinmentByID(int id)
        {
            return SubjectToM.Map<Appoinment, MAppoinment>(_uow.Appoinments.GetOne(x => (x.Id == id)));

        }

        public void AddAppoinment(Appoinment appoinment)
        {
            _uow.Appoinments.Create(new Appoinment { Doctor = appoinment.Doctor, Patient = appoinment.Patient });
            _uow.Save();
        }

        public void DeleteAppoinmentByID(int id)
        {
            _uow.Appoinments.Remove(_uow.Appoinments.FindById(id));
            _uow.Save();
        }

    }
}
