using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVC_CRUD_XML.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private List<EmployeeModel> allEmployees;
        private XDocument EmployeesData;

        public EmployeeRepository()
        {
            try
            {
                allEmployees = new List<EmployeeModel>();
                EmployeesData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/EmployeeData.xml"));
                var Employees = from t in EmployeesData.Descendants("item")
                               select new EmployeeModel(
                                   (int)t.Element("id"),
                                   t.Element("first_name").Value,
                               t.Element("last_name").Value,
                               t.Element("email_id").Value,
                               t.Element("password").Value,
                               (DateTime)t.Element("dob"),
                               t.Element("gender").Value,
                               t.Element("cell_number").Value,
                               t.Element("college").Value,
                               t.Element("adress").Value,
                               t.Element("city").Value,
                               t.Element("state").Value,
                               t.Element("pin").Value);

                allEmployees.AddRange(Employees.ToList<EmployeeModel>());
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return allEmployees;
        }

        public List<string> Getemail()
        {
            throw new NotImplementedException();
        }

        public EmployeeModel GetEmployeeByEmailPwd(string email, string pwd)
        {
            return allEmployees.Find(t => t.Email_id == email && t.Password == pwd);
        }

        public EmployeeModel GetEmployeeByID(int id)
        {
            return allEmployees.Find(item => item.ID == id);            
        }

         

        public void EditEmployeesModel(EmployeeModel Employee)
        {
            try
            {
                XElement node = EmployeesData.Root.Elements("item").Where(i => (int)i.Element("id") == Employee.ID).FirstOrDefault();

                node.SetElementValue("first_name", Employee.First_Name);
                node.SetElementValue("last_name", Employee.Last_Name);
                node.SetElementValue("dob", Employee.Dob.ToShortDateString());
                node.SetElementValue("gender", Employee.Gender);
                node.SetElementValue("cell_number", Employee.Cell_number);
                node.SetElementValue("college", Employee.College);
                node.SetElementValue("adress", Employee.Adress);
                node.SetElementValue("city", Employee.City);
                node.SetElementValue("state", Employee.State);
                node.SetElementValue("pin", Employee.Pin);
                EmployeesData.Save(HttpContext.Current.Server.MapPath("~/App_Data/EmployeeData.xml"));
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        public void DeleteEmployeesModel(int id)
        {
            try
            {
                EmployeesData.Root.Elements("item").Where(i => (int)i.Element("id") == id).Remove();

                EmployeesData.Save(HttpContext.Current.Server.MapPath("~/App_Data/EmployeeData.xml"));

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }


        
    }
}