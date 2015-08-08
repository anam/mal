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
 public partial class AdminSTD_ClassSubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassSubjectData();
         		SubjectIDLoad();
		ClassIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassSubjectData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject ();
//	sTD_ClassSubject.ClassSubjectID=  int.Parse(ddlClassSubjectID.SelectedValue);
	sTD_ClassSubject.ClassSubjectName=  txtClassSubjectName.Text;
	sTD_ClassSubject.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	sTD_ClassSubject.ClassID=  int.Parse(ddlClassID.SelectedValue);
	sTD_ClassSubject.AddedBy=  Profile.card_id;
	sTD_ClassSubject.AddedDate=  DateTime.Now;
	sTD_ClassSubject.UpdatedBy=  Profile.card_id;
	sTD_ClassSubject.UpdateDate = DateTime.Now; 
	int resutl =STD_ClassSubjectManager.InsertSTD_ClassSubject(sTD_ClassSubject);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassSubject.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_ClassSubject sTD_ClassSubject = new STD_ClassSubject ();
	sTD_ClassSubject.ClassSubjectID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ClassSubject.ClassSubjectName=  txtClassSubjectName.Text;
	sTD_ClassSubject.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	sTD_ClassSubject.ClassID=  int.Parse(ddlClassID.SelectedValue);
	sTD_ClassSubject.AddedBy=  Profile.card_id;
	sTD_ClassSubject.AddedDate=  DateTime.Now;
	sTD_ClassSubject.UpdatedBy=  Profile.card_id;
	sTD_ClassSubject.UpdateDate = DateTime.Now; 
	bool  resutl =STD_ClassSubjectManager.UpdateSTD_ClassSubject(sTD_ClassSubject);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassSubject.aspx");
	}
	private void showSTD_ClassSubjectData()
	{
	 	STD_ClassSubject sTD_ClassSubject  = new STD_ClassSubject ();
	 	sTD_ClassSubject = STD_ClassSubjectManager.GetSTD_ClassSubjectByClassSubjectID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassSubjectName.Text =sTD_ClassSubject.ClassSubjectName.ToString();
	 	ddlSubjectID.SelectedValue  =sTD_ClassSubject.SubjectID.ToString();
	 	ddlClassID.SelectedValue  =sTD_ClassSubject.ClassID.ToString();
	}
	
	private void SubjectIDLoad()
	{
		try {
		DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_Subject();
		ddlSubjectID.DataValueField = "SubjectID";
		ddlSubjectID.DataTextField = "SubjectName";
		ddlSubjectID.DataSource = ds.Tables[0];
		ddlSubjectID.DataBind();
		ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
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
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

