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
 public partial class AdminSTD_ExamDetailsStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_ExamDetailsStudentData();
            _loadExam();
            ExamDetailsIDLoad();
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                gvSTD_UpdateExam.Visible = true;
                gvSTD_Exam.Visible = false;
                showSTD_ExamDetailsStudentData();
            }

            else
            {
                gvSTD_Exam.Visible = true;
                gvSTD_UpdateExam.Visible = false;
            }
        }
    }

    private void _loadExam()
    {
        DataSet ds = STD_ExamManager.GetDropDownListAllSTD_Exam();
        ddlExamID.DataTextField = "ExamName";
        ddlExamID.DataValueField = "ExamID";
        ddlExamID.DataSource = ds.Tables[0];
        ddlExamID.DataBind();
        ddlExamID.Items.Insert(0,new ListItem("Select Exam Name >>>>", "0"));
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        STD_ExamDetailsStudent sTD_ExamDetailsStudent = new STD_ExamDetailsStudent();
        //	sTD_ExamDetailsStudent.ExamDetailsStudentID=  int.Parse(ddlExamDetailsStudentID.SelectedValue);

        DataSet ds = STD_StudentManager.GetSTD_ExamStudentsByExamDetailsID(Convert.ToInt32(ddlExamDetailsID.SelectedValue));

        int i = 0;
        foreach (GridViewRow row in gvSTD_Exam.Rows)
        {
            Label lblSID = (Label)row.FindControl("lblSID");
            TextBox txtObtainMark = (TextBox)row.FindControl("txtObtainMark");

            string mark = ds.Tables[0].Rows[i]["ObtainedMark"].ToString();

            if (mark == "")
            {
                if (txtObtainMark.Text != "")
                {
                    sTD_ExamDetailsStudent.ExamDetailsStudentName = "Exam Student";
                    sTD_ExamDetailsStudent.ExamDetailsID = int.Parse(ddlExamDetailsID.SelectedValue);
                    sTD_ExamDetailsStudent.StudentID = lblSID.Text;
                    sTD_ExamDetailsStudent.ObtainedMark = txtObtainMark.Text != "" ? decimal.Parse(txtObtainMark.Text) : 0;

                    sTD_ExamDetailsStudent.ExtraField1 = "";
                    sTD_ExamDetailsStudent.ExtraField2 = "";
                    sTD_ExamDetailsStudent.ExtraField3 = "";
                    sTD_ExamDetailsStudent.ExtraField4 = "";
                    sTD_ExamDetailsStudent.ExtraField5 = "";
                    sTD_ExamDetailsStudent.AddedBy = Profile.card_id;
                    sTD_ExamDetailsStudent.AddedDate = DateTime.Now;
                    sTD_ExamDetailsStudent.UpdatedBy = Profile.card_id;
                    sTD_ExamDetailsStudent.UpdatedDate = DateTime.Now;
                    sTD_ExamDetailsStudent.RowStatusID = 1;
                    int resutl = STD_ExamDetailsStudentManager.InsertSTD_ExamDetailsStudent(sTD_ExamDetailsStudent);
                }
                i++;
                
            }
            else
            {
                string id = ds.Tables[0].Rows[i]["ExamDetailsStudentID"].ToString();

                STD_ExamDetailsStudent sTDUpdate_ExamDetailsStudent = STD_ExamDetailsStudentManager.GetSTD_ExamDetailsStudentByExamDetailsStudentID(int.Parse(id));

              
                sTDUpdate_ExamDetailsStudent.ExamDetailsStudentName = "Exam Student";
                sTDUpdate_ExamDetailsStudent.ExamDetailsID = int.Parse(ddlExamDetailsID.SelectedValue);
                sTDUpdate_ExamDetailsStudent.StudentID = lblSID.Text;
                sTDUpdate_ExamDetailsStudent.ObtainedMark = txtObtainMark.Text != "" ? decimal.Parse(txtObtainMark.Text) : 0;

                bool resutl = STD_ExamDetailsStudentManager.UpdateSTD_ExamDetailsStudent(sTDUpdate_ExamDetailsStudent);
                i++;
            }
        }

        
        
       
        Response.Redirect("AdminDisplaySTD_ExamDetailsStudent.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ID"] != null)
        {
            STD_ExamDetailsStudent sTD_ExamDetailsStudent = STD_ExamDetailsStudentManager.GetSTD_ExamDetailsStudentByExamDetailsStudentID(int.Parse(Request.QueryString["ID"].ToString()));

            foreach (GridViewRow row in gvSTD_UpdateExam.Rows)
            {
                Label lblSID = (Label)row.FindControl("lblSID");
                TextBox txtObtainMark = (TextBox)row.FindControl("txtObtainMark");

                sTD_ExamDetailsStudent.ExamDetailsStudentName = "Exam Student";
                sTD_ExamDetailsStudent.ExamDetailsID = int.Parse(ddlExamDetailsID.SelectedValue);
                sTD_ExamDetailsStudent.StudentID = lblSID.Text;
                sTD_ExamDetailsStudent.ObtainedMark = decimal.Parse(txtObtainMark.Text);

                bool resutl = STD_ExamDetailsStudentManager.UpdateSTD_ExamDetailsStudent(sTD_ExamDetailsStudent);

            }
        }
        
        Response.Redirect("AdminDisplaySTD_ExamDetailsStudent.aspx");
    }
	private void showSTD_ExamDetailsStudentData()
	{
        STD_ExamDetailsStudent examDetailsStudent = STD_ExamDetailsStudentManager.GetSTD_ExamDetailsStudentByExamDetailsStudentID(Int32.Parse(Request.QueryString["ID"]));

        ddlExamID.SelectedValue = STD_ExamDetailsManager.GetSTD_ExamDetailsByExamDetailsID(examDetailsStudent.ExamDetailsID).ExamID.ToString();
        ddlExamDetailsID.SelectedValue = examDetailsStudent.ExamDetailsID.ToString();
	 	
        DataSet st = STD_StudentManager.GetSTD_ExamDetailsStudentsByExamDetailsStudentID(Int32.Parse(Request.QueryString["ID"]));
        gvSTD_UpdateExam.DataSource = st;
        gvSTD_UpdateExam.DataBind();
	}
	
	private void ExamDetailsIDLoad()
	{
        try
        {
            DataSet ds = STD_ExamDetailsManager.GetDropDownListAllSTD_ExamDetails();
            ddlExamDetailsID.DataValueField = "ExamDetailsID";
            ddlExamDetailsID.DataTextField = "ExamDetailsName";
            ddlExamDetailsID.DataSource = ds.Tables[0];
            ddlExamDetailsID.DataBind();
            ddlExamDetailsID.Items.Insert(0, new ListItem("Select ExamDetails >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
	 }

    protected void ddlExamDetailsID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet students = STD_StudentManager.GetSTD_ExamStudentsByExamDetailsID(Convert.ToInt32(ddlExamDetailsID.SelectedValue));
        gvSTD_Exam.DataSource = students;
        gvSTD_Exam.DataBind();
    }
    protected void ddlExamID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ddlExamDetailsID.Items.Clear();
        DataSet ds = STD_ExamDetailsManager.GetSTD_ExamDetailByExamID(int.Parse(ddlExamID.SelectedValue));
        ddlExamDetailsID.DataValueField = "ExamDetailsID";
        ddlExamDetailsID.DataTextField = "ExamDetailsName";
        ddlExamDetailsID.DataSource = ds.Tables[0];
        ddlExamDetailsID.DataBind();
        ddlExamDetailsID.Items.Insert(0, new ListItem("Select ExamDetails >>", "0"));
    }
}

