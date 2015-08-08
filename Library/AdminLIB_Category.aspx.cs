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
 public partial class AdminLIB_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadLIB_CategoryData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showLIB_CategoryData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	LIB_Category lIB_Category = new LIB_Category ();
//	lIB_Category.CategoryID=  int.Parse(ddlCategoryID.SelectedValue);
	lIB_Category.CategoryName=  txtCategoryName.Text;
	lIB_Category.AddedBy=  Profile.card_id;
	lIB_Category.AddedDate=  DateTime.Now;
	lIB_Category.ModifiedBy=  Profile.card_id;
	lIB_Category.ModifiedDate=  DateTime.Now;
	int resutl =LIB_CategoryManager.InsertLIB_Category(lIB_Category);
	Response.Redirect("AdminDisplayLIB_Category.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	LIB_Category lIB_Category = new LIB_Category ();
	lIB_Category.CategoryID=  int.Parse(Request.QueryString["ID"].ToString());
	lIB_Category.CategoryName=  txtCategoryName.Text;
	lIB_Category.AddedBy=  Profile.card_id;
	lIB_Category.AddedDate=  DateTime.Now;
	lIB_Category.ModifiedBy=  Profile.card_id;
	lIB_Category.ModifiedDate=  DateTime.Now;
	bool  resutl =LIB_CategoryManager.UpdateLIB_Category(lIB_Category);
	Response.Redirect("AdminDisplayLIB_Category.aspx");
	}
	private void showLIB_CategoryData()
	{
	 	LIB_Category lIB_Category  = new LIB_Category ();
	 	lIB_Category = LIB_CategoryManager.GetLIB_CategoryByCategoryID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCategoryName.Text =lIB_Category.CategoryName.ToString();
	}
	
}

