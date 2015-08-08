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
 public partial class AdminSTD_Exam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_ExamData();
           
            ExamTypeIDLoad();
           
            ClassIDLoad();
            SubjectIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showSTD_ExamData();
            }
        }
    }

    private void ClassIDLoad()
    {
        try
        {
            DataSet ds = STD_ClassManager.GetDropDownListAllSTD_Class();
            ddlClassID.DataValueField = "ClassID";
            ddlClassID.DataTextField = "ClassName";
            ddlClassID.DataSource = ds.Tables[0];
            ddlClassID.DataBind();
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    protected void ddlClassID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassID.SelectedValue != null)
        {
            int ClassID = int.Parse(ddlClassID.SelectedValue);
            SubjectIDLoad(ClassID);

        }
    }

    private void SubjectIDLoad()
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_Subject();
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void SubjectIDLoad(int ClassID)
    {
        try
        {
            ddlSubjectID.Items.Clear();

            DataSet ds = STD_SubjectManager.GetSTD_ClassSubjectsByClassID(ClassID);

            ListItem li = new ListItem("Select Subject >>", "0");
            ddlSubjectID.Items.Add(li);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["SubjectName"].ToString(), dr["ClassSubjectID"].ToString());
                ddlSubjectID.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_Exam sTD_Exam = new STD_Exam();
            //	sTD_Exam.ExamID=  int.Parse(ddlExamID.SelectedValue);
            sTD_Exam.ExamName = "Exam Of" + " " + ddlSubjectID.SelectedItem.Text + " " + "for" + " " + ddlClassID.SelectedItem.Text;
            sTD_Exam.Description = txtDescription.Text;
            sTD_Exam.ClassSubjectID = int.Parse(ddlSubjectID.SelectedValue);
            sTD_Exam.ExamTypeID = int.Parse(ddlExamTypeID.SelectedValue);
            sTD_Exam.TotalMarks = 0;
            sTD_Exam.ExtraField1 = "";
            sTD_Exam.ExtraField2 = "";
            sTD_Exam.ExtraField3 = "";
            sTD_Exam.ExtraField4 = "";
            sTD_Exam.ExtraField5 = "";
            sTD_Exam.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_Exam.AddedDate = DateTime.Now;
            sTD_Exam.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_Exam.UpdatedDate = DateTime.Now;
            sTD_Exam.RowStatusID = 1;
            int resutl = STD_ExamManager.InsertSTD_Exam(sTD_Exam);
            Response.Redirect("AdminDisplaySTD_Exam.aspx");
        }

        catch(Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_Exam sTD_Exam = STD_ExamManager.GetSTD_ExamByExamID(int.Parse(Request.QueryString["ID"].ToString()));
            sTD_Exam.ExamName = "Exam Of" + " " + ddlSubjectID.SelectedItem.Text + " " + "for" + " " + ddlClassID.SelectedItem.Text;
            sTD_Exam.Description = txtDescription.Text;
            sTD_Exam.ClassSubjectID = int.Parse(ddlSubjectID.SelectedValue);
            sTD_Exam.ExamTypeID = int.Parse(ddlExamTypeID.SelectedValue);          
            sTD_Exam.ExtraField1 = "";
            sTD_Exam.ExtraField2 = "";
            sTD_Exam.ExtraField3 = "";
            sTD_Exam.ExtraField4 = "";
            sTD_Exam.ExtraField5 = "";
            sTD_Exam.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_Exam.AddedDate = DateTime.Now;
            sTD_Exam.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_Exam.UpdatedDate = DateTime.Now;
            sTD_Exam.RowStatusID = 1;
            bool resutl = STD_ExamManager.UpdateSTD_Exam(sTD_Exam);
            Response.Redirect("AdminDisplaySTD_Exam.aspx");
        }

        catch (Exception ex)
        {
        }
    }
	private void showSTD_ExamData()
	{
        try
        {
            STD_Exam sTD_Exam = new STD_Exam();
            sTD_Exam = STD_ExamManager.GetSTD_ExamByExamID(Int32.Parse(Request.QueryString["ID"]));

            STD_ClassSubject classSubject = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassSubjectID(sTD_Exam.ClassSubjectID);

            txtDescription.Text = sTD_Exam.Description.ToString();

            ddlExamTypeID.SelectedValue = sTD_Exam.ExamTypeID.ToString();
           
            ddlClassID.SelectedValue = classSubject.ClassID.ToString();
            ddlSubjectID.SelectedValue = classSubject.ClassSubjectID.ToString();
            ddlSubjectID.SelectedItem.Text = classSubject.SubjectName;
        }
        catch (Exception ex)
        {
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
	
}

