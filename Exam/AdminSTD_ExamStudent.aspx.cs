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
 public partial class AdminSTD_ExamStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ExamStudentData();
         		ExamIDLoad();
		StudentIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ExamStudentData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_ExamStudent sTD_ExamStudent = new STD_ExamStudent ();
//	sTD_ExamStudent.ExamStudentID=  int.Parse(ddlExamStudentID.SelectedValue);
	sTD_ExamStudent.ExamStudent=  txtExamStudent.Text;
	sTD_ExamStudent.ExamID=  int.Parse(ddlExamID.SelectedValue);
	sTD_ExamStudent.StudentID=  ddlStudentID.SelectedValue;
	sTD_ExamStudent.ObtainedMark=  decimal.Parse(txtObtainedMark.Text);
	sTD_ExamStudent.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamStudent.AddedDate=  DateTime.Now;
	sTD_ExamStudent.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamStudent.UpdateDate=  DateTime.Now;
	int resutl =STD_ExamStudentManager.InsertSTD_ExamStudent(sTD_ExamStudent);
	Response.Redirect("AdminDisplaySTD_ExamStudent.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_ExamStudent sTD_ExamStudent = new STD_ExamStudent ();
	sTD_ExamStudent.ExamStudentID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ExamStudent.ExamStudent=  txtExamStudent.Text;
	sTD_ExamStudent.ExamID=  int.Parse(ddlExamID.SelectedValue);
	sTD_ExamStudent.StudentID=  ddlStudentID.SelectedValue;
	sTD_ExamStudent.ObtainedMark=  decimal.Parse(txtObtainedMark.Text);
	sTD_ExamStudent.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamStudent.AddedDate=  DateTime.Now;
	sTD_ExamStudent.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamStudent.UpdateDate=  DateTime.Now;
	bool  resutl =STD_ExamStudentManager.UpdateSTD_ExamStudent(sTD_ExamStudent);
	Response.Redirect("AdminDisplaySTD_ExamStudent.aspx");
	}
	private void showSTD_ExamStudentData()
	{
	 	STD_ExamStudent sTD_ExamStudent  = new STD_ExamStudent ();
	 	sTD_ExamStudent = STD_ExamStudentManager.GetSTD_ExamStudentByExamStudentID(Int32.Parse(Request.QueryString["ID"]));
	 	txtExamStudent.Text =sTD_ExamStudent.ExamStudent.ToString();
	 	ddlExamID.SelectedValue  =sTD_ExamStudent.ExamID.ToString();
	 	ddlStudentID.SelectedValue  =sTD_ExamStudent.StudentID.ToString();
	 	txtObtainedMark.Text =sTD_ExamStudent.ObtainedMark.ToString();
	}
	
	private void ExamIDLoad()
	{
		try {
		DataSet ds = STD_ExamManager.GetDropDownListAllSTD_Exam();
		ddlExamID.DataValueField = "ExamID";
		ddlExamID.DataTextField = "ExamName";
		ddlExamID.DataSource = ds.Tables[0];
		ddlExamID.DataBind();
		ddlExamID.Items.Insert(0, new ListItem("Select Exam >>", "0"));
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
}

