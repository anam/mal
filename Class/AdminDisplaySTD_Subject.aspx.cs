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
 

public partial class AdminDisplaySTD_Subject : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
        CourseIDLoad();
       STD_SubjectManager.LoadSTD_SubjectPage(gvSTD_Subject, rptPager, 1, ddlPageSize,ddlCourseID);
      }
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
     protected void PageSize_Changed(object sender, EventArgs e)
    {
        STD_SubjectManager.LoadSTD_SubjectPage(gvSTD_Subject, rptPager, 1, ddlPageSize, ddlCourseID);
 }
  protected void Page_Changed(object sender, EventArgs e)
    {
       int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
       STD_SubjectManager.LoadSTD_SubjectPage(gvSTD_Subject, rptPager, pageIndex, ddlPageSize, ddlCourseID);
   }
	
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminSTD_Subject.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = STD_SubjectManager.DeleteSTD_Subject(Convert.ToInt32(linkButton.CommandArgument));
        STD_SubjectManager.LoadSTD_SubjectPage(gvSTD_Subject, rptPager, 1, ddlPageSize, ddlCourseID);
  	}
    protected void ddlCourseID_SelectedIndexChanged(object sender, EventArgs e)
    {
        STD_SubjectManager.LoadSTD_SubjectPage(gvSTD_Subject, rptPager, 1, ddlPageSize, ddlCourseID);
    }
}

