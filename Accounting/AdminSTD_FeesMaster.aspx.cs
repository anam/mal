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
 public partial class AdminSTD_FeesMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_FeesMasterData();
         		FeesTypeIDLoad();
		StudentIDLoad();
		CourseIDLoad();
		PaymentStatusIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_FeesMasterData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster ();
//	sTD_FeesMaster.FeesMasterID=  int.Parse(ddlFeesMasterID.SelectedValue);
	sTD_FeesMaster.FeesMasterName=  txtFeesMasterName.Text;
	sTD_FeesMaster.TotalPayment=  decimal.Parse(txtTotalPayment.Text);
	sTD_FeesMaster.Discount=  decimal.Parse(txtDiscount.Text);
	sTD_FeesMaster.TotalPaymentNeedtoPay=  decimal.Parse(txtTotalPaymentNeedtoPay.Text);
	sTD_FeesMaster.FeesTypeID=  int.Parse(ddlFeesTypeID.SelectedValue);
	sTD_FeesMaster.SubmissionDate=   DateTime.Parse(txtSubmissionDate.Text);
	sTD_FeesMaster.SubmitedDate=  txtSubmitedDate.Text;
	sTD_FeesMaster.StudentID=  ddlStudentID.SelectedValue;
	sTD_FeesMaster.CourseID=  int.Parse(ddlCourseID.SelectedValue);
	sTD_FeesMaster.Remarks=  txtRemarks.Text;
	sTD_FeesMaster.IsPaid=  bool.Parse( radIsPaid.SelectedValue);
	sTD_FeesMaster.PaymentStatusID=  int.Parse(ddlPaymentStatusID.SelectedValue);
	sTD_FeesMaster.ExtraField1=  txtExtraField1.Text;
	sTD_FeesMaster.ExtraField2=  txtExtraField2.Text;
	sTD_FeesMaster.ExtraField3=  txtExtraField3.Text;
	sTD_FeesMaster.ExtraField4=  txtExtraField4.Text;
	sTD_FeesMaster.ExtraField5=  txtExtraField5.Text;
	sTD_FeesMaster.AddedBy=  Profile.card_id;
	sTD_FeesMaster.AddedDate=  DateTime.Now;
	sTD_FeesMaster.UpdatedBy=  Profile.card_id;
	sTD_FeesMaster.UpdateDate=  DateTime.Now;
	sTD_FeesMaster.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =STD_FeesMasterManager.InsertSTD_FeesMaster(sTD_FeesMaster);
	Response.Redirect("AdminDisplaySTD_FeesMaster.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_FeesMaster sTD_FeesMaster = new STD_FeesMaster ();
	sTD_FeesMaster.FeesMasterID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_FeesMaster.FeesMasterName=  txtFeesMasterName.Text;
	sTD_FeesMaster.TotalPayment=  decimal.Parse(txtTotalPayment.Text);
	sTD_FeesMaster.Discount=  decimal.Parse(txtDiscount.Text);
	sTD_FeesMaster.TotalPaymentNeedtoPay=  decimal.Parse(txtTotalPaymentNeedtoPay.Text);
	sTD_FeesMaster.FeesTypeID=  int.Parse(ddlFeesTypeID.SelectedValue);
	sTD_FeesMaster.SubmissionDate=   DateTime.Parse(txtSubmissionDate.Text);
	sTD_FeesMaster.SubmitedDate=  txtSubmitedDate.Text;
	sTD_FeesMaster.StudentID=  ddlStudentID.SelectedValue;
	sTD_FeesMaster.CourseID=  int.Parse(ddlCourseID.SelectedValue);
	sTD_FeesMaster.Remarks=  txtRemarks.Text;
	sTD_FeesMaster.IsPaid=  bool.Parse( radIsPaid.SelectedValue);
	sTD_FeesMaster.PaymentStatusID=  int.Parse(ddlPaymentStatusID.SelectedValue);
	sTD_FeesMaster.ExtraField1=  txtExtraField1.Text;
	sTD_FeesMaster.ExtraField2=  txtExtraField2.Text;
	sTD_FeesMaster.ExtraField3=  txtExtraField3.Text;
	sTD_FeesMaster.ExtraField4=  txtExtraField4.Text;
	sTD_FeesMaster.ExtraField5=  txtExtraField5.Text;
	sTD_FeesMaster.AddedBy=  Profile.card_id;
	sTD_FeesMaster.AddedDate=  DateTime.Now;
	sTD_FeesMaster.UpdatedBy=  Profile.card_id;
	sTD_FeesMaster.UpdateDate=  DateTime.Now;
	sTD_FeesMaster.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =STD_FeesMasterManager.UpdateSTD_FeesMaster(sTD_FeesMaster);
	Response.Redirect("AdminDisplaySTD_FeesMaster.aspx");
	}
	private void showSTD_FeesMasterData()
	{
	 	STD_FeesMaster sTD_FeesMaster  = new STD_FeesMaster ();
	 	sTD_FeesMaster = STD_FeesMasterManager.GetSTD_FeesMasterByFeesMasterID(Int32.Parse(Request.QueryString["ID"]));
	 	txtFeesMasterName.Text =sTD_FeesMaster.FeesMasterName.ToString();
	 	txtTotalPayment.Text =sTD_FeesMaster.TotalPayment.ToString();
	 	txtDiscount.Text =sTD_FeesMaster.Discount.ToString();
	 	txtTotalPaymentNeedtoPay.Text =sTD_FeesMaster.TotalPaymentNeedtoPay.ToString();
	 	ddlFeesTypeID.SelectedValue  =sTD_FeesMaster.FeesTypeID.ToString();
	 	txtSubmissionDate.Text =sTD_FeesMaster.SubmissionDate.ToString();
	 	txtSubmitedDate.Text =sTD_FeesMaster.SubmitedDate.ToString();
	 	ddlStudentID.SelectedValue  =sTD_FeesMaster.StudentID.ToString();
	 	ddlCourseID.SelectedValue  =sTD_FeesMaster.CourseID.ToString();
	 	txtRemarks.Text =sTD_FeesMaster.Remarks.ToString();
	 	 radIsPaid.SelectedValue  =sTD_FeesMaster.IsPaid.ToString();
	 	ddlPaymentStatusID.SelectedValue  =sTD_FeesMaster.PaymentStatusID.ToString();
	 	txtExtraField1.Text =sTD_FeesMaster.ExtraField1.ToString();
	 	txtExtraField2.Text =sTD_FeesMaster.ExtraField2.ToString();
	 	txtExtraField3.Text =sTD_FeesMaster.ExtraField3.ToString();
	 	txtExtraField4.Text =sTD_FeesMaster.ExtraField4.ToString();
	 	txtExtraField5.Text =sTD_FeesMaster.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =sTD_FeesMaster.RowStatusID.ToString();
	}
	
	private void FeesTypeIDLoad()
	{
		try {
		DataSet ds = STD_FeesTypeManager.GetDropDownListAllSTD_FeesType();
		ddlFeesTypeID.DataValueField = "FeesTypeID";
		ddlFeesTypeID.DataTextField = "FeesTypeName";
		ddlFeesTypeID.DataSource = ds.Tables[0];
		ddlFeesTypeID.DataBind();
		ddlFeesTypeID.Items.Insert(0, new ListItem("Select FeesType >>", "0"));
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
	private void PaymentStatusIDLoad()
	{
		try {
		DataSet ds = COMN_PaymentStatusManager.GetDropDownListAllCOMN_PaymentStatus();	ddlPaymentStatusID.DataValueField = "PaymentStatusID";
		ddlPaymentStatusID.DataTextField = "PaymentStatusName";
		ddlPaymentStatusID.DataSource = ds.Tables[0];
		ddlPaymentStatusID.DataBind();
		ddlPaymentStatusID.Items.Insert(0, new ListItem("Select PaymentStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
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

