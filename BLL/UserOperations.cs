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
    public class UserOperations
    {

        IMapper UserToM = new MapperConfiguration(cfg => cfg.CreateMap<User, MUser>()).CreateMapper();
        private readonly UnitOfWork _uow;
        public UserOperations(UnitOfWork uow)
        {
            this._uow = uow;
        }

        public UserOperations()
        {
            AppoinmentContext context = new AppoinmentContext();
            _uow = new UnitOfWork(context, new ContextRepository<User>(context), new ContextRepository<Doctor>(context), new ContextRepository<Patient>(context), new ContextRepository<Appoinment>(context));
        }

        public List<MUser> GetUsers()
        {
            return UserToM.Map<IEnumerable<User>, List<MUser>>(_uow.Users.Get());

        }
        public MUser GetUserById(int id)
        {
            return UserToM.Map<User, MUser>(_uow.Users.GetOne(x => (x.Id == id)));

        }
        public void AddUser(MUser user)
        {
            _uow.Users.Create(new User { Name = user.Name, Password = user.Password, Role = user.Role });
            _uow.Save();
        }

        public void DeletUserByID(int id)
        {
            _uow.Users.Remove(_uow.Users.FindById(id));
            _uow.Save();
        }

    }
}
