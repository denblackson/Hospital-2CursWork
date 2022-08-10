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
    [TestClass]
    public class DoctorTests
    {
        [TestMethod()]
        public void UserTest()
        {
            var Operations = new DoctorOperations();
            Operations.GetDoctors();
            Operations.AddDoctor(new MDoctor());

            Operations.GetDoctorByID(0);
        }
    }
}