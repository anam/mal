using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class idCardPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetEmployees();
        }
    }

    protected void GetEmployees()
    {
        try
        {
            string sqlSearchString = "";
            if (Request.QueryString["EmpID"] != null)
            {
                sqlSearchString = " Where ";
                string ID = Request.QueryString["EmpID"].ToString();
                sqlSearchString += " HR_Employee.EmployeeID ='" + ID + "'";
            }
            else if (Request.QueryString["DepartID"] != null)
            {
                sqlSearchString = " Where HR_Employee.Flag = 1";
                string ID = Request.QueryString["DepartID"].ToString();
                if (Convert.ToInt32(ID) > 0)
                {
                    sqlSearchString += " And HR_Employee.DesignationID in(select HR_Designation.DesignationID from HR_Designation where HR_Designation.DepartmentID =" + ID + ")";
                }
            }
            rptIdcard.DataSource = HR_EmployeeManager.GetAllHR_EmployeeIDInfoBySearch(sqlSearchString);
            rptIdcard.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void rptIdcard_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Label lblimagename = (Label)e.Item.FindControl("lblPhoto");

            Image imgphoto = (Image)e.Item.FindControl("imgEmployee");

            imgphoto.ImageUrl = "~/HR/upload/employeer/" + lblimagename.Text;
        }
    }
}