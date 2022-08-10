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
    public class PatientTests
    {
        [TestMethod()]
        public void UserTest()
        {
            var Operations = new PatientOperations();
            Operations.GetPatients();
            Operations.AddPatient(new MPatient());
            Operations.GetpatientByID(0);
        }
    }
}