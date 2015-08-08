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
 public partial class AdminSTD_Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ContactData();
         		StudentIDLoad();
		ContactTypeIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ContactData();
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        STD_Contact sTD_Contact = new STD_Contact();
        //	sTD_Contact.ContactID=  int.Parse(ddlContactID.SelectedValue);
        sTD_Contact.StudentID = ddlStudentID.SelectedValue;
        sTD_Contact.Name = txtName.Text;
        sTD_Contact.CellNo = txtCellNo.Text;
        sTD_Contact.Occupation = txtOccupation.Text;
        sTD_Contact.OfficeTel = txtOfficeTel.Text;
        sTD_Contact.OfficeAddress = txtOfficeAddress.Text;
        sTD_Contact.ContactTypeID = int.Parse(ddlContactTypeID.SelectedValue);
        sTD_Contact.AddedBy = Profile.card_id;
        sTD_Contact.AddedDate = DateTime.Now;
        sTD_Contact.ModifiedBy = Profile.card_id;
        sTD_Contact.ModifiedDate = DateTime.Now;
        sTD_Contact.RowStatusID = 1;
        int resutl = STD_ContactManager.InsertSTD_Contact(sTD_Contact);
        Response.Redirect("AdminDisplaySTD_Contact.aspx");
    }
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_Contact sTD_Contact = new STD_Contact ();
	sTD_Contact.ContactID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Contact.StudentID=  ddlStudentID.SelectedValue;
	sTD_Contact.Name=  txtName.Text;
	sTD_Contact.CellNo=  txtCellNo.Text;
	sTD_Contact.Occupation=  txtOccupation.Text;
	sTD_Contact.OfficeTel=  txtOfficeTel.Text;
	sTD_Contact.OfficeAddress=  txtOfficeAddress.Text;
	sTD_Contact.ContactTypeID=  int.Parse(ddlContactTypeID.SelectedValue);
	sTD_Contact.AddedBy=  Profile.card_id;
	sTD_Contact.AddedDate=  DateTime.Now;
	sTD_Contact.ModifiedBy=  Profile.card_id;
	sTD_Contact.ModifiedDate=  DateTime.Now;
	bool  resutl =STD_ContactManager.UpdateSTD_Contact(sTD_Contact);
	Response.Redirect("AdminDisplaySTD_Contact.aspx");
	}
	private void showSTD_ContactData()
	{
	 	STD_Contact sTD_Contact  = new STD_Contact ();
	 	sTD_Contact = STD_ContactManager.GetSTD_ContactByContactID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlStudentID.SelectedValue  =sTD_Contact.StudentID.ToString();
	 	txtName.Text =sTD_Contact.Name.ToString();
	 	txtCellNo.Text =sTD_Contact.CellNo.ToString();
	 	txtOccupation.Text =sTD_Contact.Occupation.ToString();
	 	txtOfficeTel.Text =sTD_Contact.OfficeTel.ToString();
	 	txtOfficeAddress.Text =sTD_Contact.OfficeAddress.ToString();
	 	ddlContactTypeID.SelectedValue  =sTD_Contact.ContactTypeID.ToString();
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
	private void ContactTypeIDLoad()
	{
		try {
		DataSet ds = STD_ContactTypeManager.GetDropDownListAllSTD_ContactType();
		ddlContactTypeID.DataValueField = "ContactTypeID";
		ddlContactTypeID.DataTextField = "ContactTypeName";
		ddlContactTypeID.DataSource = ds.Tables[0];
		ddlContactTypeID.DataBind();
		ddlContactTypeID.Items.Insert(0, new ListItem("Select ContactType >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

