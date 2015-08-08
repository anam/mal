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
 public partial class AdminSTD_Program : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ProgramData();
         		CourseIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ProgramData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_Program sTD_Program = new STD_Program ();
//	sTD_Program.ProgramID=  int.Parse(ddlProgramID.SelectedValue);
	sTD_Program.ProgramName=  txtProgramName.Text;
	sTD_Program.CourseID=  int.Parse(ddlCourseID.SelectedValue);
	sTD_Program.Description=  txtDescription.Text;
	sTD_Program.Duration=  decimal.Parse(txtDuration.Text);
	sTD_Program.Cost=  decimal.Parse(txtCost.Text);
	sTD_Program.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Program.AddedDate=  DateTime.Now;
	sTD_Program.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Program.UpdateDate=  DateTime.Now;
	int resutl =STD_ProgramManager.InsertSTD_Program(sTD_Program);
	Response.Redirect("AdminDisplaySTD_Program.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_Program sTD_Program = new STD_Program ();
	sTD_Program.ProgramID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Program.ProgramName=  txtProgramName.Text;
	sTD_Program.CourseID=  int.Parse(ddlCourseID.SelectedValue);
	sTD_Program.Description=  txtDescription.Text;
	sTD_Program.Duration=  decimal.Parse(txtDuration.Text);
	sTD_Program.Cost=  decimal.Parse(txtCost.Text);
	sTD_Program.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Program.AddedDate=  DateTime.Now;
	sTD_Program.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Program.UpdateDate=  DateTime.Now;
	bool  resutl =STD_ProgramManager.UpdateSTD_Program(sTD_Program);
	Response.Redirect("AdminDisplaySTD_Program.aspx");
	}
	private void showSTD_ProgramData()
	{
	 	STD_Program sTD_Program  = new STD_Program ();
	 	sTD_Program = STD_ProgramManager.GetSTD_ProgramByProgramID(Int32.Parse(Request.QueryString["ID"]));
	 	txtProgramName.Text =sTD_Program.ProgramName.ToString();
	 	ddlCourseID.SelectedValue  =sTD_Program.CourseID.ToString();
	 	txtDescription.Text =sTD_Program.Description.ToString();
	 	txtDuration.Text =sTD_Program.Duration.ToString();
	 	txtCost.Text =sTD_Program.Cost.ToString();
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
}

