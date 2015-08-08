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
 public partial class AdminSTD_ClassSubjectEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassSubjectEmployeeData();
         		EmployeeIDLoad();
		ClassSubjectIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassSubjectEmployeeData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee ();
//	sTD_ClassSubjectEmployee.ClassSubjectEmployeeID=  int.Parse(ddlClassSubjectEmployeeID.SelectedValue);
	sTD_ClassSubjectEmployee.ClassSubjectEmployeeName=  txtClassSubjectEmployeeName.Text;
	sTD_ClassSubjectEmployee.EmployeeID=  ddlEmployeeID.SelectedValue;
	sTD_ClassSubjectEmployee.ClassSubjectID=  int.Parse(ddlClassSubjectID.SelectedValue);
	sTD_ClassSubjectEmployee.AddedBy=  Profile.card_id;
	sTD_ClassSubjectEmployee.AddedDate=  DateTime.Now;
	sTD_ClassSubjectEmployee.UpdatedBy=  Profile.card_id;
	sTD_ClassSubjectEmployee.UpdateDate = DateTime.Now; 
	int resutl =STD_ClassSubjectEmployeeManager.InsertSTD_ClassSubjectEmployee(sTD_ClassSubjectEmployee);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassSubjectEmployee.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_ClassSubjectEmployee sTD_ClassSubjectEmployee = new STD_ClassSubjectEmployee ();
	sTD_ClassSubjectEmployee.ClassSubjectEmployeeID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ClassSubjectEmployee.ClassSubjectEmployeeName=  txtClassSubjectEmployeeName.Text;
	sTD_ClassSubjectEmployee.EmployeeID=  ddlEmployeeID.SelectedValue;
	sTD_ClassSubjectEmployee.ClassSubjectID=  int.Parse(ddlClassSubjectID.SelectedValue);
	sTD_ClassSubjectEmployee.AddedBy=  Profile.card_id;
	sTD_ClassSubjectEmployee.AddedDate=  DateTime.Now;
	sTD_ClassSubjectEmployee.UpdatedBy=  Profile.card_id;
	sTD_ClassSubjectEmployee.UpdateDate = DateTime.Now; 
	bool  resutl =STD_ClassSubjectEmployeeManager.UpdateSTD_ClassSubjectEmployee(sTD_ClassSubjectEmployee);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassSubjectEmployee.aspx");
	}
	private void showSTD_ClassSubjectEmployeeData()
	{
	 	STD_ClassSubjectEmployee sTD_ClassSubjectEmployee  = new STD_ClassSubjectEmployee ();
	 	sTD_ClassSubjectEmployee = STD_ClassSubjectEmployeeManager.GetSTD_ClassSubjectEmployeeByClassSubjectEmployeeID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassSubjectEmployeeName.Text =sTD_ClassSubjectEmployee.ClassSubjectEmployeeName.ToString();
	 	ddlEmployeeID.SelectedValue  =sTD_ClassSubjectEmployee.EmployeeID.ToString();
	 	ddlClassSubjectID.SelectedValue  =sTD_ClassSubjectEmployee.ClassSubjectID.ToString();
	 	
	}
	
	private void EmployeeIDLoad()
	{
		try {
		DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
		ddlEmployeeID.DataValueField = "EmployeeID";
		ddlEmployeeID.DataTextField = "EmployeeNameNo";
		ddlEmployeeID.DataSource = ds.Tables[0];
		ddlEmployeeID.DataBind();
		ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void ClassSubjectIDLoad()
	{
		try {
		DataSet ds = STD_ClassSubjectManager.GetDropDownListAllSTD_ClassSubject();
		ddlClassSubjectID.DataValueField = "ClassSubjectID";
		ddlClassSubjectID.DataTextField = "ClassSubjectName";
		ddlClassSubjectID.DataSource = ds.Tables[0];
		ddlClassSubjectID.DataBind();
		ddlClassSubjectID.Items.Insert(0, new ListItem("Select ClassSubject >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

