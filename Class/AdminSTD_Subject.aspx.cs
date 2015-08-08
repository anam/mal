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
 public partial class AdminSTD_Subject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_SubjectData();
         		CourseIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_SubjectData();
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_Subject sTD_Subject = new STD_Subject();
            //	sTD_Subject.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
            sTD_Subject.CourseID = int.Parse(ddlCourseID.SelectedValue);
            sTD_Subject.SubjectName = txtSubjectName.Text;
            sTD_Subject.Description = txtDescription.Text;
            sTD_Subject.ExtraField1 = txtPassMark.Text;
            sTD_Subject.ExtraField2 = "";
            sTD_Subject.ExtraField3 = "";
            sTD_Subject.ExtraField4 = "";
            sTD_Subject.ExtraField5 = "";
            sTD_Subject.AddedBy = Profile.card_id;
            sTD_Subject.AddedDate = DateTime.Now;
            sTD_Subject.UpdatedBy = Profile.card_id;
            sTD_Subject.UpdateDate = DateTime.Now;
            int resutl = STD_SubjectManager.InsertSTD_Subject(sTD_Subject);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplaySTD_Subject.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_Subject sTD_Subject = new STD_Subject();
            sTD_Subject.SubjectID = int.Parse(Request.QueryString["ID"].ToString());
            sTD_Subject.CourseID = int.Parse(ddlCourseID.SelectedValue);
            sTD_Subject.SubjectName = txtSubjectName.Text;
            sTD_Subject.Description = txtDescription.Text;
            sTD_Subject.ExtraField1 = txtPassMark.Text;
            sTD_Subject.ExtraField2 = "";
            sTD_Subject.ExtraField3 = "";
            sTD_Subject.ExtraField4 = "";
            sTD_Subject.ExtraField5 = "";
            sTD_Subject.AddedBy = Profile.card_id;
            sTD_Subject.AddedDate = DateTime.Now;
            sTD_Subject.UpdatedBy = Profile.card_id;
            sTD_Subject.UpdateDate = DateTime.Now;
            bool resutl = STD_SubjectManager.UpdateSTD_Subject(sTD_Subject);
        }
        catch (Exception ex)
        {
        }
        Response.Redirect("AdminDisplaySTD_Subject.aspx");
    }
	private void showSTD_SubjectData()
	{
	 	STD_Subject sTD_Subject  = new STD_Subject ();
	 	sTD_Subject = STD_SubjectManager.GetSTD_SubjectBySubjectID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlCourseID.SelectedValue  =sTD_Subject.CourseID.ToString();
	 	txtSubjectName.Text =sTD_Subject.SubjectName.ToString();
	 	txtDescription.Text =sTD_Subject.Description.ToString();
	}
	
	private void CourseIDLoad()
	{
        try
        {
            DataSet ds = STD_CourseManager.GetDropDownListAllSTD_Course();
            ddlCourseID.DataValueField = "CourseID";
            ddlCourseID.DataTextField = "CourseName";
            ddlCourseID.DataSource = ds.Tables[0];
            ddlCourseID.DataBind();
            ddlCourseID.Items.Insert(0, new ListItem("Select Course >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
	 }
}

