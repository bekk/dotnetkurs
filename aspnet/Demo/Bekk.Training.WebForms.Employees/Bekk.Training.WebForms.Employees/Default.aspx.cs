using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bekk.Training.WebForms.Employees.App_Code;

namespace Bekk.Training.WebForms.Employees
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var allEmployees = new List<Employee>
            {
                new Employee{Name = "Donald Duck", Position = "Senior Consultant", Phone = new Phone("87654321"), Email = new Email("donald@duck.com")},
                new Employee{Name = "Dolly Duck", Position = "Manager", Phone = new Phone("12345678"), Email = new Email("dolly@duck.com")}
            };

            EmployeeGrid.DataSource = allEmployees;
            EmployeeGrid.DataBind();
        }
    }
}
