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
 public partial class AdminLIB_SubCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadLIB_SubCategoryData();
         		CategoryIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showLIB_SubCategoryData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	LIB_SubCategory lIB_SubCategory = new LIB_SubCategory ();
//	lIB_SubCategory.SubCategoryID=  int.Parse(ddlSubCategoryID.SelectedValue);
	lIB_SubCategory.SubCategoryName=  txtSubCategoryName.Text;
	lIB_SubCategory.CategoryID=  int.Parse(ddlCategoryID.SelectedValue);
	lIB_SubCategory.AddedBy=  Profile.card_id;
	lIB_SubCategory.AddedDate=  DateTime.Now;
	lIB_SubCategory.ModifiedBy=  Profile.card_id;
	lIB_SubCategory.ModifiedDate=  DateTime.Now;
	int resutl =LIB_SubCategoryManager.InsertLIB_SubCategory(lIB_SubCategory);
	Response.Redirect("AdminDisplayLIB_SubCategory.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	LIB_SubCategory lIB_SubCategory = new LIB_SubCategory ();
	lIB_SubCategory.SubCategoryID=  int.Parse(Request.QueryString["ID"].ToString());
	lIB_SubCategory.SubCategoryName=  txtSubCategoryName.Text;
	lIB_SubCategory.CategoryID=  int.Parse(ddlCategoryID.SelectedValue);
	lIB_SubCategory.AddedBy=  Profile.card_id;
	lIB_SubCategory.AddedDate=  DateTime.Now;
	lIB_SubCategory.ModifiedBy=  Profile.card_id;
	lIB_SubCategory.ModifiedDate=  DateTime.Now;
	bool  resutl =LIB_SubCategoryManager.UpdateLIB_SubCategory(lIB_SubCategory);
	Response.Redirect("AdminDisplayLIB_SubCategory.aspx");
	}
	private void showLIB_SubCategoryData()
	{
	 	LIB_SubCategory lIB_SubCategory  = new LIB_SubCategory ();
	 	lIB_SubCategory = LIB_SubCategoryManager.GetLIB_SubCategoryBySubCategoryID(Int32.Parse(Request.QueryString["ID"]));
	 	txtSubCategoryName.Text =lIB_SubCategory.SubCategoryName.ToString();
	 	ddlCategoryID.SelectedValue  =lIB_SubCategory.CategoryID.ToString();
	}
	
	private void CategoryIDLoad()
	{
		try {
		DataSet ds = LIB_CategoryManager.GetDropDownListAllLIB_Category();
		ddlCategoryID.DataValueField = "CategoryID";
		ddlCategoryID.DataTextField = "CategoryName";
		ddlCategoryID.DataSource = ds.Tables[0];
		ddlCategoryID.DataBind();
		ddlCategoryID.Items.Insert(0, new ListItem("Select Category >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

