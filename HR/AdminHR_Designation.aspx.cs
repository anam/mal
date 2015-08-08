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
public partial class AdminHR_Designation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DepartmentIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_DesignationData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_Designation hR_Designation = new HR_Designation();
        //	hR_Designation.DesignationID=  int.Parse(ddlDesignationID.SelectedValue);
        hR_Designation.DesignationName = txtDesignationName.Text;
        hR_Designation.DepartmentID = int.Parse(ddlDepartmentID.SelectedValue);
        hR_Designation.Supervisor = txtSupervisor.Text;
        hR_Designation.JobResponsibility = txtJobResponsibility.Text;
        string userID = Profile.card_id;
        hR_Designation.AddedBy = userID;
        hR_Designation.AddedDate = DateTime.Now;
        hR_Designation.ModifiedBy = userID;
        hR_Designation.ModifiedDate = DateTime.Now;
        int resutl = HR_DesignationManager.InsertHR_Designation(hR_Designation);
        Response.Redirect("AdminDisplayHR_Designation.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_Designation hR_Designation = new HR_Designation();
        hR_Designation.DesignationID = int.Parse(Request.QueryString["ID"].ToString());
        hR_Designation.DesignationName = txtDesignationName.Text;
        hR_Designation.DepartmentID = int.Parse(ddlDepartmentID.SelectedValue);
        hR_Designation.Supervisor = txtSupervisor.Text;
        hR_Designation.JobResponsibility = txtJobResponsibility.Text;
        string userID = Profile.card_id;
        hR_Designation.AddedBy = userID;
        hR_Designation.AddedDate = DateTime.Now;
        hR_Designation.ModifiedBy = userID;
        hR_Designation.ModifiedDate = DateTime.Now;
        bool resutl = HR_DesignationManager.UpdateHR_Designation(hR_Designation);
        Response.Redirect("AdminDisplayHR_Designation.aspx");
    }

    private void showHR_DesignationData()
    {
        HR_Designation hR_Designation = new HR_Designation();
        hR_Designation = HR_DesignationManager.GetHR_DesignationByDesignationID(Int32.Parse(Request.QueryString["ID"]));
        txtDesignationName.Text = hR_Designation.DesignationName.ToString();
        ddlDepartmentID.SelectedValue = hR_Designation.DepartmentID.ToString();
        txtSupervisor.Text = hR_Designation.Supervisor.ToString();
        txtJobResponsibility.Text = hR_Designation.JobResponsibility.ToString();
    }

    private void DepartmentIDLoad()
    {
        try
        {
            DataSet ds = HR_DepartmentManager.GetDropDownListAllHR_Department();
            ddlDepartmentID.DataValueField = "DepartmentID";
            ddlDepartmentID.DataTextField = "DepartmentName";
            ddlDepartmentID.DataSource = ds.Tables[0];
            ddlDepartmentID.DataBind();
            ddlDepartmentID.Items.Insert(0, new ListItem("Select Department >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

