using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_ListOfAllEmployeePrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = HR_EmployeeManager.getAllEmployeeListDepartmentWise();
        gvListOfAllEmployee.DataSource = ds.Tables[0];
        gvListOfAllEmployee.DataBind();
    }
}