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
 public partial class AdminLIB_Publisher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadLIB_PublisherData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showLIB_PublisherData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	LIB_Publisher lIB_Publisher = new LIB_Publisher ();
//	lIB_Publisher.PublisherID=  int.Parse(ddlPublisherID.SelectedValue);
	lIB_Publisher.Address=  txtAddress.Text;
	lIB_Publisher.PublisherName=  txtPublisherName.Text;
	lIB_Publisher.Email=  txtEmail.Text;
	lIB_Publisher.Phone=  txtPhone.Text;
	lIB_Publisher.Mobile=  txtMobile.Text;
	lIB_Publisher.Country=  txtCountry.Text;
	lIB_Publisher.AddedBy=  Profile.card_id;
	lIB_Publisher.AddedDate=  DateTime.Now;
	lIB_Publisher.ModifiedBy=  Profile.card_id;
	lIB_Publisher.ModifiedDate=  DateTime.Now;
	int resutl =LIB_PublisherManager.InsertLIB_Publisher(lIB_Publisher);
    }catch(Exception ex){}Response.Redirect("AdminDisplayLIB_Publisher.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	LIB_Publisher lIB_Publisher = new LIB_Publisher ();
	lIB_Publisher.PublisherID=  int.Parse(Request.QueryString["ID"].ToString());
	lIB_Publisher.Address=  txtAddress.Text;
	lIB_Publisher.PublisherName=  txtPublisherName.Text;
	lIB_Publisher.Email=  txtEmail.Text;
	lIB_Publisher.Phone=  txtPhone.Text;
	lIB_Publisher.Mobile=  txtMobile.Text;
	lIB_Publisher.Country=  txtCountry.Text;
	lIB_Publisher.AddedBy=  Profile.card_id;
	lIB_Publisher.AddedDate=  DateTime.Now;
	lIB_Publisher.ModifiedBy=  Profile.card_id;
	lIB_Publisher.ModifiedDate=  DateTime.Now;
	bool  resutl =LIB_PublisherManager.UpdateLIB_Publisher(lIB_Publisher);
	}catch(Exception ex){}Response.Redirect("AdminDisplayLIB_Publisher.aspx");
	}
	private void showLIB_PublisherData()
	{
	 	LIB_Publisher lIB_Publisher  = new LIB_Publisher ();
	 	lIB_Publisher = LIB_PublisherManager.GetLIB_PublisherByPublisherID(Int32.Parse(Request.QueryString["ID"]));
	 	txtAddress.Text =lIB_Publisher.Address.ToString();
	 	txtPublisherName.Text =lIB_Publisher.PublisherName.ToString();
	 	txtEmail.Text =lIB_Publisher.Email.ToString();
	 	txtPhone.Text =lIB_Publisher.Phone.ToString();
	 	txtMobile.Text =lIB_Publisher.Mobile.ToString();
	 	txtCountry.Text =lIB_Publisher.Country.ToString();
	}
	
}

