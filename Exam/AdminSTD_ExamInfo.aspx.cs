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
 public partial class AdminSTD_ExamInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ExamInfoData();
         		CampusIDLoad();
		BatchIDLoad();
		SemesterIDLoad();
		SubjectTeacherIDLoad();
		ExamTypeIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ExamInfoData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo ();
//	sTD_ExamInfo.ExamInfoID=  int.Parse(ddlExamInfoID.SelectedValue);
	sTD_ExamInfo.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	sTD_ExamInfo.BatchID=  int.Parse(ddlBatchID.SelectedValue);
	sTD_ExamInfo.SemesterID=  int.Parse(ddlSemesterID.SelectedValue);
	sTD_ExamInfo.SubjectTeacherID=  ddlSubjectTeacherID.SelectedValue;
	sTD_ExamInfo.ExamTypeID=  int.Parse(ddlExamTypeID.SelectedValue);
	sTD_ExamInfo.ExamInfoName=  txtExamInfoName.Text;
	sTD_ExamInfo.ExtraField1=  txtExtraField1.Text;
	sTD_ExamInfo.ExtraField2=  txtExtraField2.Text;
	sTD_ExamInfo.ExtraField3=  txtExtraField3.Text;
	sTD_ExamInfo.ExtraField4=  txtExtraField4.Text;
	sTD_ExamInfo.ExtraField5=  txtExtraField5.Text;
	sTD_ExamInfo.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamInfo.AddedDate=  DateTime.Now;
	sTD_ExamInfo.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamInfo.UpdatedDate=  DateTime.Now;
	sTD_ExamInfo.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =STD_ExamInfoManager.InsertSTD_ExamInfo(sTD_ExamInfo);
	Response.Redirect("AdminDisplaySTD_ExamInfo.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_ExamInfo sTD_ExamInfo = new STD_ExamInfo ();
	sTD_ExamInfo.ExamInfoID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ExamInfo.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	sTD_ExamInfo.BatchID=  int.Parse(ddlBatchID.SelectedValue);
	sTD_ExamInfo.SemesterID=  int.Parse(ddlSemesterID.SelectedValue);
	sTD_ExamInfo.SubjectTeacherID=  ddlSubjectTeacherID.SelectedValue;
	sTD_ExamInfo.ExamTypeID=  int.Parse(ddlExamTypeID.SelectedValue);
	sTD_ExamInfo.ExamInfoName=  txtExamInfoName.Text;
	sTD_ExamInfo.ExtraField1=  txtExtraField1.Text;
	sTD_ExamInfo.ExtraField2=  txtExtraField2.Text;
	sTD_ExamInfo.ExtraField3=  txtExtraField3.Text;
	sTD_ExamInfo.ExtraField4=  txtExtraField4.Text;
	sTD_ExamInfo.ExtraField5=  txtExtraField5.Text;
	sTD_ExamInfo.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamInfo.AddedDate=  DateTime.Now;
	sTD_ExamInfo.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ExamInfo.UpdatedDate=  DateTime.Now;
	sTD_ExamInfo.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =STD_ExamInfoManager.UpdateSTD_ExamInfo(sTD_ExamInfo);
	Response.Redirect("AdminDisplaySTD_ExamInfo.aspx");
	}
	private void showSTD_ExamInfoData()
	{
	 	STD_ExamInfo sTD_ExamInfo  = new STD_ExamInfo ();
	 	sTD_ExamInfo = STD_ExamInfoManager.GetSTD_ExamInfoByExamInfoID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlCampusID.SelectedValue  =sTD_ExamInfo.CampusID.ToString();
	 	ddlBatchID.SelectedValue  =sTD_ExamInfo.BatchID.ToString();
	 	ddlSemesterID.SelectedValue  =sTD_ExamInfo.SemesterID.ToString();
	 	ddlSubjectTeacherID.SelectedValue  =sTD_ExamInfo.SubjectTeacherID.ToString();
	 	ddlExamTypeID.SelectedValue  =sTD_ExamInfo.ExamTypeID.ToString();
	 	txtExamInfoName.Text =sTD_ExamInfo.ExamInfoName.ToString();
	 	txtExtraField1.Text =sTD_ExamInfo.ExtraField1.ToString();
	 	txtExtraField2.Text =sTD_ExamInfo.ExtraField2.ToString();
	 	txtExtraField3.Text =sTD_ExamInfo.ExtraField3.ToString();
	 	txtExtraField4.Text =sTD_ExamInfo.ExtraField4.ToString();
	 	txtExtraField5.Text =sTD_ExamInfo.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =sTD_ExamInfo.RowStatusID.ToString();
	}
	
	private void CampusIDLoad()
	{
		try {
		DataSet ds = STD_CampusManager.GetDropDownListAllSTD_Campus();
		ddlCampusID.DataValueField = "CampusID";
		ddlCampusID.DataTextField = "CampusName";
		ddlCampusID.DataSource = ds.Tables[0];
		ddlCampusID.DataBind();
		ddlCampusID.Items.Insert(0, new ListItem("Select Campus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void BatchIDLoad()
	{
		try {
		DataSet ds = STD_BatchManager.GetDropDownListAllSTD_Batch();
		ddlBatchID.DataValueField = "BatchID";
		ddlBatchID.DataTextField = "BatchName";
		ddlBatchID.DataSource = ds.Tables[0];
		ddlBatchID.DataBind();
		ddlBatchID.Items.Insert(0, new ListItem("Select Batch >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void SemesterIDLoad()
	{
		try {
		DataSet ds = STD_SemesterManager.GetDropDownListAllSTD_Semester();
		ddlSemesterID.DataValueField = "SemesterID";
		ddlSemesterID.DataTextField = "SemesterName";
		ddlSemesterID.DataSource = ds.Tables[0];
		ddlSemesterID.DataBind();
		ddlSemesterID.Items.Insert(0, new ListItem("Select Semester >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void SubjectTeacherIDLoad()
	{
		try {
		DataSet ds = STD_SubjectTeacherManager.GetDropDownListAllSTD_SubjectTeacher();
		ddlSubjectTeacherID.DataValueField = "SubjectTeacherID";
		ddlSubjectTeacherID.DataTextField = "SubjectTeacherName";
		ddlSubjectTeacherID.DataSource = ds.Tables[0];
		ddlSubjectTeacherID.DataBind();
		ddlSubjectTeacherID.Items.Insert(0, new ListItem("Select SubjectTeacher >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void ExamTypeIDLoad()
	{
		try {
		DataSet ds = STD_ExamTypeManager.GetDropDownListAllSTD_ExamType();
		ddlExamTypeID.DataValueField = "ExamTypeID";
		ddlExamTypeID.DataTextField = "ExamTypeName";
		ddlExamTypeID.DataSource = ds.Tables[0];
		ddlExamTypeID.DataBind();
		ddlExamTypeID.Items.Insert(0, new ListItem("Select ExamType >>", "0"));
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

