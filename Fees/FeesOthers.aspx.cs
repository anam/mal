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
 public partial class AdminSTD_Fees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //         loadSTD_FeesData();
         	FeesTypeIDLoad();
		    StudentIDLoad();
		    CourseIDLoad();
		    RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_FeesData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_Fees sTD_Fees = new STD_Fees ();
//	sTD_Fees.FeesID=  int.Parse(ddlFeesID.SelectedValue);
    sTD_Fees.FeesName = "";//txtFeesName.Text;
	sTD_Fees.Amount=  decimal.Parse(txtAmount.Text);
    sTD_Fees.FeesTypeID = int.Parse(Request.QueryString["FeesTypeID"]);
	sTD_Fees.SubmissionDate=   DateTime.Now;
    sTD_Fees.SubmitedDate = DateTime.Now.ToString();
	sTD_Fees.StudentID=  ddlStudentID.SelectedValue;
	sTD_Fees.CourseID=  int.Parse(ddlCourseID.SelectedValue);
	sTD_Fees.AddedBy=  Profile.card_id;
	sTD_Fees.AddedDate=  DateTime.Now;
	sTD_Fees.UpdatedBy=  Profile.card_id;
	sTD_Fees.UpdateDate=  DateTime.Now;
	sTD_Fees.RowStatusID=  1;
	sTD_Fees.Remarks=  txtRemarks.Text;
	sTD_Fees.IsPaid=  true;
	int resutl =STD_FeesManager.InsertSTD_Fees(sTD_Fees);

    if (chkNextSubmission.Checked)
    {
        sTD_Fees.SubmissionDate = DateTime.Parse(txtNextSubmissionDate.Text);
        sTD_Fees.SubmitedDate = "";
        sTD_Fees.IsPaid = false;
        resutl = STD_FeesManager.InsertSTD_Fees(sTD_Fees);
    }

	//Response.Redirect("AdminDisplaySTD_Fees.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_Fees sTD_Fees = new STD_Fees ();
	sTD_Fees.FeesID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Fees.FeesName=  "";//txtFeesName.Text;
	sTD_Fees.Amount=  decimal.Parse(txtAmount.Text);
	sTD_Fees.FeesTypeID=  int.Parse(Request.QueryString["FeesTypeID"]);
	sTD_Fees.SubmissionDate=   DateTime.Now;
	sTD_Fees.SubmitedDate=  "";
	sTD_Fees.StudentID=  ddlStudentID.SelectedValue;
	sTD_Fees.CourseID=  int.Parse(ddlCourseID.SelectedValue);
	sTD_Fees.AddedBy=  Profile.card_id;
	sTD_Fees.AddedDate=  DateTime.Now;
	sTD_Fees.UpdatedBy=  Profile.card_id;
	sTD_Fees.UpdateDate=  DateTime.Now;
	sTD_Fees.RowStatusID=  1;
	sTD_Fees.Remarks=  txtRemarks.Text;
	sTD_Fees.IsPaid=  false;
	bool  resutl =STD_FeesManager.UpdateSTD_Fees(sTD_Fees);
	//Response.Redirect("AdminDisplaySTD_Fees.aspx");
	}
	private void showSTD_FeesData()
	{
	 	STD_Fees sTD_Fees  = new STD_Fees ();
	 	sTD_Fees = STD_FeesManager.GetSTD_FeesByFeesID(Int32.Parse(Request.QueryString["ID"]));
	 	//txtFeesName.Text =sTD_Fees.FeesName.ToString();
	 	txtAmount.Text =sTD_Fees.Amount.ToString();
	 	//ddlFeesTypeID.SelectedValue  =sTD_Fees.FeesTypeID.ToString();
        //txtSubmissionDate.Text =sTD_Fees.SubmissionDate.ToString();
        //txtSubmitedDate.Text =sTD_Fees.SubmitedDate.ToString();
	 	ddlStudentID.SelectedValue  =sTD_Fees.StudentID.ToString();
	 	ddlCourseID.SelectedValue  =sTD_Fees.CourseID.ToString();
	 	//ddlRowStatusID.SelectedValue  =sTD_Fees.RowStatusID.ToString();
	 	txtRemarks.Text =sTD_Fees.Remarks.ToString();
        //radIsPaid.SelectedValue  =sTD_Fees.IsPaid.ToString();
	}
	
	private void FeesTypeIDLoad()
	{
		try {
        //DataSet ds = STD_FeesTypeManager.GetDropDownListAllSTD_FeesType();
        //ddlFeesTypeID.DataValueField = "FeesTypeID";
        //ddlFeesTypeID.DataTextField = "FeesTypeName";
        //ddlFeesTypeID.DataSource = ds.Tables[0];
        //ddlFeesTypeID.DataBind();
        //ddlFeesTypeID.Items.Insert(0, new ListItem("Select FeesType >>", "0"));
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
	private void CourseIDLoad()
	{
		try {
		DataSet ds = STD_CourseManager.GetDropDownListAllSTD_Course();
		ddlCourseID.DataValueField = "CourseID";
		ddlCourseID.DataTextField = "CourseName";
		ddlCourseID.DataSource = ds.Tables[0];
		ddlCourseID.DataBind();
		ddlCourseID.Items.Insert(0, new ListItem("Select Course >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
        //DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
        //ddlRowStatusID.DataValueField = "RowStatusID";
        //ddlRowStatusID.DataTextField = "RowStatusName";
        //ddlRowStatusID.DataSource = ds.Tables[0];
        //ddlRowStatusID.DataBind();
        //ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

