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
 public partial class AdminSTD_Chapter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ChapterData();
         		SubjectIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ChapterData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_Chapter sTD_Chapter = new STD_Chapter ();
//	sTD_Chapter.ChapterID=  int.Parse(ddlChapterID.SelectedValue);
	sTD_Chapter.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	sTD_Chapter.ChapterName=  txtChapterName.Text;
	sTD_Chapter.Description=  txtDescription.Text;
	sTD_Chapter.AddedBy=  Profile.card_id;
	sTD_Chapter.AddedDate=  DateTime.Now;
	sTD_Chapter.UpdatedBy=  Profile.card_id;
	sTD_Chapter.UpdateDate = DateTime.Now; 
	int resutl =STD_ChapterManager.InsertSTD_Chapter(sTD_Chapter);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Chapter.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_Chapter sTD_Chapter = new STD_Chapter ();
	sTD_Chapter.ChapterID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Chapter.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	sTD_Chapter.ChapterName=  txtChapterName.Text;
	sTD_Chapter.Description=  txtDescription.Text;
	sTD_Chapter.AddedBy=  Profile.card_id;
	sTD_Chapter.AddedDate=  DateTime.Now;
	sTD_Chapter.UpdatedBy=  Profile.card_id;
	sTD_Chapter.UpdateDate = DateTime.Now; 
	bool  resutl =STD_ChapterManager.UpdateSTD_Chapter(sTD_Chapter);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Chapter.aspx");
	}
	private void showSTD_ChapterData()
	{
	 	STD_Chapter sTD_Chapter  = new STD_Chapter ();
	 	sTD_Chapter = STD_ChapterManager.GetSTD_ChapterByChapterID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlSubjectID.SelectedValue  =sTD_Chapter.SubjectID.ToString();
	 	txtChapterName.Text =sTD_Chapter.ChapterName.ToString();
	 	txtDescription.Text =sTD_Chapter.Description.ToString();
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
}

