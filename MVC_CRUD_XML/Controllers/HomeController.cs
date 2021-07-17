using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_XML.Models;

namespace MVC_CRUD_XML.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        EmployeeRepository _EmployeesRepository = new EmployeeRepository();

      
        public ActionResult Index(string Email_id, string Password)
        {
            try
            {
                List<EmployeeModel> AllEmployees = new List<EmployeeModel>();

                if (TempData["mySesstion0"] != null)
                {
                    Email_id = TempData["mySesstion0"].ToString(); Password = TempData["mySesstion1"].ToString();
                }
                if (Email_id != null && Password != null)
                {
                    AllEmployees = _EmployeesRepository.GetEmployees().Where(s => s.Email_id == Email_id && s.Password == Password).ToList();
                    if (AllEmployees.Count != 0)
                    {
                        Session["UserData"] = AllEmployees;
                        TempData["Email"] = AllEmployees[0].Email_id;
                        TempData["Pwd"] = AllEmployees[0].Password;
                        TempData["MyID"] = AllEmployees[0].ID;
                        return View(AllEmployees);
                    }
                    else
                    {
                        TempData["ErrorLogin"] = "username or password you entered is incorrect...";
                        return View("../Home/LoginPage");
                    }
                }
                else
                {
                    return View("../Home/LoginPage");
                }
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }

       
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
       
        
        [HttpGet]
        public ActionResult UpdateEmployeeDetails(int EmployeeID)
        {
            try
            {
                return View(_EmployeesRepository.GetEmployees().Where(s => s.ID == EmployeeID).ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateEmployeeDetails(EmployeeModel Employees, HttpPostedFileBase file)
        {
            try
            {
                _EmployeesRepository.EditEmployeesModel(Employees);
                TempData["Sucss"] = "You are record update successfully..";
                TempData["mySesstion0"] = Employees.Email_id; TempData["mySesstion1"] = Employees.Password;
                return RedirectToAction("../Home/Index");
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

     
        public ActionResult Delete(int id)
        {
            EmployeeModel AllEmployees = _EmployeesRepository.GetEmployeeByID(id);
            if (AllEmployees == null)
                return RedirectToAction("Index");
            return View(AllEmployees);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _EmployeesRepository.DeleteEmployeesModel(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        public ActionResult Signout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}
