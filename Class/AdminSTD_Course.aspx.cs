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
 public partial class AdminSTD_Course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_CourseData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_CourseData();
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_Course sTD_Course = new STD_Course();
            //	sTD_Course.CourseID=  int.Parse(ddlCourseID.SelectedValue);
            sTD_Course.CourseName = txtCourseName.Text;
            sTD_Course.Description = txtDescription.Text;
            sTD_Course.Duration = txtDuration.Text;
            sTD_Course.Cost = decimal.Parse(txtCost.Text);
            sTD_Course.AddedBy = Profile.card_id;
            sTD_Course.AddedDate = DateTime.Now;
            sTD_Course.UpdatedBy = Profile.card_id;
            sTD_Course.UpdateDate = DateTime.Now;
            int resutl = STD_CourseManager.InsertSTD_Course(sTD_Course);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplaySTD_Course.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            STD_Course sTD_Course = new STD_Course();
            sTD_Course.CourseID = int.Parse(Request.QueryString["ID"].ToString());
            sTD_Course.CourseName = txtCourseName.Text;
            sTD_Course.Description = txtDescription.Text;
            sTD_Course.Duration = txtDuration.Text;
            sTD_Course.Cost = decimal.Parse(txtCost.Text);
            sTD_Course.AddedBy = Profile.card_id;
            sTD_Course.AddedDate = DateTime.Now;
            sTD_Course.UpdatedBy = Profile.card_id;
            sTD_Course.UpdateDate = DateTime.Now;
            bool resutl = STD_CourseManager.UpdateSTD_Course(sTD_Course);
        }
        catch (Exception ex) { } Response.Redirect("AdminDisplaySTD_Course.aspx");
    }
	private void showSTD_CourseData()
	{
	 	STD_Course sTD_Course  = new STD_Course ();
	 	sTD_Course = STD_CourseManager.GetSTD_CourseByCourseID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCourseName.Text =sTD_Course.CourseName.ToString();
	 	txtDescription.Text =sTD_Course.Description.ToString();
	 	txtDuration.Text =sTD_Course.Duration.ToString();
	 	txtCost.Text =sTD_Course.Cost.ToString();
	}
	
}

