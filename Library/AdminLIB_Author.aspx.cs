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
 public partial class AdminLIB_Author : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadLIB_AuthorData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showLIB_AuthorData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	LIB_Author lIB_Author = new LIB_Author ();
//	lIB_Author.AuthorID=  int.Parse(ddlAuthorID.SelectedValue);
	lIB_Author.AuthorName=  txtAuthorName.Text;
	lIB_Author.Address=  txtAddress.Text;
	lIB_Author.Email=  txtEmail.Text;
	lIB_Author.Phone=  txtPhone.Text;
	lIB_Author.Mobile=  txtMobile.Text;
	lIB_Author.Country=  txtCountry.Text;
	lIB_Author.AddedBy=  Profile.card_id;
	lIB_Author.AddedDate=  DateTime.Now;
	lIB_Author.ModifiedBy=  Profile.card_id;
	lIB_Author.ModifiedDate=  DateTime.Now;
	int resutl =LIB_AuthorManager.InsertLIB_Author(lIB_Author);
	}catch(Exception ex){}Response.Redirect("AdminDisplayLIB_Author.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	LIB_Author lIB_Author = new LIB_Author ();
	lIB_Author.AuthorID=  int.Parse(Request.QueryString["ID"].ToString());
	lIB_Author.AuthorName=  txtAuthorName.Text;
	lIB_Author.Address=  txtAddress.Text;
	lIB_Author.Email=  txtEmail.Text;
	lIB_Author.Phone=  txtPhone.Text;
	lIB_Author.Mobile=  txtMobile.Text;
	lIB_Author.Country=  txtCountry.Text;
	lIB_Author.AddedBy=  Profile.card_id;
	lIB_Author.AddedDate=  DateTime.Now;
	lIB_Author.ModifiedBy=  Profile.card_id;
	lIB_Author.ModifiedDate=  DateTime.Now;
	bool  resutl =LIB_AuthorManager.UpdateLIB_Author(lIB_Author);
	}catch(Exception ex){}Response.Redirect("AdminDisplayLIB_Author.aspx");
	}
	private void showLIB_AuthorData()
	{
	 	LIB_Author lIB_Author  = new LIB_Author ();
	 	lIB_Author = LIB_AuthorManager.GetLIB_AuthorByAuthorID(Int32.Parse(Request.QueryString["ID"]));
	 	txtAuthorName.Text =lIB_Author.AuthorName.ToString();
	 	txtAddress.Text =lIB_Author.Address.ToString();
	 	txtEmail.Text =lIB_Author.Email.ToString();
	 	txtPhone.Text =lIB_Author.Phone.ToString();
	 	txtMobile.Text =lIB_Author.Mobile.ToString();
	 	txtCountry.Text =lIB_Author.Country.ToString();
	}
	
}

