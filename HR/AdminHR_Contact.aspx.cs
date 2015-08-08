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
 public partial class AdminHR_Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showHR_ContactData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	HR_Contact hR_Contact = new HR_Contact ();
//	hR_Contact.ContactID=  int.Parse(ddlContactID.SelectedValue);
    hR_Contact.EmployeeID = Profile.card_id;
	hR_Contact.CurrentAddress=  txtCurrentAddress.Text;
	hR_Contact.PermanentAddress=  txtPermanentAddress.Text;
	hR_Contact.Telephone=  txtTelephone.Text;
	hR_Contact.Mobile=  txtMobile.Text;
	hR_Contact.Email=  txtEmail.Text;
	hR_Contact.AddedBy=  Profile.card_id;
	hR_Contact.AddedDate=  DateTime.Now;
	hR_Contact.ModifiedBy=  Profile.card_id;
	hR_Contact.ModifiedDate=  DateTime.Now;
	int resutl =HR_ContactManager.InsertHR_Contact(hR_Contact);
	Response.Redirect("AdminDisplayHR_Contact.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_Contact hR_Contact = new HR_Contact ();
	hR_Contact.ContactID=  int.Parse(Request.QueryString["ID"].ToString());
    hR_Contact.EmployeeID = Profile.card_id;
	hR_Contact.CurrentAddress=  txtCurrentAddress.Text;
	hR_Contact.PermanentAddress=  txtPermanentAddress.Text;
	hR_Contact.Telephone=  txtTelephone.Text;
	hR_Contact.Mobile=  txtMobile.Text;
	hR_Contact.Email=  txtEmail.Text;
	hR_Contact.AddedBy=  Profile.card_id;
	hR_Contact.AddedDate=  DateTime.Now;
	hR_Contact.ModifiedBy=  Profile.card_id;
	hR_Contact.ModifiedDate=  DateTime.Now;
	bool  resutl =HR_ContactManager.UpdateHR_Contact(hR_Contact);
	

        var  eimployeeID =Request.QueryString["eid"];

        if (eimployeeID != null)
        {
            Response.Redirect("AdminHR_EmployeeDetails.aspx?ID=" + eimployeeID);
        }
        else
        {
            Response.Redirect("AdminDisplayHR_Contact.aspx");
        }
	}
	private void showHR_ContactData()
	{
	 	HR_Contact hR_Contact  = new HR_Contact ();

	 	hR_Contact = HR_ContactManager.GetHR_ContactByContactID(Int32.Parse(Request.QueryString["ID"]));
	 	 
	 	txtCurrentAddress.Text =hR_Contact.CurrentAddress.ToString();
	 	txtPermanentAddress.Text =hR_Contact.PermanentAddress.ToString();
	 	txtTelephone.Text =hR_Contact.Telephone.ToString();
	 	txtMobile.Text =hR_Contact.Mobile.ToString();
	 	txtEmail.Text =hR_Contact.Email.ToString();
	}
	
	 
}

