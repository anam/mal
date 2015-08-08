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
 public partial class AdminACC_SubBasicAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_SubBasicAccountData();
         		BasicAccountIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_SubBasicAccountData();
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ACC_SubBasicAccount aCC_SubBasicAccount = new ACC_SubBasicAccount();
            //	aCC_SubBasicAccount.SubBasicAccountID=  int.Parse(ddlSubBasicAccountID.SelectedValue);
            aCC_SubBasicAccount.SubBasicAccountCode = "";
            aCC_SubBasicAccount.SubBasicAccountName = txtSubBasicAccountName.Text;
            aCC_SubBasicAccount.Description = txtDescription.Text;
            aCC_SubBasicAccount.BasicAccountID = int.Parse(ddlBasicAccountID.SelectedValue);
            aCC_SubBasicAccount.AddedBy = Profile.card_id;
            aCC_SubBasicAccount.AddedDate = DateTime.Now;
            aCC_SubBasicAccount.UpdatedBy = Profile.card_id;
            aCC_SubBasicAccount.UpdateDate = DateTime.Now;
            aCC_SubBasicAccount.RowStatusID = 1;
            int resutl = ACC_SubBasicAccountManager.InsertACC_SubBasicAccount(aCC_SubBasicAccount);
            Response.Redirect("AdminDisplayACC_SubBasicAccount.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ACC_SubBasicAccount aCC_SubBasicAccount = new ACC_SubBasicAccount();
            aCC_SubBasicAccount.SubBasicAccountID = int.Parse(Request.QueryString["ID"].ToString());
            aCC_SubBasicAccount.SubBasicAccountCode = "";
            aCC_SubBasicAccount.SubBasicAccountName = txtSubBasicAccountName.Text;
            aCC_SubBasicAccount.Description = txtDescription.Text;
            aCC_SubBasicAccount.BasicAccountID = int.Parse(ddlBasicAccountID.SelectedValue);
            aCC_SubBasicAccount.AddedBy = Profile.card_id;
            aCC_SubBasicAccount.AddedDate = DateTime.Now;
            aCC_SubBasicAccount.UpdatedBy = Profile.card_id;
            aCC_SubBasicAccount.UpdateDate = DateTime.Now;
            aCC_SubBasicAccount.RowStatusID = 1;
            bool resutl = ACC_SubBasicAccountManager.UpdateACC_SubBasicAccount(aCC_SubBasicAccount);
            Response.Redirect("AdminDisplayACC_SubBasicAccount.aspx");
        }

        catch (Exception ex)
        {
        }
    }
	private void showACC_SubBasicAccountData()
	{
	 	ACC_SubBasicAccount aCC_SubBasicAccount  = new ACC_SubBasicAccount ();
	 	aCC_SubBasicAccount = ACC_SubBasicAccountManager.GetACC_SubBasicAccountBySubBasicAccountID(Int32.Parse(Request.QueryString["ID"]));
	 	
	 	txtSubBasicAccountName.Text =aCC_SubBasicAccount.SubBasicAccountName.ToString();
	 	txtDescription.Text =aCC_SubBasicAccount.Description.ToString();
	 	ddlBasicAccountID.SelectedValue  =aCC_SubBasicAccount.BasicAccountID.ToString();
	 	
	}
	
	private void BasicAccountIDLoad()
	{
		try {
		DataSet ds = ACC_BasicAccountManager.GetDropDownListAllACC_BasicAccount();
		ddlBasicAccountID.DataValueField = "BasicAccountID";
		ddlBasicAccountID.DataTextField = "BasicAccountName";
		ddlBasicAccountID.DataSource = ds.Tables[0];
		ddlBasicAccountID.DataBind();
		ddlBasicAccountID.Items.Insert(0, new ListItem("Select BasicAccount >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
        //try {
        //DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
        //ddlRowStatusID.DataValueField = "RowStatusID";
        //ddlRowStatusID.DataTextField = "RowStatusName";
        //ddlRowStatusID.DataSource = ds.Tables[0];
        //ddlRowStatusID.DataBind();
        //ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
        //}
        //catch (Exception ex) {
        //ex.Message.ToString();
        //}
	 }
}

