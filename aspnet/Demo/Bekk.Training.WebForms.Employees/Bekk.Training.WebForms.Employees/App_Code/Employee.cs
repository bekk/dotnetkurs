using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bekk.Training.WebForms.Employees.App_Code
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }
    }

    public class Email
    {
        public Email(string email)
        {
            Address = email;
        }
        public string Address{ get; set; }
        
        public override string ToString()
        {
            return Address;
        }
    }

    public class Phone
    {
        public Phone(string number)
        {
            Number = number;
        }
        public string Number { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}