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
 public partial class AdminSTD_SubjectStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadSTD_SubjectStudentData();
            StudentIDLoad();
            SubjectIDLoad();
            //RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showSTD_SubjectStudentData();

            }

            loadData();
        }
    }

    private void mangeStudentCode()
    {
        if (Request.QueryString["StudentCode"] != null)
        {
            txtStudentCode.Text = Request.QueryString["StudentCode"];
        }
        if (Request.QueryString["StudentID"] != null)
        {
            txtStudentCode.Text = STD_StudentManager.GetSTD_StudentByStudentID(Request.QueryString["StudentID"]).StudentCode; ;
        }

        txtStudentCode.Text = txtStudentCode.Text == "" ? "84102143" : txtStudentCode.Text;
        txtStudentCode.Enabled = false;

        hfStudentID.Value = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text).StudentID;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (!hfSubjects.Value.Contains("-" + ddlSubjectID.SelectedValue + "-"))
            {
                STD_SubjectStudent sTD_SubjectStudent = new STD_SubjectStudent();
                //	sTD_SubjectStudent.SubjectStudentID=  int.Parse(ddlSubjectStudentID.SelectedValue);
                sTD_SubjectStudent.SubjectStudentName = ddlClassID.SelectedValue;
                sTD_SubjectStudent.StudentID = hfStudentID.Value;
                sTD_SubjectStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                sTD_SubjectStudent.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
                sTD_SubjectStudent.AddedDate = DateTime.Now;
                sTD_SubjectStudent.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
                sTD_SubjectStudent.UpdateDate = DateTime.Now;
                sTD_SubjectStudent.RowStatusID = 1;
                int resutl = STD_SubjectStudentManager.InsertSTD_SubjectStudent(sTD_SubjectStudent);
                loadData();
            }
            else
            {
                lblMessage.Text = "Already this subject has chosen..";
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_SubjectStudent sTD_SubjectStudent = new STD_SubjectStudent();
            sTD_SubjectStudent.SubjectStudentID = int.Parse(Request.QueryString["ID"].ToString());
            sTD_SubjectStudent.SubjectStudentName = ddlClassID.SelectedValue;
            sTD_SubjectStudent.StudentID = hfStudentID.Value;
            sTD_SubjectStudent.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
            sTD_SubjectStudent.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_SubjectStudent.AddedDate = DateTime.Now;
            sTD_SubjectStudent.UpdatedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
            sTD_SubjectStudent.UpdateDate = DateTime.Now;
            sTD_SubjectStudent.RowStatusID = 1;
            bool resutl = STD_SubjectStudentManager.UpdateSTD_SubjectStudent(sTD_SubjectStudent);
            loadData();
        }

        catch (Exception ex)
        {
        }
    }
	private void showSTD_SubjectStudentData()
	{
        try
        {
            STD_SubjectStudent sTD_SubjectStudent = new STD_SubjectStudent();
            sTD_SubjectStudent = STD_SubjectStudentManager.GetSTD_SubjectStudentBySubjectStudentID(Int32.Parse(Request.QueryString["ID"]));
            hfStudentID.Value = sTD_SubjectStudent.StudentID.ToString();
            txtStudentCode.Text = STD_StudentManager.GetSTD_StudentByStudentID(hfStudentID.Value).StudentCode;
            ddlSubjectID.SelectedValue = sTD_SubjectStudent.SubjectID.ToString();
            chkLoadAvailableClass_CheckedChanged(this, new EventArgs());
            ddlClassID.SelectedValue = sTD_SubjectStudent.ToString();
            ddlRowStatusID.SelectedValue = sTD_SubjectStudent.RowStatusID.ToString();
        }

        catch (Exception ex)
        {
        }
	}
	
	private void StudentIDLoad()
	{
		try {
            if (Request.QueryString["StudentCode"] != null)
            {
                txtStudentCode.Text = Request.QueryString["StudentCode"];
            }
            if (Request.QueryString["StudentID"] != null)
            {
                txtStudentCode.Text = STD_StudentManager.GetSTD_StudentByStudentID(Request.QueryString["StudentID"]).StudentCode; ;
            }

            txtStudentCode.Text = txtStudentCode.Text == "" ? "84102143" : txtStudentCode.Text;
            txtStudentCode.Enabled = false;

            hfStudentID.Value = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text).StudentID;
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void SubjectIDLoad()
	{
		try {
            DataSet ds = STD_SubjectManager.GetAllSTD_Subjects();
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "CourseSubject";
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
    private void loadData()
    {
        //STD_SubjectStudentManager.LoadSTD_SubjectStudentPage(gvSTD_SubjectStudent, rptPager, 1, ddlPageSize);
        DataSet ds = new DataSet();
        ds = STD_SubjectStudentManager.GetSTD_StudentByStudentID(hfStudentID.Value, true);

        hfSubjects.Value = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            hfSubjects.Value += "-"+dr["SubjectID"].ToString()+"-"; 
        }
        

        gvSTD_SubjectStudent.DataSource = ds;
        gvSTD_SubjectStudent.DataBind();
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminSTD_SubjectStudent.aspx?ID=" + id);
        loadData();
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        STD_SubjectStudent subjectStudent = STD_SubjectStudentManager.GetSTD_SubjectStudentBySubjectStudentID(Convert.ToInt32(linkButton.CommandArgument));
        subjectStudent.RowStatusID = 3;

        bool result = STD_SubjectStudentManager.UpdateSTD_SubjectStudent(subjectStudent);
        //STD_SubjectStudentManager.LoadSTD_SubjectStudentPage(gvSTD_SubjectStudent, rptPager, 1, ddlPageSize);
        loadData();
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_SubjectStudentManager.LoadSTD_SubjectStudentPage(gvSTD_SubjectStudent, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_SubjectStudentManager.LoadSTD_SubjectStudentPage(gvSTD_SubjectStudent, rptPager, pageIndex, ddlPageSize);
    }
    protected void chkLoadAvailableClass_CheckedChanged(object sender, EventArgs e)
    {
        if (chkLoadAvailableClass.Checked)
        {
            loadClassSubject();
        }
        else
        {
            loadClass();
        }
    }

    private void loadClass()
    {
        try
        {

            ddlClassID.Items.Clear();
            DataSet ds = STD_ClassManager.GetDropDownListAllSTD_Class();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["ClassName"].ToString(), dr["ClassID"].ToString());
                ddlClassID.Items.Add(item);

            }
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0"));


        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void loadClassSubject()
    {
        try
        {

            ddlClassID.Items.Clear();
            DataSet ds = STD_ClassSubjectManager.GetSTD_ClassSubjectBySubjectID(int.Parse(ddlSubjectID.SelectedValue));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(dr["ClassName"].ToString(), dr["ClassID"].ToString());
                ddlClassID.Items.Add(item);

            }
            ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0"));


        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void ddlSubjectID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ddlClassID.Items.Clear();
        DataSet ds = STD_ClassSubjectManager.GetSTD_ClassSubjectBySubjectID(int.Parse(ddlSubjectID.SelectedValue));
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ListItem item = new ListItem(dr["ClassName"].ToString(), dr["ClassID"].ToString());
            ddlClassID.Items.Add(item);

        }
        ddlClassID.Items.Insert(0, new ListItem("Select Class >>", "0"));
    }
}

