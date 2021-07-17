using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD_XML.Models
{
    public class EmployeeModel
    {

        public EmployeeModel()
        {            
            this.ID = 0;
            this.First_Name = null;
            this.Last_Name = null;
            this.Email_id = null;
            this.Password = null;
            this.Dob = DateTime.Now;
            this.Gender = null;
            this.Cell_number = null;
            this.College = null;
            this.Adress = null;
            this.City = null;
            this.State = null;
            this.Pin = null;
        }
        public EmployeeModel(int id, string first_Name, string last_Name, string email_id,string password, DateTime dob, string gender, string cell_number, String college,string adress, string city, string state, string pin)
        {
            this.ID = id;
            this.First_Name = first_Name;
            this.Last_Name = last_Name;
            this.Email_id = email_id;
            this.Password = password;
            this.Dob = dob;
            this.Gender = gender;
            this.Cell_number = cell_number;
            this.College = college;
            this.Adress = adress;
            this.City = city;
            this.State = state;
            this.Pin = pin;

        }
        public EmployeeModel(string email_id, string pwd)
        {
            this.Email_id = email_id;
            this.Password = pwd;
        }
       
        
        public int ID { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Email name is required")]
        [DataType(DataType.EmailAddress)]
        public string Email_id { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Plaese select required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "CellNo is required")]
        [DataType(DataType.PhoneNumber)]
        public string Cell_number { get; set; }
        [Required(ErrorMessage = "College name is required")]
        public string College { get; set; }
        [Required(ErrorMessage = "Employee adress is required")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Your city is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Your sate is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Postal code is required")]
        [DataType(DataType.PostalCode)]
        public string Pin { get; set; }

    }
}