using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_XML.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeModel> GetEmployees();
        List<string> Getemail();
        EmployeeModel GetEmployeeByID(int id);
        EmployeeModel GetEmployeeByEmailPwd(string email, string pwd);
        void DeleteEmployeesModel(int id);
        void EditEmployeesModel(EmployeeModel Employee);
    }
}