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
 public partial class AdminUSER_Roles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadUSER_RolesData();
         		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showUSER_RolesData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	USER_Roles uSER_Roles = new USER_Roles ();
//	uSER_Roles.RoleID=  int.Parse(ddlRoleID.SelectedValue);
	uSER_Roles.AddedBy=  txtAddedBy.Text;
	uSER_Roles.AddedDate=  DateTime.Now;
	uSER_Roles.UpdatedBy=  txtUpdatedBy.Text;
	uSER_Roles.UpdatedDate=  DateTime.Now;
	uSER_Roles.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =USER_RolesManager.InsertUSER_Roles(uSER_Roles);
	Response.Redirect("AdminDisplayUSER_Roles.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	USER_Roles uSER_Roles = new USER_Roles ();
	uSER_Roles.RoleID=  int.Parse(Request.QueryString["ID"].ToString());
	uSER_Roles.AddedBy=  txtAddedBy.Text;
	uSER_Roles.AddedDate=  DateTime.Now;
	uSER_Roles.UpdatedBy=  txtUpdatedBy.Text;
	uSER_Roles.UpdatedDate=  DateTime.Now;
	uSER_Roles.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =USER_RolesManager.UpdateUSER_Roles(uSER_Roles);
	Response.Redirect("AdminDisplayUSER_Roles.aspx");
	}
	private void showUSER_RolesData()
	{
	 	USER_Roles uSER_Roles  = new USER_Roles ();
	 	uSER_Roles = USER_RolesManager.GetUSER_RolesByRoleID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlRowStatusID.SelectedValue  =uSER_Roles.RowStatusID.ToString();
	}
	
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = UserRowStatusManager.GetDropDownListAllUserRowStatus();
		ddlRowStatusID.DataValueField = "RowStatusID";
		ddlRowStatusID.DataTextField = "RowStatusName";
		ddlRowStatusID.DataSource = ds.Tables[0];
		ddlRowStatusID.DataBind();
		ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

