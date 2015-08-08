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
 

public partial class AdminDisplayACC_Check : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnPaging.Visible = true;

            //ACC_CheckManager.LoadACC_CheckPageByRowStatusID(gvACC_Check, rptPager, 1, ddlPageSize,int.Parse(ddlCheckStatus.SelectedValue));

            _loadBank();
        }
    }


    private void _loadBank()
    {
        DataSet banks = ACC_AccountingUserManager.GetACC_BankForChecks();
        ddlBank.DataValueField = "AccountingUserID";
        ddlBank.DataTextField = "AccountingUserName";
        ddlBank.DataSource = banks;
        ddlBank.DataBind();

        ddlBank.Items.Insert(0, new ListItem("Select Bank >>", "0"));

        loadDefaultCUCBank();
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        ACC_CheckManager.LoadACC_CheckPageByRowStatusID(gvACC_Check, rptPager, 1, ddlPageSize, int.Parse(ddlCheckStatus.SelectedValue));
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        ACC_CheckManager.LoadACC_CheckPageByRowStatusID(gvACC_Check, rptPager, pageIndex, ddlPageSize, int.Parse(ddlCheckStatus.SelectedValue));
    }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminACC_Check.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminACC_Check.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = ACC_CheckManager.DeleteACC_Check(Convert.ToInt32(linkButton.CommandArgument));
        ACC_CheckManager.LoadACC_CheckPageByRowStatusID(gvACC_Check, rptPager, 1, ddlPageSize, int.Parse(ddlCheckStatus.SelectedValue));
  	}

    protected void btnBounch_Click(object sender, EventArgs e)
    {
        Button btnBounch = new Button();
        btnBounch = (Button)sender;
        int id;
        id = Convert.ToInt32(btnBounch.CommandArgument);

        ACC_Check check = new ACC_Check();
        check.CheckID = id;
        check.AddedBy = Profile.card_id; ;

        int newlyAddedJournalMasterID = ACC_CheckManager.CheckBounchByCheckID(check);
        //DataSet dsCheck = new DataSet();
        //dsCheck= ACC_CheckManager.GetACC_CheckByCheckID(id, true);

        //Now we have to wite the operation for the data Entry
        search();
    }

    protected void btnTransactionCompleted_Click(object sender, EventArgs e)
    {
        Button btnBounch = new Button();
        btnBounch = (Button)sender;
        int id;
        id = Convert.ToInt32(btnBounch.CommandArgument);
        string bankID = "0";
        foreach (GridViewRow gr in gvACC_Check.Rows)
        {
            Label lblCheckID = (Label)gr.FindControl("lblCheckID");
            if (lblCheckID.Text == id.ToString())
            {
                DropDownList ddlCUCBank = (DropDownList)gr.FindControl("ddlCUCBank");
                bankID = ddlCUCBank.SelectedValue;
            }
        }
        if (bankID == "0")
        {
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Plase select the bank...')", true);
            lblMessage.Visible = true;
            lblMessage.Text = "Plase select the bank...<br/>";
        }
        else
        {
            ACC_Check check = new ACC_Check();
            check.CheckID = id;
            check.ExtraField1 = bankID;
            check.AddedBy = Profile.card_id; ;

            int newlyAddedJournalMasterID = ACC_CheckManager.CheckTransactinoCompletedByCheckID(check);
            lblMessage.Visible = false;

        }

        search();
       
        //Now we have to wite the operation for the data Entry

    }

    private void loadDefaultCUCBank()
    {
        DataSet dsbank = ACC_BankAccountManager.GetDropDownListAllACC_BankAccount(); //3 for user type Bank
        ddlDefaultCUCBank.Items.Clear();
        foreach (DataRow dr in dsbank.Tables[0].Rows)
        {
            ListItem litems = new ListItem(dr["BankAccountName"].ToString() + " -> " + dr["AccountNo"].ToString(), dr["BankAcountID"].ToString());
            ddlDefaultCUCBank.Items.Add(litems);
        }
        ddlDefaultCUCBank.DataBind();
        ddlDefaultCUCBank.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));
    }

    protected void gvACC_Check_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlCUCBank = (DropDownList)e.Row.FindControl("ddlCUCBank");
            HyperLink hlinkProcess = (HyperLink)e.Row.FindControl("hlinkProcess");
            Label lblRemarks = (Label)e.Row.FindControl("lblRemarks");
            HiddenField hfWhoGivesHeadID = (HiddenField)e.Row.FindControl("hfWhoGivesHeadID");
            if (ddlDefaultCUCBank.Items.Count == 0)
            {
                try
                {
                    DataSet dsbank = ACC_BankAccountManager.GetDropDownListAllACC_BankAccount(); //3 for user type Bank

                    ddlDefaultCUCBank.Items.Clear();
                    foreach (DataRow dr in dsbank.Tables[0].Rows)
                    {
                        ListItem litems = new ListItem(dr["BankAccountName"].ToString() + " -> " + dr["AccountNo"].ToString(), dr["BankAcountID"].ToString());
                        ddlDefaultCUCBank.Items.Add(litems);
                    }
                    ddlDefaultCUCBank.DataBind();
                    ddlDefaultCUCBank.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));


                    ddlCUCBank.Items.Clear();
                    foreach (DataRow dr in dsbank.Tables[0].Rows)
                    {
                        ListItem litems = new ListItem(dr["BankAccountName"].ToString() + " -> " + dr["AccountNo"].ToString(), dr["BankAcountID"].ToString());
                        ddlCUCBank.Items.Add(litems);
                    }
                    ddlCUCBank.DataBind();
                    ddlCUCBank.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));


                    
                }
                catch (Exception ex)
                { }
            }
            else
            {

                ddlCUCBank.Items.Clear();
                foreach (ListItem li in ddlDefaultCUCBank.Items)
                {
                    ddlCUCBank.Items.Add(li);
                }
                ddlCUCBank.DataBind();
                //ddlAccountingUser.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));
            }

            ddlCUCBank.SelectedIndex = 0;
            HiddenField hfCheckID = (HiddenField)e.Row.FindControl("hfCheckID");
            HiddenField hfExtraField1 = (HiddenField)e.Row.FindControl("hfExtraField1");
            if (hfExtraField1.Value != "")
            {
                ddlCUCBank.SelectedValue = hfExtraField1.Value;
            }

            hlinkProcess.NavigateUrl = "~/Accounting/JournalDoubleEntryCommon.aspx?DrOrCr=Cr&BasicAccountID=1&SubBasicAccountID=27&AccountID=43&UserTypeID=1&CheckGiverHeadID=" + hfWhoGivesHeadID.Value + "&Amount=" + lblRemarks.Text + "&UserTypeIDMoney=2&CheckID=" + hfCheckID.Value;

        }
    }

    private void search()
    {
        try
        {
            if (txtCheckDate.Text != "" || txtCheckNo.Text != "" || txtWhomUser.Text != "" || txtWhoUser.Text != "" || ddlBank.SelectedIndex != 0)
            {
                pnPaging.Visible = false;

                string WhomUser = txtWhomUser.Text;
                string WhoUser = txtWhoUser.Text;

                WhomUser = WhomUser == "" ? "" : (chkEmployee.Checked ? HR_EmployeeManager.GetHR_EmployeeByEmployeeNo(WhomUser).EmployeeID : STD_StudentManager.GetHR_StudnetByStudentCode(WhomUser).StudentID);
                WhoUser = WhoUser == "" ? "" : (!chkStudent.Checked ? HR_EmployeeManager.GetHR_EmployeeByEmployeeNo(WhoUser).EmployeeID : STD_StudentManager.GetHR_StudnetByStudentCode(WhoUser).StudentID);


                gvACC_Check.DataSource = ACC_CheckManager.SearchACC_Checks(WhomUser, WhoUser, txtCheckNo.Text, Convert.ToInt32(ddlBank.SelectedValue), txtCheckDate.Text, int.Parse(ddlCheckStatus.SelectedValue));
                gvACC_Check.DataBind();
            }
            else
            {
                pnPaging.Visible = true;
                ACC_CheckManager.LoadACC_CheckPageByRowStatusID(gvACC_Check, rptPager, 1, ddlPageSize, int.Parse(ddlCheckStatus.SelectedValue));
            }
        }
        catch (Exception ex)
        { }
    }

    protected void btnSeach_OnClick(object sender, EventArgs e)
    {
        search();
    }
}

