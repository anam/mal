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
 public partial class AdminSTD_StudentContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_StudentContactData();
         		SudentIDLoad();
		ContactIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_StudentContactData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_StudentContact sTD_StudentContact = new STD_StudentContact ();
//	sTD_StudentContact.StudentContactID=  int.Parse(ddlStudentContactID.SelectedValue);
	sTD_StudentContact.SudentID=  ddlSudentID.SelectedValue;
	sTD_StudentContact.ContactID=  int.Parse(ddlContactID.SelectedValue);
	sTD_StudentContact.AddedBy=  Profile.card_id;
	sTD_StudentContact.AddedDate=  DateTime.Now;
	sTD_StudentContact.UpdatedBy=  Profile.card_id;
	sTD_StudentContact.UpdateDate = DateTime.Now; 
	int resutl =STD_StudentContactManager.InsertSTD_StudentContact(sTD_StudentContact);
        }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_StudentContact.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_StudentContact sTD_StudentContact = new STD_StudentContact ();
	sTD_StudentContact.StudentContactID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_StudentContact.SudentID=  ddlSudentID.SelectedValue;
	sTD_StudentContact.ContactID=  int.Parse(ddlContactID.SelectedValue);
	sTD_StudentContact.AddedBy=  Profile.card_id;
	sTD_StudentContact.AddedDate=  DateTime.Now;
	sTD_StudentContact.UpdatedBy=  Profile.card_id;
	sTD_StudentContact.UpdateDate = DateTime.Now; 
	bool  resutl =STD_StudentContactManager.UpdateSTD_StudentContact(sTD_StudentContact);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_StudentContact.aspx");
	}
	private void showSTD_StudentContactData()
	{
	 	STD_StudentContact sTD_StudentContact  = new STD_StudentContact ();
	 	sTD_StudentContact = STD_StudentContactManager.GetSTD_StudentContactByStudentContactID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlSudentID.SelectedValue  =sTD_StudentContact.SudentID.ToString();
	 	ddlContactID.SelectedValue  =sTD_StudentContact.ContactID.ToString();
	 	string txtUpdatedBy_Text =sTD_StudentContact.UpdatedBy.ToString();
	 	string txtUpdateDate_Text =sTD_StudentContact.UpdateDate.ToString();
	}
	
	private void SudentIDLoad()
	{
		try {
		DataSet ds = STD_StudentManager.GetDropDownListAllSTD_Student();
		ddlSudentID.DataValueField = "SudentID";
		ddlSudentID.DataTextField = "SudentName";
		ddlSudentID.DataSource = ds.Tables[0];
		ddlSudentID.DataBind();
		ddlSudentID.Items.Insert(0, new ListItem("Select Sudent >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void ContactIDLoad()
	{
		try {
		DataSet ds = STD_ContactManager.GetDropDownListAllSTD_Contact();
		ddlContactID.DataValueField = "ContactID";
		ddlContactID.DataTextField = "ContactName";
		ddlContactID.DataSource = ds.Tables[0];
		ddlContactID.DataBind();
		ddlContactID.Items.Insert(0, new ListItem("Select Contact >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

