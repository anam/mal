using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
public partial class AdminHR_Department : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadHR_DepartmentData();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_DepartmentData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_Department hR_Department = new HR_Department();
        hR_Department.DepartmentName = txtDepartmentName.Text;
        hR_Department.JobLocation = txtJobLocation.Text;
        hR_Department.Description = txtDescription.Text;
        string userID = Profile.card_id;
        hR_Department.AddedBy = userID;
        hR_Department.AddedDate = DateTime.Now;
        hR_Department.ModifiedBy = userID;
        hR_Department.ModifiedDate = DateTime.Now;
        int resutl = HR_DepartmentManager.InsertHR_Department(hR_Department);
        Response.Redirect("AdminDisplayHR_Department.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_Department hR_Department = new HR_Department();
        hR_Department.DepartmentID = int.Parse(Request.QueryString["ID"].ToString());
        hR_Department.DepartmentName = txtDepartmentName.Text;
        hR_Department.JobLocation = txtJobLocation.Text;
        hR_Department.Description = txtDescription.Text;
        string userID = Profile.card_id;
        hR_Department.AddedBy = userID;
        hR_Department.AddedDate = DateTime.Now;
        hR_Department.ModifiedBy = userID;
        hR_Department.ModifiedDate = DateTime.Now;
        bool resutl = HR_DepartmentManager.UpdateHR_Department(hR_Department);
        Response.Redirect("AdminDisplayHR_Department.aspx");
    }

    private void showHR_DepartmentData()
    {
        HR_Department hR_Department = new HR_Department();
        hR_Department = HR_DepartmentManager.GetHR_DepartmentByDepartmentID(Int32.Parse(Request.QueryString["ID"]));
        txtDepartmentName.Text = hR_Department.DepartmentName.ToString();
        txtJobLocation.Text = hR_Department.JobLocation.ToString();
        txtDescription.Text = hR_Department.Description.ToString();
    }
}

