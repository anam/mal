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
 public partial class AdminACC_BasicAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_BasicAccountData();
         		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_BasicAccountData();
                }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ACC_BasicAccount aCC_BasicAccount = new ACC_BasicAccount();
            //	aCC_BasicAccount.BasicAccountID=  int.Parse(ddlBasicAccountID.SelectedValue);
            aCC_BasicAccount.BasicAccountCode = "";
            aCC_BasicAccount.BasicAccountName = txtBasicAccountName.Text;
            aCC_BasicAccount.Description = txtDescription.Text;
            aCC_BasicAccount.AddedBy = Profile.card_id;
            aCC_BasicAccount.AddedDate = DateTime.Now;
            aCC_BasicAccount.UpdatedBy = Profile.card_id;
            aCC_BasicAccount.UpdateDate = DateTime.Now;
            aCC_BasicAccount.RowStatusID = 1;
            int resutl = ACC_BasicAccountManager.InsertACC_BasicAccount(aCC_BasicAccount);
            Response.Redirect("AdminDisplayACC_BasicAccount.aspx");
        }

        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ACC_BasicAccount aCC_BasicAccount = new ACC_BasicAccount();
            aCC_BasicAccount.BasicAccountID = int.Parse(Request.QueryString["ID"].ToString());
            aCC_BasicAccount.BasicAccountCode = "";
            aCC_BasicAccount.BasicAccountName = txtBasicAccountName.Text;
            aCC_BasicAccount.Description = txtDescription.Text;
            aCC_BasicAccount.AddedBy = Profile.card_id;
            aCC_BasicAccount.AddedDate = DateTime.Now;
            aCC_BasicAccount.UpdatedBy = Profile.card_id;
            aCC_BasicAccount.UpdateDate = DateTime.Now;
            aCC_BasicAccount.RowStatusID = 1;
            bool resutl = ACC_BasicAccountManager.UpdateACC_BasicAccount(aCC_BasicAccount);
            Response.Redirect("AdminDisplayACC_BasicAccount.aspx");
        }
        catch (Exception ex)
        {
        }
    }
	private void showACC_BasicAccountData()
	{
	 	ACC_BasicAccount aCC_BasicAccount  = new ACC_BasicAccount ();
	 	aCC_BasicAccount = ACC_BasicAccountManager.GetACC_BasicAccountByBasicAccountID(Int32.Parse(Request.QueryString["ID"]));
	 	
	 	txtBasicAccountName.Text =aCC_BasicAccount.BasicAccountName.ToString();
	 	txtDescription.Text =aCC_BasicAccount.Description.ToString();
	 	
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

