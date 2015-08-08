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
 public partial class AdminSTD_ClassSubjectEmployeeStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassSubjectEmployeeStudentData();
         		ClassSubjectEmployeeIDLoad();
		StudentIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassSubjectEmployeeStudentData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent = new STD_ClassSubjectEmployeeStudent ();
//	sTD_ClassSubjectEmployeeStudent.ClassSubjectEmployeeStudentID=  int.Parse(ddlClassSubjectEmployeeStudentID.SelectedValue);
	sTD_ClassSubjectEmployeeStudent.ClassSubjectEmployeeID=  int.Parse(ddlClassSubjectEmployeeID.SelectedValue);
	sTD_ClassSubjectEmployeeStudent.StudentID=  ddlStudentID.SelectedValue;
	sTD_ClassSubjectEmployeeStudent.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ClassSubjectEmployeeStudent.AddedDate=  DateTime.Now;
	sTD_ClassSubjectEmployeeStudent.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ClassSubjectEmployeeStudent.UpdateDate=  DateTime.Now;
	sTD_ClassSubjectEmployeeStudent.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =STD_ClassSubjectEmployeeStudentManager.InsertSTD_ClassSubjectEmployeeStudent(sTD_ClassSubjectEmployeeStudent);
	Response.Redirect("AdminDisplaySTD_ClassSubjectEmployeeStudent.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent = new STD_ClassSubjectEmployeeStudent ();
	sTD_ClassSubjectEmployeeStudent.ClassSubjectEmployeeStudentID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ClassSubjectEmployeeStudent.ClassSubjectEmployeeID=  int.Parse(ddlClassSubjectEmployeeID.SelectedValue);
	sTD_ClassSubjectEmployeeStudent.StudentID=  ddlStudentID.SelectedValue;
	sTD_ClassSubjectEmployeeStudent.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ClassSubjectEmployeeStudent.AddedDate=  DateTime.Now;
	sTD_ClassSubjectEmployeeStudent.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ClassSubjectEmployeeStudent.UpdateDate=  DateTime.Now;
	sTD_ClassSubjectEmployeeStudent.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =STD_ClassSubjectEmployeeStudentManager.UpdateSTD_ClassSubjectEmployeeStudent(sTD_ClassSubjectEmployeeStudent);
	Response.Redirect("AdminDisplaySTD_ClassSubjectEmployeeStudent.aspx");
	}
	private void showSTD_ClassSubjectEmployeeStudentData()
	{
	 	STD_ClassSubjectEmployeeStudent sTD_ClassSubjectEmployeeStudent  = new STD_ClassSubjectEmployeeStudent ();
	 	sTD_ClassSubjectEmployeeStudent = STD_ClassSubjectEmployeeStudentManager.GetSTD_ClassSubjectEmployeeStudentByClassSubjectEmployeeStudentID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlClassSubjectEmployeeID.SelectedValue  =sTD_ClassSubjectEmployeeStudent.ClassSubjectEmployeeID.ToString();
	 	ddlStudentID.SelectedValue  =sTD_ClassSubjectEmployeeStudent.StudentID.ToString();
	 	ddlRowStatusID.SelectedValue  =sTD_ClassSubjectEmployeeStudent.RowStatusID.ToString();
	}
	
	private void ClassSubjectEmployeeIDLoad()
	{
		try {
		DataSet ds = STD_ClassSubjectEmployeeManager.GetDropDownListAllSTD_ClassSubjectEmployee();
		ddlClassSubjectEmployeeID.DataValueField = "ClassSubjectEmployeeID";
		ddlClassSubjectEmployeeID.DataTextField = "ClassSubjectEmployeeName";
		ddlClassSubjectEmployeeID.DataSource = ds.Tables[0];
		ddlClassSubjectEmployeeID.DataBind();
		ddlClassSubjectEmployeeID.Items.Insert(0, new ListItem("Select ClassSubjectEmployee >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void StudentIDLoad()
	{
		try {
		DataSet ds = STD_StudentManager.GetDropDownListAllSTD_Student();
		ddlStudentID.DataValueField = "StudentID";
		ddlStudentID.DataTextField = "StudentName";
		ddlStudentID.DataSource = ds.Tables[0];
		ddlStudentID.DataBind();
		ddlStudentID.Items.Insert(0, new ListItem("Select Student >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = STD_RowStatusManager.GetDropDownListAllSTD_RowStatus();
		ddlRowStatusID.DataValueField = "RowStatusID";
		ddlRowStatusID.DataTextField = "RowStatusName";
		ddlRowStatusID.DataSource = ds.Tables[0];
		ddlRowStatusID.DataBind();
		ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

