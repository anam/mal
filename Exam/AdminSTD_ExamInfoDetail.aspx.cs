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
 public partial class AdminSTD_ExamInfoDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ExamInfoDetailData();
         		ExamInfoIDLoad();
		StudentIDLoad();
		SubjectIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ExamInfoDetailData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_ExamInfoDetail sTD_ExamInfoDetail = new STD_ExamInfoDetail ();
//	sTD_ExamInfoDetail.ExamInfoDetailID=  int.Parse(ddlExamInfoDetailID.SelectedValue);
	sTD_ExamInfoDetail.ExamInfoID=  int.Parse(ddlExamInfoID.SelectedValue);
	sTD_ExamInfoDetail.StudentID=  ddlStudentID.SelectedValue;
	sTD_ExamInfoDetail.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	sTD_ExamInfoDetail.ExamStartTime=  txtExamStartTime.Text;
	sTD_ExamInfoDetail.ExamDuration=  int.Parse(txtExamDuration.Text);
	sTD_ExamInfoDetail.ExamDate=   DateTime.Parse(txtExamDate.Text);
	sTD_ExamInfoDetail.ExamMarks=  int.Parse(txtExamMarks.Text);
	sTD_ExamInfoDetail.ObtainMarks=  decimal.Parse(txtObtainMarks.Text);
	sTD_ExamInfoDetail.ExtraField1=  txtExtraField1.Text;
	sTD_ExamInfoDetail.ExtraField2=  txtExtraField2.Text;
	sTD_ExamInfoDetail.ExtraField3=  txtExtraField3.Text;
	sTD_ExamInfoDetail.ExtraField4=  txtExtraField4.Text;
	sTD_ExamInfoDetail.ExtraField5=  txtExtraField5.Text;
	sTD_ExamInfoDetail.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamInfoDetail.AddedDate=  DateTime.Now;
	sTD_ExamInfoDetail.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamInfoDetail.UpdatedDate=  DateTime.Now;
	sTD_ExamInfoDetail.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =STD_ExamInfoDetailManager.InsertSTD_ExamInfoDetail(sTD_ExamInfoDetail);
	Response.Redirect("AdminDisplaySTD_ExamInfoDetail.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_ExamInfoDetail sTD_ExamInfoDetail = new STD_ExamInfoDetail ();
	sTD_ExamInfoDetail.ExamInfoDetailID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ExamInfoDetail.ExamInfoID=  int.Parse(ddlExamInfoID.SelectedValue);
	sTD_ExamInfoDetail.StudentID=  ddlStudentID.SelectedValue;
	sTD_ExamInfoDetail.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	sTD_ExamInfoDetail.ExamStartTime=  txtExamStartTime.Text;
	sTD_ExamInfoDetail.ExamDuration=  int.Parse(txtExamDuration.Text);
	sTD_ExamInfoDetail.ExamDate=   DateTime.Parse(txtExamDate.Text);
	sTD_ExamInfoDetail.ExamMarks=  int.Parse(txtExamMarks.Text);
	sTD_ExamInfoDetail.ObtainMarks=  decimal.Parse(txtObtainMarks.Text);
	sTD_ExamInfoDetail.ExtraField1=  txtExtraField1.Text;
	sTD_ExamInfoDetail.ExtraField2=  txtExtraField2.Text;
	sTD_ExamInfoDetail.ExtraField3=  txtExtraField3.Text;
	sTD_ExamInfoDetail.ExtraField4=  txtExtraField4.Text;
	sTD_ExamInfoDetail.ExtraField5=  txtExtraField5.Text;
	sTD_ExamInfoDetail.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamInfoDetail.AddedDate=  DateTime.Now;
	sTD_ExamInfoDetail.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamInfoDetail.UpdatedDate=  DateTime.Now;
	sTD_ExamInfoDetail.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =STD_ExamInfoDetailManager.UpdateSTD_ExamInfoDetail(sTD_ExamInfoDetail);
	Response.Redirect("AdminDisplaySTD_ExamInfoDetail.aspx");
	}
	private void showSTD_ExamInfoDetailData()
	{
	 	STD_ExamInfoDetail sTD_ExamInfoDetail  = new STD_ExamInfoDetail ();
	 	sTD_ExamInfoDetail = STD_ExamInfoDetailManager.GetSTD_ExamInfoDetailByExamInfoDetailID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlExamInfoID.SelectedValue  =sTD_ExamInfoDetail.ExamInfoID.ToString();
	 	ddlStudentID.SelectedValue  =sTD_ExamInfoDetail.StudentID.ToString();
	 	ddlSubjectID.SelectedValue  =sTD_ExamInfoDetail.SubjectID.ToString();
	 	txtExamStartTime.Text =sTD_ExamInfoDetail.ExamStartTime.ToString();
	 	txtExamDuration.Text =sTD_ExamInfoDetail.ExamDuration.ToString();
	 	txtExamDate.Text =sTD_ExamInfoDetail.ExamDate.ToString();
	 	txtExamMarks.Text =sTD_ExamInfoDetail.ExamMarks.ToString();
	 	txtObtainMarks.Text =sTD_ExamInfoDetail.ObtainMarks.ToString();
	 	txtExtraField1.Text =sTD_ExamInfoDetail.ExtraField1.ToString();
	 	txtExtraField2.Text =sTD_ExamInfoDetail.ExtraField2.ToString();
	 	txtExtraField3.Text =sTD_ExamInfoDetail.ExtraField3.ToString();
	 	txtExtraField4.Text =sTD_ExamInfoDetail.ExtraField4.ToString();
	 	txtExtraField5.Text =sTD_ExamInfoDetail.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =sTD_ExamInfoDetail.RowStatusID.ToString();
	}
	
	private void ExamInfoIDLoad()
	{
		try {
		DataSet ds = STD_ExamInfoManager.GetDropDownListAllSTD_ExamInfo();
		ddlExamInfoID.DataValueField = "ExamInfoID";
		ddlExamInfoID.DataTextField = "ExamInfoName";
		ddlExamInfoID.DataSource = ds.Tables[0];
		ddlExamInfoID.DataBind();
		ddlExamInfoID.Items.Insert(0, new ListItem("Select ExamInfo >>", "0"));
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
	private void SubjectIDLoad()
	{
		try {
		DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_Subject();
		ddlSubjectID.DataValueField = "SubjectID";
		ddlSubjectID.DataTextField = "SubjectName";
		ddlSubjectID.DataSource = ds.Tables[0];
		ddlSubjectID.DataBind();
		ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
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

