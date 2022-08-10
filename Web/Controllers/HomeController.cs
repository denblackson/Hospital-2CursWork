using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SingUp()
        {
            return View();
        }

        public ActionResult Registered()
        {
            return View();
        }


        public ActionResult Admin()
        {

            return View();
        }

        public ActionResult Manager()
        {
            PatientOperations patientOperations = new PatientOperations();
            var data = patientOperations.GetPatients();
            List<string> data1 = new List<string>();
            foreach (MPatient mp in data)
            {
                data1.Add(mp.Id + " " + mp.Name);
            }
             
            return View(data1) ;
        }

        [HttpPost]
        public ActionResult Manager(DAL.Doctor doctor, DAL.Patient patient)
        {
            
                ViewBag.Message = " ";
           
            return View();
             
        }

        [HttpPost]
        public ActionResult Admin(string login, string role, string password, string passwordrepeat)
        {
            UserOperations userOperations = new UserOperations();
            List<MUser> qwe = userOperations.GetUsers();
            bool isUser = false;
            foreach (MUser mp in qwe)
            {
                if (mp.Name == login)
                    isUser = true;
            }
            if (isUser)
            {
                ViewBag.Message = "User with this login exists, go sign in!";
                return View();
            }
            else
            {
                if (!password.Equals(passwordrepeat))
                {
                    ViewBag.Message = "Passwords dont match";
                    return View();
                }

                UserOperations uo = new UserOperations();
                uo.AddUser(new MUser(login, password, role));
                ViewBag.Message = "Succesfully registred";
                return View();
            }
        }

         

        [HttpPost]
        public ActionResult Registered(string name)
        { 

              PatientOperations patientOperations = new PatientOperations();
              patientOperations.AddPatient(new MPatient(name, name));
             
            ViewBag.Message = "Succesfully Added To Appointment: ";

            return View();
        }


        

        [HttpPost]
        public ActionResult SingUp(string login, string password, string passwordrepeat)
        {
             
            UserOperations userOperations = new UserOperations();
            List<MUser> qwe = userOperations.GetUsers();
            bool isUser = false;
            foreach (MUser mp in qwe)
            {
                if (mp.Name == login)
                    isUser = true;
            }
            if (isUser)
            {
                ViewBag.Message = "User with this login exists, go sign in!";
                return View();
            }
            else
            {
                if (!password.Equals(passwordrepeat))
                {
                    ViewBag.Message = "Passwords dont match";
                    return View();
                }

                UserOperations uo = new UserOperations();
                uo.AddUser(new MUser(login, password, "Registered"));
                ViewBag.Message = "Succesfully registred";
                return Redirect("Registered"); }
        }
        
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            UserOperations op = new UserOperations();
            var listUsers = op.GetUsers();
            string role = "none";
            foreach (MUser u in  listUsers)
            {
                if (u.Password.Equals(password) && u.Name.Equals(login))
                {
                    role = u.Role;
                }
            }

            if (role.Equals("Manager"))
                return Redirect("Manager");
            else if (role.Equals("admin"))
                return Redirect("Admin");
            else if (role.Equals("Registered"))
                return Redirect("Registered");
            else
            {
                ViewBag.Message = "Incorrect login or password, try again";
                return View();
            }
                
        }
    }
}