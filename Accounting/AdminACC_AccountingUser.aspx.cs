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
 public partial class AdminACC_AccountingUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_AccountingUserData();
         		UserTypeIDLoad();
		        RowStatusIDLoad();
                ddlRowStatusID.SelectedIndex = 1;
            if (Request.QueryString["ID"] != null)
            {
                    int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_AccountingUserData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_AccountingUser aCC_AccountingUser = new ACC_AccountingUser ();
//	aCC_AccountingUser.AccountingUserID=  int.Parse(ddlAccountingUserID.SelectedValue);
	aCC_AccountingUser.AccountingUserName=  txtAccountingUserName.Text;
	aCC_AccountingUser.UserTypeID=  int.Parse(ddlUserTypeID.SelectedValue);
	aCC_AccountingUser.AddedBy=  Profile.card_id;
	aCC_AccountingUser.AddedDate=  DateTime.Now;
	aCC_AccountingUser.UpdatedBy=  Profile.card_id;
	aCC_AccountingUser.UpdateDate=  DateTime.Now;
	aCC_AccountingUser.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =ACC_AccountingUserManager.InsertACC_AccountingUser(aCC_AccountingUser);
	Response.Redirect("AdminDisplayACC_AccountingUser.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_AccountingUser aCC_AccountingUser = new ACC_AccountingUser ();
	aCC_AccountingUser.AccountingUserID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_AccountingUser.AccountingUserName=  txtAccountingUserName.Text;
	aCC_AccountingUser.UserTypeID=  int.Parse(ddlUserTypeID.SelectedValue);
	aCC_AccountingUser.AddedBy=  Profile.card_id;
	aCC_AccountingUser.AddedDate=  DateTime.Now;
	aCC_AccountingUser.UpdatedBy=  Profile.card_id;
	aCC_AccountingUser.UpdateDate=  DateTime.Now;
	aCC_AccountingUser.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_AccountingUserManager.UpdateACC_AccountingUser(aCC_AccountingUser);
	Response.Redirect("AdminDisplayACC_AccountingUser.aspx");
	}
	private void showACC_AccountingUserData()
	{
	 	ACC_AccountingUser aCC_AccountingUser  = new ACC_AccountingUser ();
	 	aCC_AccountingUser = ACC_AccountingUserManager.GetACC_AccountingUserByAccountingUserID(Int32.Parse(Request.QueryString["ID"]));
	 	txtAccountingUserName.Text =aCC_AccountingUser.AccountingUserName.ToString();
	 	ddlUserTypeID.SelectedValue  =aCC_AccountingUser.UserTypeID.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_AccountingUser.RowStatusID.ToString();
	}
	
	private void UserTypeIDLoad()
	{
		try {

            ListItem li = new ListItem("Select UserType...", "0");
            ddlUserTypeID.Items.Add(li);

            DataSet ds = COMN_UserTypeManager.GetDropDownListAllCOMN_UserType();
           foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["UserTypeName"].ToString() != "Student" && dr["UserTypeName"].ToString() != "Employee" && dr["UserTypeName"].ToString() != "Campus")
                {
                    ListItem item = new ListItem(dr["UserTypeName"].ToString(), dr["UserTypeID"].ToString());
                    ddlUserTypeID.Items.Add(item);
                }
            }
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
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

