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
 public partial class AdminSTD_ClassSubjectStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassSubjectStudentData();
         		StudentIDLoad();
		ClassSubjectIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassSubjectStudentData();
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent();
            //	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(ddlClassSubjectStudentID.SelectedValue);
            sTD_ClassSubjectStudent.ClassSubjectStudentName = txtClassSubjectStudentName.Text;
            sTD_ClassSubjectStudent.StudentID = ddlStudentID.SelectedValue;
            sTD_ClassSubjectStudent.ClassSubjectID = int.Parse(ddlClassSubjectID.SelectedValue);
            sTD_ClassSubjectStudent.AddedBy = Profile.card_id;
            sTD_ClassSubjectStudent.AddedDate = DateTime.Now;
            sTD_ClassSubjectStudent.UpdatedBy = Profile.card_id;
            sTD_ClassSubjectStudent.UpdateDate = DateTime.Now;
            sTD_ClassSubjectStudent.RowStatusID = 1;
            int resutl = STD_ClassSubjectStudentManager.InsertSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
            Response.Redirect("AdminDisplaySTD_ClassSubjectStudent.aspx");
        }
        catch (Exception ex)
        {

        }
    }
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_ClassSubjectStudent sTD_ClassSubjectStudent = new STD_ClassSubjectStudent ();
	sTD_ClassSubjectStudent.ClassSubjectStudentID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ClassSubjectStudent.ClassSubjectStudentName=  txtClassSubjectStudentName.Text;
	sTD_ClassSubjectStudent.StudentID=  ddlStudentID.SelectedValue;
	sTD_ClassSubjectStudent.ClassSubjectID=  int.Parse(ddlClassSubjectID.SelectedValue);
	sTD_ClassSubjectStudent.AddedBy=  Profile.card_id;
	sTD_ClassSubjectStudent.AddedDate=  DateTime.Now;
	sTD_ClassSubjectStudent.UpdatedBy=  Profile.card_id;
	sTD_ClassSubjectStudent.UpdateDate=  DateTime.Now;
	bool  resutl =STD_ClassSubjectStudentManager.UpdateSTD_ClassSubjectStudent(sTD_ClassSubjectStudent);
	Response.Redirect("AdminDisplaySTD_ClassSubjectStudent.aspx");
	}
	private void showSTD_ClassSubjectStudentData()
	{
	 	STD_ClassSubjectStudent sTD_ClassSubjectStudent  = new STD_ClassSubjectStudent ();
	 	sTD_ClassSubjectStudent = STD_ClassSubjectStudentManager.GetSTD_ClassSubjectStudentByClassSubjectStudentID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassSubjectStudentName.Text =sTD_ClassSubjectStudent.ClassSubjectStudentName.ToString();
	 	ddlStudentID.SelectedValue  =sTD_ClassSubjectStudent.StudentID.ToString();
	 	ddlClassSubjectID.SelectedValue  =sTD_ClassSubjectStudent.ClassSubjectID.ToString();
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

