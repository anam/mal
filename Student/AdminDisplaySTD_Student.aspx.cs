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


public partial class AdminDisplaySTD_Student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BatchIDLoad();
            STD_StudentManager.LoadSTD_StudentPage(gvSTD_Student, rptPager, 1, ddlPageSize);
            pageID.Visible = true;
        }
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_StudentManager.LoadSTD_StudentPage(gvSTD_Student, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_StudentManager.LoadSTD_StudentPage(gvSTD_Student, rptPager, pageIndex, ddlPageSize);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminSTD_Student.aspx?ID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        String id="";
        id = linkButton.CommandArgument;       
        Response.Redirect("StudentRegistration.aspx?studentID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;

            //STD_Student student = STD_StudentManager.GetSTD_StudentByStudentID(linkButton.CommandArgument);
            //student.RowStatusID = 3;
            bool resutl = STD_StudentManager.DeleteSTD_StudentAccordingToRowStatusID(linkButton.CommandArgument,3);
            //bool result = STD_StudentManager.DeleteSTD_Student(linkButton.CommandArgument);
            STD_StudentManager.LoadSTD_StudentPage(gvSTD_Student, rptPager, 1, ddlPageSize);

        }

        catch (Exception ex)
        {
        }
    }
    protected void lnkDetails_OnClick(object sender, EventArgs e)
    {
        LinkButton lnkButton = new LinkButton();

        lnkButton = (LinkButton)sender;

        string id = "";
        id = lnkButton.CommandArgument;
        Response.Redirect("AdminDetailsSTD_Student.aspx?ID=" + id);
    }

    private void BatchIDLoad()
    {
        try
        {
            DataSet ds = STD_BatchManager.GetAllSTD_Batchs();
            ddlBatchID.DataValueField = "BatchCode";
            ddlBatchID.DataTextField = "BatchName";
            ddlBatchID.DataSource = ds.Tables[0];
            ddlBatchID.DataBind();
            ddlBatchID.Items.Insert(0, new ListItem("Select Batch >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnSeach_OnClick(object sender, EventArgs e)
    {
        if (ddlBatchID.SelectedIndex != 0 || txtFromDate.Text != "" || txtMobile.Text != "" || txtStudentCode.Text != "" || txtStudentName.Text != "" || txtToDate.Text != "")
        {
            List<STD_Student> students = STD_StudentManager.SearchAllSTD_Students(txtStudentName.Text, txtStudentCode.Text, ddlBatchID.SelectedValue != "" ? Convert.ToInt32(ddlBatchID.SelectedValue) : 0,
                txtMobile.Text, txtFromDate.Text != "" ? DateTime.Parse(txtFromDate.Text) : DateTime.Parse("1/1/1753"), txtToDate.Text != "" ? DateTime.Parse(txtToDate.Text) : DateTime.Parse("12/31/9999"));
            
            students.Sort(delegate(STD_Student s1, STD_Student s2) { return s1.StudentCode.CompareTo(s2.StudentCode); });

            gvSTD_Student.DataSource = students;
            gvSTD_Student.DataBind();
            pageID.Visible = false;
        }
        else
        {
            pageID.Visible = true;
            STD_StudentManager.LoadSTD_StudentPage(gvSTD_Student, rptPager, 1, ddlPageSize);
        }
    }
}

