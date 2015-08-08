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
 public partial class AdminCOMN_PersonalDocuments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_PersonalDocumentsData();
         		UserIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_PersonalDocumentsData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_PersonalDocuments cOMN_PersonalDocuments = new COMN_PersonalDocuments ();
//	cOMN_PersonalDocuments.PersonalDocumentsID=  int.Parse(ddlPersonalDocumentsID.SelectedValue);
	cOMN_PersonalDocuments.UserID=  ddlUserID.SelectedValue;
	cOMN_PersonalDocuments.FileName=  txtFileName.Text;
	cOMN_PersonalDocuments.FileLocationUrl=  txtFileLocationUrl.Text;
	cOMN_PersonalDocuments.AddedBy=  Profile.card_id;
	cOMN_PersonalDocuments.AddedDate=  DateTime.Now;
	cOMN_PersonalDocuments.ModifiedBy=  Profile.card_id;
	cOMN_PersonalDocuments.ModifiedDate=  DateTime.Now;
	int resutl =COMN_PersonalDocumentsManager.InsertCOMN_PersonalDocuments(cOMN_PersonalDocuments);
	Response.Redirect("AdminCOMN_PersonalDocumentsDisplay.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_PersonalDocuments cOMN_PersonalDocuments = new COMN_PersonalDocuments ();
	cOMN_PersonalDocuments.PersonalDocumentsID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_PersonalDocuments.UserID=  ddlUserID.SelectedValue;
	cOMN_PersonalDocuments.FileName=  txtFileName.Text;
	cOMN_PersonalDocuments.FileLocationUrl=  txtFileLocationUrl.Text;
	cOMN_PersonalDocuments.AddedBy=  Profile.card_id;
	cOMN_PersonalDocuments.AddedDate=  DateTime.Now;
	cOMN_PersonalDocuments.ModifiedBy=  Profile.card_id;
	cOMN_PersonalDocuments.ModifiedDate=  DateTime.Now;
	bool  resutl =COMN_PersonalDocumentsManager.UpdateCOMN_PersonalDocuments(cOMN_PersonalDocuments);
	Response.Redirect("AdminDisplayCOMN_PersonalDocuments.aspx");
	}
	private void showCOMN_PersonalDocumentsData()
	{
	 	COMN_PersonalDocuments cOMN_PersonalDocuments  = new COMN_PersonalDocuments ();
	 	cOMN_PersonalDocuments = COMN_PersonalDocumentsManager.GetCOMN_PersonalDocumentsByPersonalDocumentsID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlUserID.SelectedValue  =cOMN_PersonalDocuments.UserID.ToString();
	 	txtFileName.Text =cOMN_PersonalDocuments.FileName.ToString();
	 	txtFileLocationUrl.Text =cOMN_PersonalDocuments.FileLocationUrl.ToString();
	}
	
	private void UserIDLoad()
	{
		try {
        //DataSet ds = COMN_UserManager.GetDropDownListAllCOMN_User();
        //ddlUserID.DataValueField = "UserID";
        //ddlUserID.DataTextField = "UserName";
        //ddlUserID.DataSource = ds.Tables[0];
        //ddlUserID.DataBind();
        //ddlUserID.Items.Insert(0, new ListItem("Select User >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

