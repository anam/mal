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
 public partial class AdminSTD_ExamDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_ExamDetailsData();
            ExamIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showSTD_ExamDetailsData();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_ExamDetails sTD_ExamDetails = new STD_ExamDetails();
            //	sTD_ExamDetails.ExamDetailsID=  int.Parse(ddlExamDetailsID.SelectedValue);
            sTD_ExamDetails.ExamID = int.Parse(ddlExamID.SelectedValue);
            sTD_ExamDetails.ExamTypeID = 0;
            sTD_ExamDetails.ExamDetailsName = txtExamDetailsName.Text;
            sTD_ExamDetails.ExtraField1 = "";
            sTD_ExamDetails.ExtraField2 = "";
            sTD_ExamDetails.ExtraField3 = "";
            sTD_ExamDetails.ExtraField4 = "";
            sTD_ExamDetails.ExtraField5 = "";
            sTD_ExamDetails.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_ExamDetails.AddedDate = DateTime.Now;
            sTD_ExamDetails.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_ExamDetails.UpdatedDate = DateTime.Now;
            sTD_ExamDetails.RowStatusID = 1;
            sTD_ExamDetails.TotalMarks = decimal.Parse(txtTotalMark.Text);
            int resutl = STD_ExamDetailsManager.InsertSTD_ExamDetails(sTD_ExamDetails);

            DataSet ds = STD_ExamDetailsManager.GetSTD_ExamDetailsMarksByExamID(int.Parse(ddlExamID.SelectedValue));

            decimal totalMark = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string mark = row["TotalMarks"].ToString();
                totalMark = totalMark + decimal.Parse(mark);
            }

            STD_Exam exam = STD_ExamManager.GetSTD_ExamByExamID(int.Parse(ddlExamID.SelectedValue));
            exam.TotalMarks = totalMark;

            STD_ExamManager.UpdateSTD_Exam(exam);

            Response.Redirect("AdminDisplaySTD_ExamDetails.aspx");
        }

        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_ExamDetails sTD_ExamDetails = new STD_ExamDetails();
            sTD_ExamDetails.ExamDetailsID = int.Parse(Request.QueryString["ID"].ToString());
            sTD_ExamDetails.ExamID = int.Parse(ddlExamID.SelectedValue);
            sTD_ExamDetails.ExamTypeID = 0;
            sTD_ExamDetails.ExamDetailsName = txtExamDetailsName.Text;
            sTD_ExamDetails.ExtraField1 = "";
            sTD_ExamDetails.ExtraField2 = "";
            sTD_ExamDetails.ExtraField3 = "";
            sTD_ExamDetails.ExtraField4 = "";
            sTD_ExamDetails.ExtraField5 = "";
            sTD_ExamDetails.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_ExamDetails.AddedDate = DateTime.Now;
            sTD_ExamDetails.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_ExamDetails.UpdatedDate = DateTime.Now;
            sTD_ExamDetails.RowStatusID = 1;
            sTD_ExamDetails.TotalMarks = decimal.Parse(txtTotalMark.Text);
            bool resutl = STD_ExamDetailsManager.UpdateSTD_ExamDetails(sTD_ExamDetails);

            DataSet ds = STD_ExamDetailsManager.GetSTD_ExamDetailsMarksByExamID(int.Parse(ddlExamID.SelectedValue));

            decimal totalMark = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string mark = row["TotalMarks"].ToString();
                totalMark = totalMark + decimal.Parse(mark);
            }

            STD_Exam exam = STD_ExamManager.GetSTD_ExamByExamID(int.Parse(ddlExamID.SelectedValue));
            exam.TotalMarks = totalMark;

            STD_ExamManager.UpdateSTD_Exam(exam);

                
            Response.Redirect("AdminDisplaySTD_ExamDetails.aspx");
        }

        catch (Exception ex)
        {
        }
    }
	private void showSTD_ExamDetailsData()
	{
        try
        {
            STD_ExamDetails sTD_ExamDetails = new STD_ExamDetails();
            sTD_ExamDetails = STD_ExamDetailsManager.GetSTD_ExamDetailsByExamDetailsID(Int32.Parse(Request.QueryString["ID"]));
            ddlExamID.SelectedValue = sTD_ExamDetails.ExamID.ToString();

            txtExamDetailsName.Text = sTD_ExamDetails.ExamDetailsName.ToString();
            txtTotalMark.Text = sTD_ExamDetails.TotalMarks.ToString();
        }

        catch (Exception ex)
        {
        }
	}
	
	private void ExamIDLoad()
	{
        try
        {
            DataSet ds = STD_ExamManager.GetDropDownListAllSTD_Exam();
            ddlExamID.DataValueField = "ExamID";
            ddlExamID.DataTextField = "ExamName";
            ddlExamID.DataSource = ds.Tables[0];
            ddlExamID.DataBind();
            ddlExamID.Items.Insert(0, new ListItem("Select Exam >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
	 }
}

