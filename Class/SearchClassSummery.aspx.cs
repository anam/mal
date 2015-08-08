using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Class_SearchClassSummery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            
        }
    }
    protected void btnSeach_OnClick(object sender, EventArgs e)
    {
        gvSTD_ClassSummery.DataSource = STD_StudentManager.GetSTD_StudentClassSummery(txtStudentCode.Text, txtFromDate.Text != "" ? DateTime.Parse(txtFromDate.Text) : DateTime.Parse("1/1/1753"), txtToDate.Text != "" ? DateTime.Parse(txtToDate.Text).AddDays(1) : DateTime.Parse("1/1/9999").AddDays(1));
        gvSTD_ClassSummery.DataBind();

        foreach (GridViewRow row in gvSTD_ClassSummery.Rows)
        {
            Label lblNoOfClass = (Label)row.FindControl("lblNoOfClass");
            Label lblNoOfPresent = (Label)row.FindControl("lblNoOfPresent");
            Label lblNoAbsent = (Label)row.FindControl("lblNoAbsent");

            lblNoAbsent.Text = (Convert.ToInt32(lblNoOfClass.Text) - Convert.ToInt32(lblNoOfPresent.Text)).ToString();
        }
    }
    protected void lnkClassSummery_OnClick(object sender, EventArgs e)
    {
        LinkButton lnkButton = new LinkButton();
        lnkButton = (LinkButton)sender;

        string studentID = lnkButton.ToolTip;
        int classSubjectID = Convert.ToInt32(lnkButton.CommandArgument);

        Response.Redirect("StudentClassDetails.aspx?studentID=" + studentID + "&classSubjectID=" + classSubjectID);
    }
}