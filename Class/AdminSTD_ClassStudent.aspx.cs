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
 public partial class AdminSTD_ClassStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassStudentData();
         		StudentIDLoad();
		ClassIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassStudentData();
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent();
            //	sTD_ClassStudent.ClassStudentID=  int.Parse(ddlClassStudentID.SelectedValue);
            sTD_ClassStudent.ClassStudentName = txtClassStudentName.Text;
            sTD_ClassStudent.StudentID = ddlStudentID.SelectedValue;
            sTD_ClassStudent.ClassID = int.Parse(ddlClassID.SelectedValue);
            sTD_ClassStudent.AddedBy = Profile.card_id;
            sTD_ClassStudent.AddedDate = DateTime.Now;
            sTD_ClassStudent.UpdatedBy = Profile.card_id;
            sTD_ClassStudent.UpdateDate = DateTime.Now;
            sTD_ClassStudent.RowStatusID = 1;
            int resutl = STD_ClassStudentManager.InsertSTD_ClassStudent(sTD_ClassStudent);
        }
        catch (Exception ex)
        {
        }
        
        Response.Redirect("AdminDisplaySTD_ClassStudent.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_ClassStudent sTD_ClassStudent = new STD_ClassStudent ();
	sTD_ClassStudent.ClassStudentID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ClassStudent.ClassStudentName=  txtClassStudentName.Text;
	sTD_ClassStudent.StudentID=  ddlStudentID.SelectedValue;
	sTD_ClassStudent.ClassID=  int.Parse(ddlClassID.SelectedValue);
	sTD_ClassStudent.AddedBy=  Profile.card_id;
	sTD_ClassStudent.AddedDate=  DateTime.Now;
	sTD_ClassStudent.UpdatedBy=  Profile.card_id;
	sTD_ClassStudent.UpdateDate = DateTime.Now; 
	bool  resutl =STD_ClassStudentManager.UpdateSTD_ClassStudent(sTD_ClassStudent);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassStudent.aspx");
	}
	private void showSTD_ClassStudentData()
	{
	 	STD_ClassStudent sTD_ClassStudent  = new STD_ClassStudent ();
	 	sTD_ClassStudent = STD_ClassStudentManager.GetSTD_ClassStudentByClassStudentID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassStudentName.Text =sTD_ClassStudent.ClassStudentName.ToString();
	 	ddlStudentID.SelectedValue  =sTD_ClassStudent.StudentID.ToString();
	 	ddlClassID.SelectedValue  =sTD_ClassStudent.ClassID.ToString();
	}
	
	private void StudentIDLoad()
	{
		try {
		DataSet ds = STD_StudentManager.GetDropDownListAllSTD_Student();
		ddlStudentID.DataValueField = "StudentID";
		ddlStudentID.DataTextField = "StudentName";
		ddlStudentID.DataSource = ds.Tables[0];
		ddlStudentID.DataBind();
		ddlStudentID.Items.Insert(0, new ListItem("Select Student >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void ClassIDLoad()
	{
		try {
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
}

