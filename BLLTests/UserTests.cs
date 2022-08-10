using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLL.Tests
{
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            var Operations = new UserOperations();
            Operations.GetUsers();
            Operations.AddUser(new MUser());

            Operations.GetUserById(0);
        }
    }
}