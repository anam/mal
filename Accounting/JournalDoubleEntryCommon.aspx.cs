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

public partial class AdminACC_Voucher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Remarks"] != null)
            {
                txtRemarks.Text = Request.QueryString["Remarks"];
            }

            txtCUCCheckDate.Text = DateTime.Today.ToShortDateString();
            BasicAccountIDLoad();
            
            Session["doubleEntry"] = null;
            if (Request.QueryString["BasicAccountID"] != null)
            {
                ddlBasicAccountID.SelectedValue = Request.QueryString["BasicAccountID"];
                ddlBasicAccountID.Visible = false;
                //lblBasicAccountID.Visible = false;
                ddlBasicAccountID_SelectedIndexChanged(this, new EventArgs());
            }

            if (Request.QueryString["SubBasicAccountID"] != null)
            {
                ddlSubBasicAccountID.SelectedValue = Request.QueryString["SubBasicAccountID"];
                ddlSubBasicAccountID.Visible = false;
                //lblSubBasicAccountID.Visible = false;
                ddlSubBasicAccountID_SelectedIndexChanged(this, new EventArgs());
            }

            UserTypeIDLoad();
            AccountIDLoad();
            
            if (Request.QueryString["HeadID"] != null)
            {
                ddlBasicAccountID.SelectedValue = Request.QueryString["HeadID"];
                ddlBasicAccountID.Visible = false;
                //lblBasicAccountID.Visible = false;
                ddlBasicAccountID_SelectedIndexChanged(this, new EventArgs());
            }

            if (Request.QueryString["AccountID"] != null)
            {
                
                ddlBasicAccountID.Visible = false;
                ddlAccountID.SelectedValue = Request.QueryString["AccountID"];
            }

            if (Request.QueryString["AccountIDMoney"] != null)
            {
                ddlAccountForMoney.SelectedValue = Request.QueryString["AccountIDMoney"];
            }

            if (Request.QueryString["UserTypeID"] != null)
            {
                ddlUserTypeID.SelectedValue = Request.QueryString["UserTypeID"];
                ddlUserTypeID_SelectedIndexChanged(this, new EventArgs());

                if (Request.QueryString["EmployeeID"] != null)
                {
                    ddlAccountingUser.SelectedValue = Request.QueryString["EmployeeID"];
                    txtAmount.Text = Request.QueryString["Amount"];
                    txtAmount.Enabled = false;
                    txtAmountMoney.Text = Request.QueryString["Amount"];
                    ddlSubBasicAccountID.Visible = false;
                    ddlBasicAccountID.Visible = false;
                    txtStudentCode.Visible = false;

                    getHead(false);
                }

            }


           
            if (Request.QueryString["UserTypeIDMoney"] != null)
            {
                if (ddlUserTypeIDMoney.Items.Count > 0)
                {
                    if (ddlUserTypeIDMoney.SelectedItem.Text == "Student")
                    {
                        txtStudentCodeMoney.Visible = true;
                        ddlAccountingUserMoney.Visible = false;
                        //txtStudentCodeMoney.ReadOnly = true;
                    }
                    else
                    {
                        ddlAccountingUserMoney.Visible = true;
                        txtStudentCodeMoney.Visible = false;
                        ddlUserTypeIDMoney.SelectedValue = Request.QueryString["UserTypeIDMoney"];
                        ddlUserTypeIDMoney_SelectedIndexChanged(this, new EventArgs());

                        if (Request.QueryString["UserTypeIDMoney"] == "2")
                        {
                            ddlAccountingUserMoney.Enabled = false;
                            ddlUserTypeIDMoney.Enabled = false;
                        }
                    }
                }
            }
            //HeadIDLoad();
            RowStatusIDLoad();
            loadDebitOrCredit();
            
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showACC_VoucherData();
            }

            initialDataLoad();

            if (Request.QueryString["StudentCode"] != null)
            {
                txtStudentCode.Visible = true;
                txtStudentCode.Enabled = false;
                ddlAccountingUser.Visible = false;
                txtAmount.Text = Request.QueryString["Amount"];
                txtAmount.Enabled = false;
                txtAmountMoney.Text = txtAmount.Text;
                txtStudentCode.Text = Request.QueryString["StudentCode"];
                getHead(false);
                //btnVarify_OnClick(this, new EventArgs());
                //btnAdd_Click(this, new EventArgs());
            }


            //processing for check bounching
            if (Request.QueryString["CheckGiverHeadID"] != null)
            {
                ACC_HeadUser headuser = new ACC_HeadUser();
                headuser = ACC_HeadUserManager.GetACC_HeadByHeadID(int.Parse(Request.QueryString["CheckGiverHeadID"]));
                ddlUserTypeID.SelectedValue = headuser.UserTypeID.ToString();

                if (headuser.UserTypeID == 1)
                {
                    txtStudentCode.Text = STD_StudentManager.GetSTD_StudentByStudentID(headuser.UserID).StudentCode;
                    btnVarify_OnClick(this, new EventArgs());
                    ddlUserTypeID_SelectedIndexChanged(this, new EventArgs());
                }
                else
                {
                    ddlUserTypeID_SelectedIndexChanged(this, new EventArgs());
                    ddlAccountingUser.SelectedValue = headuser.UserID.ToString();
                    ddlAccountingUser_SelectedIndexChanged(this, new EventArgs());
                }

                txtAmount.Text = Request.QueryString["Amount"];
                txtAmount.Enabled = false;
                //btnAdd_Click(this, new EventArgs());
                //btnAdd.Visible = false;
            }
        }
    }

    private void initialDataLoad()
    {
        if (Request.QueryString["OtherTransaction"] != null)
        {
            //lblFromTransaction.Text = "Credit Entry";
            //lblToTransaction.Text = "Debit Entry";
            ddlDrCrOtherTransaction.Visible = true;
            if (Request.QueryString["Amount"] != null)
            {
                txtAmount.Text = Request.QueryString["Amount"];
                txtAmount.Enabled = false;
            }
            lblMessageOtherTransactiondt.Visible = true;
            lblMessageOtherTransactiondd.Visible = true;
        }
        else
        {
            ddlDrCrOtherTransaction.Visible = false;
            lblMessageOtherTransactiondt.Visible = false;
            lblMessageOtherTransactiondd.Visible = false;
        }

        txtCheckDate.Text = String.Format("{0:dd MMM yyyy}", DateTime.Today);

        if (Request.QueryString["AccountID"] != null)
        {
            if (Request.QueryString["AccountIDMoney"] != null)
            {
                if (Request.QueryString["AccountID"] == Request.QueryString["AccountIDMoney"])
                {
                    if (Request.QueryString["DrOrCr"] == "Cr")
                    {
                        lblFromTransaction.Text = "To User";
                        lblToTransaction.Text = "From User";
                    }
                    else
                    {
                        lblFromTransaction.Text = "From User";
                        lblToTransaction.Text = "To User";
                    }
                }
            }
        }
    }

    private void ClearAllControllJournalEntry()
    {
        /*
        ddlBasicAccountID.SelectedIndex = 0;
        ddlSubBasicAccountID.SelectedIndex = 0;
        ddlAccountID.SelectedIndex = 0;
        ddlAccountingUser.SelectedIndex = 0;
        ddlUserTypeID.SelectedIndex = 0;
        ddlBank.SelectedIndex = 0;
        txtAmount.Text = "0";
        txtNewCompany.Text = "";
        txtStudentCode.Text = "";
        lblHeadName.Text = "";   
          
         */
    }

    private void ClearAllControllMoney()
    {
        /*
        ddlAccountForMoney.SelectedIndex = 0;
        ddlUserTypeIDMoney.SelectedIndex = 0;
        ddlAccountingUserMoney.SelectedIndex = 0;
        ddlBank.SelectedIndex = 0;
        txtAccountNo.Text = "0";
        txtAmountMoney.Text = "0";
        txtBranchInfo.Text = "";
        txtCheckDate.Text = DateTime.Today.ToShortDateString();
        txtAccountNo.Text = "0";
        txtCheckNo.Text = "";
        txtNewBank.Text = "";
        txtNewCompanyMoney.Text = "";
        txtStudentCodeMoney.Text = "";
        lblHeadNameMoney.Text = "";
         */
    }

    private void BasicAccountIDLoad()
    {
        try
        {
            DataSet ds = ACC_BasicAccountManager.GetDropDownListAllACC_BasicAccount();
            ddlBasicAccountID.DataValueField = "BasicAccountID";
            ddlBasicAccountID.DataTextField = "BasicAccountName";
            ddlBasicAccountID.DataSource = ds.Tables[0];
            ddlBasicAccountID.DataBind();
            ddlBasicAccountID.Items.Insert(0, new ListItem("Select BasicAccount >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void ddlBasicAccountID_SelectedIndexChanged(object sender, EventArgs e)
    {

        SubBasicAccountIDLoad();
        loadDebitOrCredit();
    }

    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBank.SelectedItem.Text == "New Bank")
        {
            txtNewBank.Visible = true;
            divNewBank.Visible = true;
        }
        else
        {
            txtNewBank.Visible = false;
            divNewBank.Visible = false;
        }
    }

    protected void chkCashCheck_CheckedChanged(object sender, EventArgs e)
    {
        if (!chkCashCheck.Checked)
        {
            if (ddlBankAccountID.Items.Count == 0)
            {
                try
                {
                    DataSet ds = ACC_BankAccountManager.GetDropDownListAllACC_BankAccount(); //3 for user type Bank
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ListItem litems = new ListItem(dr["BankAccountName"].ToString() + " -> " + dr["AccountNo"].ToString(), dr["BankAcountID"].ToString());
                        ddlBankAccountID.Items.Add(litems);
                    }
                    ddlBankAccountID.DataBind();
                    ddlBankAccountID.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));
                }
                catch (Exception ex)
                { }
            }

            divPayToBank.Visible = true;
        }
        else
        {
            divPayToBank.Visible = false;
        }

    }

    protected void ddlAccountForMoney_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlAccountForMoney.SelectedValue == "42")//Check in hand
        {
            divMoneyReceivibale.Visible = true;

            if (ddlBank.Items.Count == 0)
            {
                DataSet ds = ACC_AccountingUserManager.GetACC_UserTypeByUserTypeID(3, true); //3 for user type Bank
                ddlBank.DataValueField = "AccountingUserID";
                ddlBank.DataTextField = "AccountingUserName";
                ddlBank.DataSource = ds.Tables[0];
                ddlBank.DataBind();
                ddlBank.Items.Insert(0, new ListItem("Select >>", "0"));
                ddlBank.Items.Insert(ddlBank.Items.Count, new ListItem("New Bank", "-1"));
            }

            ddlUserTypeIDMoney.SelectedValue = "2";
        }
        else
        {
            divMoneyReceivibale.Visible = false;
        }

        if (ddlAccountForMoney.SelectedValue == "2" )//Chash at bank
        {
            divCUCBankAccount.Visible = true;
            ddlUserTypeIDMoney.SelectedValue = "3";
            ddlAccountingUserMoney.Enabled = true;
            
        }
        else
        {
            ddlAccountingUserMoney.Enabled = false;
            divCUCBankAccount.Visible = false;
        }

        if (ddlAccountForMoney.SelectedValue == "1")//Check in hand
        {
            ddlUserTypeIDMoney.SelectedValue = "2";
        }
        ddlUserTypeIDMoney_SelectedIndexChanged(this, new EventArgs());


        getHeadMoney(false);
    }

    protected void ddlSubBasicAccountID_SelectedIndexChanged(object sender, EventArgs e)
    {
        AccountIDLoad();
    }

    private void SubBasicAccountIDLoad()
    {
        try
        {
            DataSet ds = ACC_SubBasicAccountManager.GetACC_SubBasicAccountByBasicAccountIDDataset(int.Parse(ddlBasicAccountID.SelectedValue));
            ddlSubBasicAccountID.DataValueField = "SubBasicAccountID";
            ddlSubBasicAccountID.DataTextField = "SubBasicAccountName";
            ddlSubBasicAccountID.DataSource = ds.Tables[0];
            ddlSubBasicAccountID.DataBind();
            ddlSubBasicAccountID.Items.Insert(0, new ListItem("Select SubBasicAccount >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void loadDebitOrCredit()
    {
        if (Request.QueryString["DrOrCr"] != null)
        {
            ddlDebitOrCredit.SelectedValue = Request.QueryString["DrOrCr"];
            if (Request.QueryString["DrOrCr"] == "Cr")
            {
                ddlDebitOrCreditMoney.SelectedValue = "Dr";
            }
            else
            {
                ddlDebitOrCreditMoney.SelectedValue = "Cr";
            }
        }
        else
        {
            /*
             * <select id="ctl00_MainContent_ddlBasicAccountID" onchange="javascript:setTimeout('__doPostBack(\'ctl00$MainContent$ddlBasicAccountID\',\'\')', 0)" name="ctl00$MainContent$ddlBasicAccountID">
	<option value="0">Select BasicAccount &gt;&gt;</option>
	<option value="1">Assets</option>
	<option value="2" selected="selected">Expense</option>
	<option value="3">Income</option>
	<option value="4">Liability</option>
	<option value="5">Capital</option>

</select>
             */
            switch (ddlAccountID.SelectedValue)
            {
                case "1":
                    //Assets
                    ddlDebitOrCredit.SelectedValue = "Dr";
                    ddlDebitOrCreditMoney.SelectedValue = "Cr";
                    break;
                case "2":
                    //Expense
                    ddlDebitOrCredit.SelectedValue = "Dr";
                    ddlDebitOrCreditMoney.SelectedValue = "Cr";
                    break;
                case "3":
                    //Income
                    ddlDebitOrCredit.SelectedValue = "Cr";
                    ddlDebitOrCreditMoney.SelectedValue = "Dr";
                    break;
                case "4":
                    //Liability
                    ddlDebitOrCredit.SelectedValue = "Cr";
                    ddlDebitOrCreditMoney.SelectedValue = "Dr";
                    break;
                case "5":
                    //Capital
                    ddlDebitOrCredit.SelectedValue = "Cr";
                    ddlDebitOrCreditMoney.SelectedValue = "Dr";
                    break;
                default:
                    break;
            }
        }
    }
    private void AccountIDLoad()
    {
        try
        {
            DataSet ds = new DataSet();

            if (Request.QueryString["MoneyTransfer"] != null)
            {
                ds = ACC_AccountManager.GetACC_AccountByBasicAccountID(1, true);
                ddlAccountID.DataValueField = "AccountID";
                ddlAccountID.DataTextField = "AccountName";
                ddlAccountID.DataSource = ds.Tables[0];
                ddlAccountID.DataBind();
                ddlAccountID.Items.Insert(0, new ListItem("Select Account >>", "0"));
            }
            else
            {
                try
                {
                    ds = ACC_AccountManager.GetACC_AccountBySubBasicAccountID(int.Parse(Request.QueryString["SubBasicAccountID"] == null ? ddlSubBasicAccountID.SelectedValue : Request.QueryString["SubBasicAccountID"]), true);
                    ddlAccountID.DataValueField = "AccountID";
                    ddlAccountID.DataTextField = "AccountName";
                    ddlAccountID.DataSource = ds.Tables[0];
                    ddlAccountID.DataBind();
                    ddlAccountID.Items.Insert(0, new ListItem("Select Account >>", "0"));
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }

            //ds = ACC_AccountManager.GetACC_AccountByBasicAccountID(1, true);
            //ddlAccountForMoney.DataValueField = "AccountID";
            //ddlAccountForMoney.DataTextField = "AccountName";
            //ddlAccountForMoney.DataSource = ds.Tables[0];
            //ddlAccountForMoney.DataBind();
            //ddlAccountForMoney.Items.Insert(0, new ListItem("Select Account >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void UserTypeIDLoad()
    {
        try
        {
            DataSet ds = COMN_UserTypeManager.GetDropDownListAllCOMN_UserType();
            ddlUserTypeID.DataValueField = "UserTypeID";
            ddlUserTypeID.DataTextField = "UserTypeName";
            ddlUserTypeID.DataSource = ds.Tables[0];
            ddlUserTypeID.DataBind();
            ddlUserTypeID.Items.Insert(0, new ListItem("Select UserType >>", "0"));


            ddlUserTypeIDMoney.DataValueField = "UserTypeID";
            ddlUserTypeIDMoney.DataTextField = "UserTypeName";
            ddlUserTypeIDMoney.DataSource = ds.Tables[0];
            ddlUserTypeIDMoney.DataBind();
            ddlUserTypeIDMoney.Items.Insert(0, new ListItem("Select UserType >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private bool IsUser(string user)
    {
        STD_Student student = new STD_Student();
        student = STD_StudentManager.GetHR_StudnetByStudentCode(user);

        if (student == null)
            return false;
        else
        {
            hfStudentID.Value = student.StudentID;
            return true;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
            if (Session["doubleEntry"] != null)
            {
                doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];
            }
            if (txtStudentCode.Visible != false)
            {
                if (IsUser(txtStudentCode.Text))
                {
                    ACC_Journal aCC_Journal = new ACC_Journal();
                    aCC_Journal.JournalID = doubleEntry.Count;
                    aCC_Journal.HeadID = int.Parse(hfHeadID.Value);
                    aCC_Journal.HeadName = lblHeadName.Text;
                    aCC_Journal.Debit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Dr" ? txtAmount.Text : "0");
                    aCC_Journal.Credit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Cr" ? txtAmount.Text : "0");
                    aCC_Journal.JournalMasterID = int.Parse("1");
                    aCC_Journal.JournalVoucherNo = "";
                    aCC_Journal.SubBasicAccountID = int.Parse(Request.QueryString["SubBasicAccountID"] == null ? ddlSubBasicAccountID.SelectedValue : Request.QueryString["SubBasicAccountID"]);
                    aCC_Journal.UserID = hfStudentID.Value;
                    aCC_Journal.AccountID = int.Parse(ddlAccountID.SelectedValue);
                    aCC_Journal.UserTypeID = int.Parse(ddlUserTypeID.SelectedValue);
                    aCC_Journal.AddedBy = Profile.card_id;
                    aCC_Journal.AddedDate = DateTime.Now;
                    aCC_Journal.UpdatedBy = Profile.card_id;
                    aCC_Journal.UpdateDate = DateTime.Now;
                    aCC_Journal.RowStatusID = 1;
                    aCC_Journal.IsNotCheck = true;

                    doubleEntry.Add(aCC_Journal);
                    Session["doubleEntry"] = doubleEntry;
                    loadJournal();
                    loadSubmitButton();
                    lblUser.Text = "";
                }
                else
                {
                    lblUser.Text = "User is not exist";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('User is not exist')", true);
                }
            }

            else
            {
                ACC_Journal aCC_Journal = new ACC_Journal();
                aCC_Journal.JournalID = doubleEntry.Count;
                aCC_Journal.HeadID = int.Parse(hfHeadID.Value);
                aCC_Journal.HeadName = lblHeadName.Text;
                aCC_Journal.Debit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Dr" ? txtAmount.Text : "0");
                aCC_Journal.Credit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Cr" ? txtAmount.Text : "0");
                aCC_Journal.JournalMasterID = int.Parse("1");
                aCC_Journal.JournalVoucherNo = "";
                aCC_Journal.UserID = ddlAccountingUser.SelectedValue;
                aCC_Journal.AccountID = int.Parse(ddlAccountID.SelectedValue);
                aCC_Journal.UserTypeID = int.Parse(ddlUserTypeID.SelectedValue);
                aCC_Journal.AddedBy = Profile.card_id;
                aCC_Journal.AddedDate = DateTime.Now;
                aCC_Journal.UpdatedBy = Profile.card_id;
                aCC_Journal.UpdateDate = DateTime.Now;
                aCC_Journal.RowStatusID = 1;
                aCC_Journal.IsNotCheck = true;
                aCC_Journal.SubBasicAccountID = 0;


                doubleEntry.Add(aCC_Journal);
                Session["doubleEntry"] = doubleEntry;
                loadJournal();
                loadSubmitButton();
            }

            //load the Check from
            hfCheckFrom.Value += hfHeadID.Value + "," + lblHeadName.Text + ";";
            ListItem litems = new ListItem(lblHeadName.Text, hfHeadID.Value);
            ddlCheckFrom.Items.Add(litems);
            ddlCheckFrom.DataBind();

            ClearAllControllJournalEntry();
        }

        catch (Exception ex)
        {
        }
    }

    private void loadSubmitButton()
    {
        decimal debit = 0;
        decimal credit = 0;

        List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
        doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];

        if (doubleEntry != null)
        {
            foreach (ACC_Journal jornal in doubleEntry)
            {
                debit += jornal.Debit;
                credit += jornal.Credit;
            }


            lblDebit.Text = debit.ToString();
            lblCredit.Text = credit.ToString();


            if (decimal.Parse(lblDebit.Text) == decimal.Parse(lblCredit.Text))
            {
                btnJournalEntry.Visible = true;
                lblJournalEntry.Visible = false;
            }
            else
            {
                btnJournalEntry.Visible = false;
                lblJournalEntry.Visible = true;
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //doubleEntry[int.Parse(hfJournalID.Value)].JournalID = doubleEntry.Count;
        List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
        doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];

        doubleEntry[int.Parse(hfJournalID.Value)].HeadID = int.Parse(hfHeadID.Value);
        doubleEntry[int.Parse(hfJournalID.Value)].HeadName = lblHeadName.Text;
        if (hfIsMoney.Value == "0")
        {
            doubleEntry[int.Parse(hfJournalID.Value)].Debit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Dr" ? txtAmount.Text : "0");
            doubleEntry[int.Parse(hfJournalID.Value)].Credit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Cr" ? txtAmount.Text : "0");
            doubleEntry[int.Parse(hfJournalID.Value)].UserID = ddlAccountingUser.SelectedValue;
            doubleEntry[int.Parse(hfJournalID.Value)].AccountID = int.Parse(ddlAccountID.SelectedValue);
            doubleEntry[int.Parse(hfJournalID.Value)].UserTypeID = int.Parse(ddlUserTypeID.SelectedValue);

            btnAdd.Visible = true;
            btnUpdate.Visible = false;
        }
        else
        {
            doubleEntry[int.Parse(hfJournalID.Value)].Debit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Cr" ? txtAmountMoney.Text : "0");
            doubleEntry[int.Parse(hfJournalID.Value)].Credit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Dr" ? txtAmountMoney.Text : "0");
            doubleEntry[int.Parse(hfJournalID.Value)].UserID = ddlAccountingUserMoney.SelectedValue;
            doubleEntry[int.Parse(hfJournalID.Value)].AccountID = int.Parse(ddlAccountForMoney.SelectedValue);
            doubleEntry[int.Parse(hfJournalID.Value)].UserTypeID = int.Parse(ddlUserTypeIDMoney.SelectedValue);

            btnMoneyAdd.Visible = true;
            btnMoneyUpdate.Visible = false;
        }

        doubleEntry[int.Parse(hfJournalID.Value)].JournalMasterID = int.Parse("1");
        doubleEntry[int.Parse(hfJournalID.Value)].JournalVoucherNo = "";

        doubleEntry[int.Parse(hfJournalID.Value)].UpdatedBy = Profile.card_id;
        doubleEntry[int.Parse(hfJournalID.Value)].UpdateDate = DateTime.Now;


        loadJournal();
        loadSubmitButton();

    }
    private void showACC_VoucherData()
    {
        ACC_Voucher aCC_Voucher = new ACC_Voucher();
        aCC_Voucher = ACC_VoucherManager.GetACC_VoucherByVoucherID(Int32.Parse(Request.QueryString["ID"]));

    }

    private void HeadIDLoad()
    {
        try
        {
            //DataSet ds = ACC_HeadManager.GetDropDownListAllACC_Head();
            //ddlHeadID.DataValueField = "HeadID";
            //ddlHeadID.DataTextField = "HeadName";
            //ddlHeadID.DataSource = ds.Tables[0];
            //ddlHeadID.DataBind();
            //ddlHeadID.Items.Insert(0, new ListItem("Select Head >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void RowStatusIDLoad()
    {
        try
        {
            //DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
            //ddlRowStatusID.DataValueField = "RowStatusID";
            //ddlRowStatusID.DataTextField = "RowStatusName";
            //ddlRowStatusID.DataSource = ds.Tables[0];
            //ddlRowStatusID.DataBind();
            //ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void ddlUserTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        divNewCompany.Visible = false;
        //ibtnRefresh.Visible = false;
        ddlAccountingUser.Items.Clear();
        if (ddlUserTypeID.SelectedIndex != 0)
        {
            switch (ddlUserTypeID.SelectedValue)
            {
                case "1":
                    {
                        txtStudentCode.Visible = true;
                        ddlAccountingUser.Visible = false;
                        btnVarify.Visible = true;
                        //DataSet ds = STD_StudentManager.GetDropDownListAllSTD_Student();
                        //ddlAccountingUser.DataValueField = "StudentID";
                        //ddlAccountingUser.DataTextField = "StudentName";
                        //ddlAccountingUser.DataSource = ds.Tables[0];
                        //ddlAccountingUser.DataBind();
                        //ddlAccountingUser.Items.Insert(0, new ListItem("Select >>", "0"));
                    }
                    break;
                case "2":
                    {
                        txtStudentCode.Visible = false;
                        ddlAccountingUser.Visible = true;
                        btnVarify.Visible = false;
                        
                        DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();

                        ListItem li = new ListItem("Select Employee...", "0");
                        ddlAccountingUser.Items.Add(li);

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (bool.Parse(dr["Flag"].ToString()) == true)
                            {
                                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeID"].ToString());
                                ddlAccountingUser.Items.Add(item);
                            }
                        }

                    }
                    break;
                case "3":
                    {
                        txtStudentCode.Visible = false;
                        ddlAccountingUser.Visible = true;
                        btnVarify.Visible = false;
                        //DataSet ds = ACC_AccountingUserManager.GetACC_UserTypeByUserTypeID(3, true);
                        //DataSet ds = ACC_AccountingUserManager.GetAllACC_AccountingUsersOnlyBank();
                        //ddlAccountingUser.DataValueField = "AccountingUserID";
                        //ddlAccountingUser.DataTextField = "AccountingUserName";
                        //ddlAccountingUser.DataSource = ds.Tables[0];
                        //ddlAccountingUser.DataBind();
                        //ddlAccountingUser.Items.Insert(0, new ListItem("Select >>", "0"));
                        //ddlAccountingUser.Items.Insert(ddlAccountingUser.Items.Count, new ListItem("New Company", "-1"));


                        if (ddlBankAccountID.Items.Count == 0)
                        {
                            try
                            {
                                DataSet dsbank = ACC_BankAccountManager.GetDropDownListAllACC_BankAccount(); //3 for user type Bank
                                ddlAccountingUser.Items.Clear();
                                foreach (DataRow dr in dsbank.Tables[0].Rows)
                                {
                                    ListItem litems = new ListItem("(" + dr["BankAccountName"].ToString() + ") " + dr["AccountNo"].ToString(), dr["BankAcountID"].ToString());
                                    ddlAccountingUser.Items.Add(litems);
                                }
                                ddlAccountingUser.DataBind();
                                ddlAccountingUser.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));
                            }
                            catch (Exception ex)
                            { }
                        }
                        else
                        {
                            ddlAccountingUser.Items.Clear();
                            foreach (ListItem li in ddlBankAccountID.Items)
                            {
                                ddlAccountingUser.Items.Add(li);
                            }
                            ddlAccountingUser.DataBind();
                            //ddlAccountingUser.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));
                        }
                    }
                    break;
                case "4":
                    {
                        txtStudentCode.Visible = false;
                        ddlAccountingUser.Visible = true;
                        btnVarify.Visible = false;
                        DataSet ds = ACC_AccountingUserManager.GetACC_UserTypeByUserTypeID(4, true);
                        ddlAccountingUser.DataValueField = "AccountingUserID";
                        ddlAccountingUser.DataTextField = "AccountingUserName";
                        ddlAccountingUser.DataSource = ds.Tables[0];
                        ddlAccountingUser.DataBind();
                        ddlAccountingUser.Items.Insert(0, new ListItem("Select >>", "0"));
                        ddlAccountingUser.Items.Insert(ddlAccountingUser.Items.Count, new ListItem("New Company", "-1"));
                    }
                    break;
                case "5":
                    {
                        txtStudentCode.Visible = false;
                        ddlAccountingUser.Visible = true;
                        btnVarify.Visible = false;
                        DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
                        ddlAccountingUser.DataValueField = "CampusID";
                        ddlAccountingUser.DataTextField = "CampusName";
                        ddlAccountingUser.DataSource = ds.Tables[0];
                        ddlAccountingUser.DataBind();
                        ddlAccountingUser.Items.Insert(0, new ListItem("Select >>", "0"));
                    }
                    break;
                default:
                    break;
            }
        }
    }

    protected void addNewCompay_Click(object sender, EventArgs e)
    {
        ibtnRefresh.Visible = false;
        getHead(true);
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        getHead(true);
    }

    private void getHead(bool IsNewCompany)
    {
        string UserID = "";
        string UserName = "";
        if (ddlAccountingUser.Visible != false)
        {
            UserID = ddlAccountingUser.SelectedValue;
            if (ddlUserTypeID.SelectedValue == "2" || ddlUserTypeID.SelectedValue == "3")
            {
                UserName =  ddlAccountingUser.SelectedItem.Text;
            }
            else
            {
                UserName = "(" + ddlAccountingUser.SelectedValue + ") " + ddlAccountingUser.SelectedItem.Text;
            }
            
        }
        else
        {
            STD_Student student=STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text);
            UserID = student.StudentID;
            UserName = "(" + txtStudentCode.Text + ") " + student.StudentName;
        }

        if (IsNewCompany && txtNewCompany.Text!="")
        {
            ACC_AccountingUser aCC_AccountingUser = new ACC_AccountingUser();
            //	aCC_AccountingUser.AccountingUserID=  int.Parse(ddlAccountingUserID.SelectedValue);
            aCC_AccountingUser.AccountingUserName = txtNewCompany.Text;
            UserName = txtNewCompany.Text;
            aCC_AccountingUser.UserTypeID = int.Parse(ddlUserTypeID.SelectedValue);
            aCC_AccountingUser.AddedBy = Profile.card_id;
            aCC_AccountingUser.AddedDate = DateTime.Now;
            aCC_AccountingUser.UpdatedBy = Profile.card_id;
            aCC_AccountingUser.UpdateDate = DateTime.Now;
            aCC_AccountingUser.RowStatusID = 1;
            UserID = ACC_AccountingUserManager.InsertACC_AccountingUser(aCC_AccountingUser).ToString();
        }

        int HeadID = 0;
        string headName = "";
        if (ddlAccountID.SelectedValue != "0")
        {
            DataSet dsHeadUser = ACC_HeadUserManager.GetACC_UserByUserIDnUserTypeIDnAccountID(UserID, int.Parse(ddlUserTypeID.SelectedValue), int.Parse(ddlAccountID.SelectedValue));

            if (dsHeadUser.Tables[0].Rows.Count == 0)
            {
                //need to create the dead for this user
                ACC_Head aCC_Head = new ACC_Head();
                //	aCC_Head.HeadID=  int.Parse(ddlHeadID.SelectedValue);
                aCC_Head.HeadName = ddlAccountID.SelectedItem.Text+" "  + UserName;
                headName = aCC_Head.HeadName;
                aCC_Head.HeadCode = ""; //code need to generate automatically
                aCC_Head.AccountID = int.Parse(ddlAccountID.SelectedValue);
                aCC_Head.AddedBy = Profile.card_id;
                aCC_Head.AddedDate = DateTime.Now;
                aCC_Head.UpdatedBy = Profile.card_id;
                aCC_Head.UpdateDate = DateTime.Now;
                aCC_Head.RowStatusID = 1;
                HeadID = ACC_HeadManager.InsertACC_Head(aCC_Head);

                //add in the head user
                ACC_HeadUser aCC_HeadUser = new ACC_HeadUser();
                //	aCC_HeadUser.HeadUserID=  int.Parse(ddlHeadUserID.SelectedValue);
                aCC_HeadUser.HeadUserName = "";
                aCC_HeadUser.HeadID = HeadID;
                aCC_HeadUser.UserID = UserID;
                aCC_HeadUser.UserTypeID = int.Parse(ddlUserTypeID.SelectedValue);
                aCC_HeadUser.AddedBy = Profile.card_id;
                aCC_HeadUser.AddedDate = DateTime.Now;
                aCC_HeadUser.UpdatedBy = Profile.card_id;
                aCC_HeadUser.UpdateDate = DateTime.Now;
                aCC_HeadUser.RowStatusID = 1;
                ACC_HeadUserManager.InsertACC_HeadUser(aCC_HeadUser);
            }
            else
            {
                HeadID = int.Parse(dsHeadUser.Tables[0].Rows[0]["HeadID"].ToString());
                headName = dsHeadUser.Tables[0].Rows[0]["HeadName"].ToString();
            }
        }
        else 
        {
            return;
        }

        hfHeadID.Value = HeadID.ToString();
        lblHeadName.Text = headName;
    }
    private void getHeadMoney(bool IsNewCompany)
    {
        if (ddlAccountForMoney.SelectedValue == "0") return;
        if (ddlUserTypeIDMoney.SelectedValue == "0") return;
        if (ddlAccountingUserMoney.SelectedValue == "0") return;
        string UserID = "";
        string UserName = "";
        if (ddlAccountingUserMoney.Visible != false)
        {
            UserID = ddlAccountingUserMoney.SelectedValue;
            if (ddlUserTypeID.SelectedValue == "2" || ddlUserTypeID.SelectedValue == "3")
            {
                UserName = ddlAccountingUserMoney.SelectedItem.Text;
            }
            else
            {
                UserName = "(" + ddlAccountingUserMoney.SelectedValue + ") " + ddlAccountingUserMoney.SelectedItem.Text;
            }
        }
        else
        {

            STD_Student student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCodeMoney.Text);
            UserID = student.StudentID;
            UserName = "(" + txtStudentCodeMoney.Text + ") " + student.StudentName;
        }


        

        if (IsNewCompany)
        {
            ACC_AccountingUser aCC_AccountingUser = new ACC_AccountingUser();
            //	aCC_AccountingUser.AccountingUserID=  int.Parse(ddlAccountingUserID.SelectedValue);
            aCC_AccountingUser.AccountingUserName = txtNewCompanyMoney.Text;
            UserName = txtNewCompanyMoney.Text;
            aCC_AccountingUser.UserTypeID = int.Parse(ddlUserTypeIDMoney.SelectedValue);
            aCC_AccountingUser.AddedBy = Profile.card_id;
            aCC_AccountingUser.AddedDate = DateTime.Now;
            aCC_AccountingUser.UpdatedBy = Profile.card_id;
            aCC_AccountingUser.UpdateDate = DateTime.Now;
            aCC_AccountingUser.RowStatusID = 1;
            UserID = ACC_AccountingUserManager.InsertACC_AccountingUser(aCC_AccountingUser).ToString();
        }
        int HeadID = 0;
        string headNameMoney = "";
            

        if (ddlAccountID.SelectedValue != "0")
        {
            DataSet dsHeadUser = ACC_HeadUserManager.GetACC_UserByUserIDnUserTypeIDnAccountID(UserID, int.Parse(ddlUserTypeIDMoney.SelectedValue), int.Parse(ddlAccountForMoney.SelectedValue));
            if (dsHeadUser.Tables[0].Rows.Count == 0)
            {
                //need to create the dead for this user
                ACC_Head aCC_Head = new ACC_Head();
                //	aCC_Head.HeadID=  int.Parse(ddlHeadID.SelectedValue);
                aCC_Head.HeadName = ddlAccountForMoney.SelectedItem.Text +" " +UserName;
                headNameMoney = aCC_Head.HeadName;
                aCC_Head.HeadCode = ""; //code need to generate automatically
                aCC_Head.AccountID = int.Parse(ddlAccountForMoney.SelectedValue);
                aCC_Head.AddedBy = Profile.card_id;
                aCC_Head.AddedDate = DateTime.Now;
                aCC_Head.UpdatedBy = Profile.card_id;
                aCC_Head.UpdateDate = DateTime.Now;
                aCC_Head.RowStatusID = 1;
                HeadID = ACC_HeadManager.InsertACC_Head(aCC_Head);

                //add in the head user
                ACC_HeadUser aCC_HeadUser = new ACC_HeadUser();
                //	aCC_HeadUser.HeadUserID=  int.Parse(ddlHeadUserID.SelectedValue);
                aCC_HeadUser.HeadUserName = "";
                aCC_HeadUser.HeadID = HeadID;
                aCC_HeadUser.UserID = UserID;
                aCC_HeadUser.UserTypeID = int.Parse(ddlUserTypeIDMoney.SelectedValue);
                aCC_HeadUser.AddedBy = Profile.card_id;
                aCC_HeadUser.AddedDate = DateTime.Now;
                aCC_HeadUser.UpdatedBy = Profile.card_id;
                aCC_HeadUser.UpdateDate = DateTime.Now;
                aCC_HeadUser.RowStatusID = 1;
                ACC_HeadUserManager.InsertACC_HeadUser(aCC_HeadUser);
            }
            else
            {
                HeadID = int.Parse(dsHeadUser.Tables[0].Rows[0]["HeadID"].ToString());
                headNameMoney = dsHeadUser.Tables[0].Rows[0]["HeadName"].ToString();
            }
        }
        else
        {
            return;
        }
        hfHeadIDMoney.Value = HeadID.ToString();
        lblHeadNameMoney.Text = headNameMoney;
    }
    private void loadJournal()
    {
        List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
        doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];

        gvACC_Journal.DataSource = doubleEntry;
        gvACC_Journal.DataBind();
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        //ACC_JournalManager.LoadACC_JournalPage(gvACC_Journal, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        //ACC_JournalManager.LoadACC_JournalPage(gvACC_Journal, rptPager, pageIndex, ddlPageSize);
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminACC_Journal.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = ACC_JournalManager.DeleteACC_Journal(Convert.ToInt32(linkButton.CommandArgument));
        //ACC_JournalManager.LoadACC_JournalPage(gvACC_Journal, rptPager, 1, ddlPageSize);
    }
    protected void btnMoney_Click(object sender, EventArgs e)
    {
        if (ddlAccountForMoney.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Please select the Account for Money entry.')", true);
            return;
        }
        try
        {

            
            List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
            if (Session["doubleEntry"] != null)
            {
                doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];
            }
            int journalID = 0;
            journalID = doubleEntry.Count;


            List<ACC_Check> checks = new List<ACC_Check>();
            if (Session["checks"] != null)
            {
                checks = (List<ACC_Check>)Session["checks"];
            }
            if (ddlAccountForMoney.SelectedValue == "42")
            {
                //If check info is given then we need to save that check
                ACC_Check aCC_Check = new ACC_Check();
                aCC_Check.CheckID = checks.Count;
                aCC_Check.CheckNo = txtCheckNo.Text;
                aCC_Check.BankAccountNo = txtAccountNo.Text;
                aCC_Check.BankID = int.Parse(ddlBank.SelectedValue);
                aCC_Check.BranchNOtherDetails = txtBranchInfo.Text;
                aCC_Check.Remarks = txtAmountMoney.Text; ;
                aCC_Check.IsCashCheck = chkCashCheck.Checked;
                aCC_Check.ExtraField1 = !chkCashCheck.Checked ? ddlBankAccountID.SelectedValue : "";
                aCC_Check.ExtraField2 = hfHeadIDMoney.Value;
                aCC_Check.ExtraField3 = "";
                aCC_Check.ExtraField4 = ddlCheckFrom.SelectedValue;
                aCC_Check.ExtraField5 = txtCheckDate.Text;
                aCC_Check.AddedBy = Profile.card_id;
                aCC_Check.AddedDate = DateTime.Now;
                aCC_Check.UpdatedBy = Profile.card_id;
                aCC_Check.UpdateDate = DateTime.Now;
                aCC_Check.RowStatusID = 1;//temporary we are using this to keep info about the 
                checks.Add(aCC_Check);
                Session["checks"] = checks;
                //hfcheckIDs.Value += ACC_CheckManager.InsertACC_Check(aCC_Check).ToString()+",";
            }


            List<ACC_CUCCheck> aCC_CUCCheckList = new List<ACC_CUCCheck>();
            if (Session["cucCheck"] != null)
            {
                aCC_CUCCheckList = (List<ACC_CUCCheck>)Session["cucCheck"];
            }
            if (ddlAccountForMoney.SelectedValue == "2" )
            {
                ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck();
                //	aCC_CUCCheck.CUCCheckID=  int.Parse(ddlCUCCheckID.SelectedValue);
                aCC_CUCCheck.CUCCheckName = ddlAccountingUserMoney.SelectedItem.Text;
                aCC_CUCCheck.CUCCheckNo = ddlAccountingUserMoney.SelectedItem.Text;
                aCC_CUCCheck.BankAccountID = int.Parse(ddlAccountingUserMoney.SelectedValue);
                aCC_CUCCheck.CheckDate = DateTime.Parse(txtCUCCheckDate.Text);
                aCC_CUCCheck.PaytoHeadID = int.Parse(hfHeadIDMoney.Value);
                aCC_CUCCheck.JournalID = journalID;
                aCC_CUCCheck.Amount = decimal.Parse(txtAmountMoney.Text);
                aCC_CUCCheck.ExtraField1 = "";
                aCC_CUCCheck.ExtraField2 = "";
                aCC_CUCCheck.ExtraField3 = "";
                aCC_CUCCheck.ExtraField4 = "";
                aCC_CUCCheck.ExtraField5 = "";
                aCC_CUCCheck.AddedBy = Profile.card_id;
                aCC_CUCCheck.AddedDate = DateTime.Now;
                aCC_CUCCheck.UpdatedBy = Profile.card_id;
                aCC_CUCCheck.UpdatedDate = DateTime.Now;
                aCC_CUCCheck.RowStatusID = 1;//Temporary Inserted In DB
                //hfCUCCheck.Value = ACC_CUCCheckManager.InsertACC_CUCCheck(aCC_CUCCheck).ToString();
                aCC_CUCCheckList.Add(aCC_CUCCheck);
                Session["cucCheck"] = aCC_CUCCheckList;
            }

            if (txtStudentCodeMoney.Visible != false)
            {
                if (IsUser(txtStudentCodeMoney.Text))
                {
                    ACC_Journal aCC_Journal = new ACC_Journal();
                    aCC_Journal.JournalID = doubleEntry.Count;
                    
                    aCC_Journal.HeadID = int.Parse(hfHeadIDMoney.Value);
                    aCC_Journal.HeadName = lblHeadNameMoney.Text;
                    aCC_Journal.Debit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Cr" ? txtAmountMoney.Text : "0");
                    aCC_Journal.Credit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Dr" ? txtAmountMoney.Text : "0");
                    aCC_Journal.JournalMasterID = int.Parse("1");
                    aCC_Journal.JournalVoucherNo = ddlAccountForMoney.SelectedValue == "42" ? txtCheckNo.Text : "";
                    aCC_Journal.UserID = txtStudentCodeMoney.Text;
                    aCC_Journal.AccountID = int.Parse(ddlAccountForMoney.SelectedValue);
                    aCC_Journal.UserTypeID = int.Parse(ddlUserTypeIDMoney.SelectedValue);
                    aCC_Journal.AddedBy = Profile.card_id;
                    aCC_Journal.AddedDate = DateTime.Now;
                    aCC_Journal.UpdatedBy = Profile.card_id;
                    aCC_Journal.UpdateDate = DateTime.Now;
                    aCC_Journal.RowStatusID = 1;
                    aCC_Journal.IsNotCheck = ddlAccountForMoney.SelectedValue == "42" ? false : true;
                    doubleEntry.Add(aCC_Journal);
                    Session["doubleEntry"] = doubleEntry;
                    loadJournal();

                    loadSubmitButton();
                }
                else
                {
                    lblUserMoney.Text = "User is not exist";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('User is not exist')", true);
                }
            }
            else
            {

                ACC_Journal aCC_Journal = new ACC_Journal();
                aCC_Journal.JournalID = doubleEntry.Count;
                aCC_Journal.HeadID = int.Parse(hfHeadIDMoney.Value);
                aCC_Journal.HeadName = lblHeadNameMoney.Text;
                aCC_Journal.Debit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Cr" ? txtAmountMoney.Text : "0");
                aCC_Journal.Credit = decimal.Parse(ddlDebitOrCredit.SelectedValue == "Dr" ? txtAmountMoney.Text : "0");
                aCC_Journal.JournalMasterID = int.Parse("1");
                aCC_Journal.JournalVoucherNo = ddlAccountForMoney.SelectedValue == "42" ? txtCheckNo.Text : "";//temporay we are using to manage the check #
                aCC_Journal.UserID = ddlAccountingUserMoney.SelectedValue;
                aCC_Journal.AccountID = int.Parse(ddlAccountForMoney.SelectedValue);
                aCC_Journal.UserTypeID = int.Parse(ddlUserTypeIDMoney.SelectedValue);
                aCC_Journal.AddedBy = Profile.card_id;
                aCC_Journal.AddedDate = DateTime.Now;
                aCC_Journal.UpdatedBy = Profile.card_id;
                aCC_Journal.UpdateDate = DateTime.Now;
                aCC_Journal.RowStatusID = 1;
                aCC_Journal.IsNotCheck = ddlAccountForMoney.SelectedValue == "42" ? false : true;

                doubleEntry.Add(aCC_Journal);
                Session["doubleEntry"] = doubleEntry;
                loadJournal();

                loadSubmitButton();
            }

            ClearAllControllMoney();
        }

        catch (Exception ex)
        {
        }


    }
    protected void ddlUserTypeIDMoney_SelectedIndexChanged(object sender, EventArgs e)
    {
        divNewCompanyMoney.Visible = false;
        //ibtnRefresh.Visible = false;
        ddlAccountingUserMoney.Items.Clear();
        if (ddlUserTypeIDMoney.SelectedIndex != 0)
        {
            switch (ddlUserTypeIDMoney.SelectedValue)
            {
                case "1":
                    {
                        txtStudentCodeMoney.Visible = true;
                        //txtStudentCodeMoney.Text = Request.QueryString["UserTypeIDMoney"];
                        ddlAccountingUserMoney.Visible = false;
                        btnMoneyVerify.Visible = true;
                    }
                    break;
                case "2":
                    {
                        txtStudentCodeMoney.Visible = false;
                        ddlAccountingUserMoney.Visible = true;
                        btnMoneyVerify.Visible = false;
                        //DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
                        //ddlAccountingUserMoney.DataValueField = "EmployeeID";
                        //ddlAccountingUserMoney.DataTextField = "EmployeeName";
                        //ddlAccountingUserMoney.DataSource = ds.Tables[0];
                        //ddlAccountingUserMoney.DataBind();
                        //ddlAccountingUserMoney.Items.Insert(0, new ListItem("Select >>", "0"));


                        DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();

                        ListItem li = new ListItem("Select Employee...", "0");
                        ddlAccountingUserMoney.Items.Add(li);
                        string selectedEmployee = "";
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (bool.Parse(dr["Flag"].ToString()) == true)
                            {
                                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeID"].ToString());
                                ddlAccountingUserMoney.Items.Add(item);
                            }
                        }

                        ddlAccountingUserMoney.SelectedValue = Profile.card_id;
                        ddlAccountingUserMoney_SelectedIndexChanged(this, new EventArgs());
                    }
                    break;
                case "3":
                    {
                        txtStudentCodeMoney.Visible = false;
                        ddlAccountingUserMoney.Visible = true;
                        btnMoneyVerify.Visible = false;
                        if (ddlBankAccountID.Items.Count == 0)
                        {
                            try
                            {
                                DataSet dsbank = ACC_BankAccountManager.GetDropDownListAllACC_BankAccount(); //3 for user type Bank
                                ddlAccountingUserMoney.Items.Clear();
                                foreach (DataRow dr in dsbank.Tables[0].Rows)
                                {
                                    ListItem litems = new ListItem("("+dr["BankAccountName"].ToString() + ") " + dr["AccountNo"].ToString(), dr["BankAcountID"].ToString());
                                    ddlAccountingUserMoney.Items.Add(litems);
                                }
                                ddlAccountingUserMoney.DataBind();
                                ddlAccountingUserMoney.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));
                            }
                            catch (Exception ex)
                            { }
                        }
                        else
                        {
                            ddlAccountingUserMoney.Items.Clear();
                            foreach (ListItem li in ddlBankAccountID.Items)
                            {
                                ddlAccountingUserMoney.Items.Add(li);
                            }
                            ddlAccountingUserMoney.DataBind();
                            //ddlAccountingUser.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));
                        }
                    }
                    break;
                case "4":
                    {
                        txtStudentCodeMoney.Visible = false;
                        ddlAccountingUserMoney.Visible = true;
                        btnMoneyVerify.Visible = false;
                        DataSet ds = ACC_AccountingUserManager.GetACC_UserTypeByUserTypeID(4, true);
                        ddlAccountingUserMoney.DataValueField = "AccountingUserID";
                        ddlAccountingUserMoney.DataTextField = "AccountingUserName";
                        ddlAccountingUserMoney.DataSource = ds.Tables[0];
                        ddlAccountingUserMoney.DataBind();
                        ddlAccountingUserMoney.Items.Insert(0, new ListItem("Select >>", "0"));
                        ddlAccountingUserMoney.Items.Insert(ddlAccountingUserMoney.Items.Count, new ListItem("New Company", "-1"));
                    }
                    break;
                case "5":
                    {
                        txtStudentCodeMoney.Visible = false;
                        ddlAccountingUserMoney.Visible = true;
                        btnMoneyVerify.Visible = false;
                        DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
                        ddlAccountingUserMoney.DataValueField = "CampusID";
                        ddlAccountingUserMoney.DataTextField = "CampusName";
                        ddlAccountingUserMoney.DataSource = ds.Tables[0];
                        ddlAccountingUserMoney.DataBind();
                        ddlAccountingUserMoney.Items.Insert(0, new ListItem("Select >>", "0"));
                    }
                    break;
                default:
                    break;
            }
        }
    }
    protected void ddlAccountingUserMoney_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAccountingUserMoney.SelectedItem.Text == "New Company")
        {
            divNewCompanyMoney.Visible = true;
            ibtnRefreshMoney.Visible = true;
        }
        else
        {
            divNewCompanyMoney.Visible = false;
            ibtnRefreshMoney.Visible = false;
            getHeadMoney(false);
        }
    }
    protected void ibtnRefreshMoney_Click(object sender, ImageClickEventArgs e)
    {
        getHeadMoney(true);
    }

    protected void lbSelectJournal_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);

        showACC_VoucherEntry(id);
    }

    protected void ddlAccountingUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAccountingUser.SelectedItem.Text == "New Company")
        {
            divNewCompany.Visible = true;
            txtNewCompany.Visible = true;
            ibtnRefresh.Visible = true;
        }
        else
        {
            divNewCompany.Visible = false;
            txtNewCompany.Visible = false;
            ibtnRefresh.Visible = false;
            getHead(false);
        }
    }

    private void showACC_VoucherEntry(int journalID)
    {
        List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
        if (Session["doubleEntry"] != null)
        {
            doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];
        }

        ACC_Journal aCC_Journal = new ACC_Journal();

        aCC_Journal = doubleEntry[journalID];

        if (aCC_Journal.Debit == decimal.Parse("0") && Request.QueryString["DrOrCr"] == "Cr")
        {
            //Voucher
            hfIsMoney.Value = "0";
            lblHeadName.Text = aCC_Journal.HeadName.ToString();
            txtAmount.Text = aCC_Journal.Credit.ToString();
            ddlAccountID.SelectedValue = aCC_Journal.AccountID.ToString();
            ddlUserTypeID.SelectedValue = aCC_Journal.UserTypeID.ToString();
            ddlUserTypeID_SelectedIndexChanged(this, new EventArgs());
            ddlAccountingUser.SelectedValue = aCC_Journal.UserID;
            ddlAccountingUser_SelectedIndexChanged(this, new EventArgs());

            hfHeadID.Value = aCC_Journal.HeadID.ToString();
            hfJournalID.Value = journalID.ToString();
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
        }
        else
        {
            //money
            hfIsMoney.Value = "1";
            lblHeadNameMoney.Text = aCC_Journal.HeadName.ToString();
            txtAmountMoney.Text = aCC_Journal.Debit.ToString();
            ddlAccountForMoney.SelectedValue = aCC_Journal.AccountID.ToString();
            ddlUserTypeIDMoney.SelectedValue = aCC_Journal.UserTypeID.ToString();
            ddlUserTypeIDMoney_SelectedIndexChanged(this, new EventArgs());
            ddlAccountingUserMoney.SelectedValue = aCC_Journal.UserID;
            ddlAccountingUserMoney_SelectedIndexChanged(this, new EventArgs());

            hfHeadID.Value = aCC_Journal.HeadID.ToString();
            hfJournalID.Value = journalID.ToString();

            btnMoneyAdd.Visible = false;
            btnMoneyUpdate.Visible = true;
        }
    }


    protected void lbDeleteJournal_Click(object sender, EventArgs e)
    {
        try
        {
            List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
            doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];


            List<ACC_Check> checks = new List<ACC_Check>();
            checks = (List<ACC_Check>)Session["checks"];


            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;

            //very creafully need to implement
            //remove the check info form this 

            if (checks != null)
            {
                foreach (ACC_Check check in checks)
                {
                    if (check.ExtraField2 == doubleEntry[Convert.ToInt32(linkButton.CommandArgument)].HeadID.ToString())
                    {
                        checks.Remove(check);
                    }
                }
                Session["checks"] = checks;
            }


            if (doubleEntry != null)
            {

                doubleEntry.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));
                for (int i = 0; i < doubleEntry.Count; i++)
                {
                    doubleEntry[i].JournalID = i;
                }

                Session["doubleEntry"] = doubleEntry;
            }

            loadJournal();
            loadSubmitButton();

        }
        catch (Exception ex)
        { }
    }
    protected void btnJournalEntry_Click(object sender, EventArgs e)
    {
        int fulltimesalryJournalID = 0;
        int FeesMasterJournalID = 0;

        List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
        doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];
        
        List<ACC_Check> checks = new List<ACC_Check>();
        if (Session["checks"] != null) checks = (List<ACC_Check>)Session["checks"];

        List<ACC_CUCCheck> cucChecks = new List<ACC_CUCCheck>();
        if (Session["cucCheck"] != null) cucChecks = (List<ACC_CUCCheck>)Session["cucCheck"];

        ACC_JournalMaster aCC_JournalMaster = new ACC_JournalMaster();
        aCC_JournalMaster.JournalMasterName = "";
        aCC_JournalMaster.AddedBy = Profile.card_id;
        aCC_JournalMaster.AddedDate = DateTime.Now;
        aCC_JournalMaster.UpdatedBy = Profile.card_id;
        aCC_JournalMaster.UpdateDate = DateTime.Now;
        aCC_JournalMaster.RowStatusID = 1;
        aCC_JournalMaster.JournalMasterID = ACC_JournalMasterManager.InsertACC_JournalMaster(aCC_JournalMaster);

        if (doubleEntry != null)
        {
            foreach (ACC_Journal eachJournal in doubleEntry)
            {
                int temp = eachJournal.HeadID;
                string checkno = eachJournal.JournalVoucherNo;
                
                eachJournal.JournalVoucherNo = Request.QueryString["IsAdmissionFees"] != null ? Request.QueryString["IsAdmissionFees"] : "";
                eachJournal.JournalMasterID = aCC_JournalMaster.JournalMasterID;
                eachJournal.JournalID = ACC_JournalManager.InsertACC_Journal(eachJournal);

                if (eachJournal.AccountID == 17)//fulltime salary
                {
                    fulltimesalryJournalID = eachJournal.JournalID;
                }

                 if (eachJournal.SubBasicAccountID == 20)//student Fees
                {
                    FeesMasterJournalID = eachJournal.JournalID;
                }

                if (checkno != "")
                {
                    foreach (ACC_Check check in checks)
                    {
                        if (checkno == check.CheckNo)
                        {
                            //teamporary we have used the login that
                            //we will keep in the JournalVoucherNo the checkno 
                            //then
                            //in the insert script we will update the JournalVoucherNo with the CheckID

                            check.ExtraField3 = eachJournal.JournalID.ToString();
                            ACC_CheckManager.InsertACC_Check(check);
                        }
                    }
                }
                else
                {
                    foreach (ACC_CUCCheck cucCheck in cucChecks)
                    {
                        if (temp == cucCheck.PaytoHeadID)
                        {
                            //cucCheck.PaytoHeadID = eachJournal.JournalID;
                            cucCheck.JournalID = eachJournal.JournalID;
                            ACC_CUCCheckManager.InsertACC_CUCCheck(cucCheck);
                        }
                    }
                }

            }
        }
        if (Session["cucCheck"] != null) Session.Remove("cucCheck");
        if (Session["doubleEntry"] != null) Session.Remove("doubleEntry");
        if (Session["checks"] != null) Session.Remove("checks");
        
        try
        {
            if (Request.QueryString["CheckID"] != null)
            {
                ACC_Check aCC_Check = new ACC_Check();
                aCC_Check = ACC_CheckManager.GetACC_CheckByCheckID(int.Parse(Request.QueryString["CheckID"]));
                aCC_Check.UpdatedBy = Profile.card_id;
                aCC_Check.UpdateDate = DateTime.Now;
                aCC_Check.RowStatusID = 11;
                bool resutl = ACC_CheckManager.UpdateACC_Check(aCC_Check);
            }
        }
        catch (Exception ex)
        {
           
        }


        try
        {
            if (Request.QueryString["EmployPayRoleSalaryID"] != null)
            {
                ACC_EmployPayRoleSalary employPayroleSalary = new ACC_EmployPayRoleSalary();
                
                if (Session["employPayRoleSalary"] != null)
                {
                    employPayroleSalary = (ACC_EmployPayRoleSalary)Session["employPayRoleSalary"];
                    employPayroleSalary.ExtraField6 += ", " + aCC_JournalMaster.JournalMasterID.ToString();
                    employPayroleSalary.ExtraField7 = fulltimesalryJournalID.ToString();
                }
                Session.Remove("employPayRoleSalary");

                bool result = ACC_EmployPayRoleSalaryManager.UpdateEmployPayRoleSalary(employPayroleSalary);
            }
        }
        catch (Exception ex)
        { }

        
        try
        {
            if (Request.QueryString["FeesID"] != null)
            {
                STD_Fees sTD_FeesUpdate = new STD_Fees();

                sTD_FeesUpdate = STD_FeesManager.GetSTD_FeesByFeesID(int.Parse(Request.QueryString["FeesID"]));
                sTD_FeesUpdate.IsPaid = true;
                sTD_FeesUpdate.SubmitedDate = DateTime.Today.ToString();
                sTD_FeesUpdate.UpdatedBy = Profile.card_id;
                sTD_FeesUpdate.UpdateDate = DateTime.Now;
                sTD_FeesUpdate.RowStatusID = int.Parse("1");
                sTD_FeesUpdate.Remarks = Request.QueryString["Remarks"];
                bool resutl = STD_FeesManager.UpdateSTD_Fees(sTD_FeesUpdate);

                STD_FeesMaster feesMaster = new STD_FeesMaster();
                feesMaster = STD_FeesMasterManager.GetSTD_FeesMasterByFeesMasterID(int.Parse(sTD_FeesUpdate.FeesName));

                feesMaster.ExtraField1 = (decimal.Parse(feesMaster.ExtraField1) + sTD_FeesUpdate.Amount).ToString();//total paid Amount
                feesMaster.ExtraField1 = (decimal.Parse(feesMaster.ExtraField2) - sTD_FeesUpdate.Amount).ToString();//total unpaid Amount

                resutl = STD_FeesMasterManager.UpdateSTD_FeesMaster(feesMaster);
            }
        }
        catch (Exception ex)
        { }
        STD_FeesMaster feesMasterTemp = new STD_FeesMaster();
        try
        {
            if (Request.QueryString["newFeesID"] != null)
            {
                if (Session["feesListUpdate"] != null)
                {
                    List<STD_Fees> feesListUpdate = new List<STD_Fees>();
                    feesListUpdate = (List<STD_Fees>)Session["feesListUpdate"];

                    foreach (STD_Fees item in feesListUpdate)
                    {
                        item.IsPaid = true;
                        STD_FeesManager.UpdateSTD_Fees(item);
                    }
                    Session.Remove("feesListUpdate");
                }
                if (Session["feesMaster"] != null)
                {
                    feesMasterTemp = (STD_FeesMaster)Session["feesMaster"];
                    feesMasterTemp.ExtraField4 = FeesMasterJournalID.ToString();
                    STD_FeesMasterManager.UpdateSTD_FeesMaster(feesMasterTemp);
                    Session.Remove("feesMaster");
                }

                if (Request.QueryString["newFeesID"] != "0")
                {
                    STD_Fees sTD_FeesUpdate = new STD_Fees();

                    sTD_FeesUpdate = STD_FeesManager.GetSTD_FeesByFeesID(int.Parse(Request.QueryString["newFeesID"]));
                    sTD_FeesUpdate.RowStatusID = int.Parse("1");
                    bool resutl = STD_FeesManager.UpdateSTD_Fees(sTD_FeesUpdate);
                }

               
            }
        }
        catch (Exception ex)
        { }

        if (Request.QueryString["Refund"] != null)
        {
            if (STD_FeesMasterManager.RefundSTD_FeesMaster(hfStudentID.Value))
            {
                lblMessage.Text += "Student Refund Successfull<br/>";
            }
        }

        lblMessage.Text += "Journal Entry Successful. <a href='VoucherPage.aspx?JournalMasterID=" + aCC_JournalMaster.JournalMasterID.ToString() + "&EmployeeID=" + ddlAccountingUserMoney.SelectedValue + "&Amount=" + lblDebit.Text + "' target='_blank'>Click here to Print</a>";
        if (Request.QueryString["AccountID"] != null)
        {
            //if (int.Parse(Request.QueryString["AccountID"]) >= 29 && int.Parse(Request.QueryString["AccountID"]) <= 37)
            if (int.Parse(Request.QueryString["SubBasicAccountID"]) ==20)
            {
                lblMessage.Text += "</br><a  target='_blank' href='FeesInstallment.aspx?StudentCode=" + Request.QueryString["StudentCode"] + "'>Back to Student Fees Search page</a></br><a href='MoneyReceipt.aspx?StudentID=" + hfStudentID.Value + "&Amount=" + lblDebit.Text + "&Remark=" + (chkAddInMoneyReceipt.Checked ? txtRemarks.Text : "") + "&FeesMasterID=" + feesMasterTemp.FeesMasterID.ToString() + "&JournalMasterID=" + aCC_JournalMaster.JournalMasterID.ToString() + "&IsAdmissionFees=" + Request.QueryString["IsAdmissionFees"] + "' target='_blank'>Click here to Print the receipt</a>";
                //lblMessage.Text += "</br><a  target='_blank' href='FeesInstallment.aspx?StudentCode=" + Request.QueryString["StudentCode"] + "'>Back to Student Fees Search page</a></br><a href='../Accounting/MoneyReceipt.aspx?StudentID=" + hfStudentID.Value + "&Amount=" + lblDebit.Text + "&Remark=" + Request.QueryString["Remark"] + "&FeesMasterID=" + feesMasterTemp.FeesMasterID.ToString() + "&JournalMasterID=" + aCC_JournalMaster.JournalMasterID.ToString() + "' target='_blank'>Click here to Print the receipt</a>";
            }
            else
                if (int.Parse(Request.QueryString["AccountID"]) >= 17 && int.Parse(Request.QueryString["AccountID"]) <= 19)
                {
                    lblMessage.Text += "</br><a  target='_blank' href='AccountEmployPayRoleSalary.aspx?EmployeeID=" + Request.QueryString["EmployeeID"] + "'>Back to Sallary posting page</a></br><a href='VoucherPage.aspx?JournalMasterID=" + aCC_JournalMaster.JournalMasterID.ToString() + "&EmployeeID=" + ddlAccountingUser.SelectedValue + "&Amount=" + lblDebit.Text + "&Payto=" + ddlAccountingUser.SelectedItem.Text + "&Purpose=" + Request.QueryString["Purpose"] + "' target='_blank'>Click here to Print the receipt</a>";
                }
        }

        lblMessage.ForeColor = System.Drawing.Color.Green;

        btnJournalEntry.Visible = false;
    }

    //private string processRemarks()
    //{
    //    string remarks = " ";

    //    remarks = (chkFA1.Checked ? ", FA1" : "")
    //        + (chkFA2.Checked ? ", FA2" : "")
    //        + (chkMA1.Checked ? ", MA1" : "")
    //        + (chkMA2.Checked ? ", MA2" : "")
    //        + (chkFAB.Checked ? ", FAB" : "")
    //        + (chkFFA.Checked ? ", FFA" : "")
    //        + (chkFMA.Checked ? ", FMA" : "")
    //        + (chkFAU.Checked ? ", FAU" : "")
    //        + (chkFTX.Checked ? ", FTX" : "")
    //        + (chkFFM.Checked ? ", FFM" : "");

    //    return remarks==" "?"":remarks.Substring(1,remarks.Length-1);
    //}

    protected void txtStudentCode_OnTextChanged(object sender, EventArgs e)
    {
        btnVarify_OnClick(this, new EventArgs());
        //getHead(false);
    }

    protected void txtStudentCodeMoney_OnTextChanged(object sender, EventArgs e)
    {
        getHeadMoney(false);
    }

    protected void btnVarify_OnClick(object sender, EventArgs e)
    {
        STD_Student student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCode.Text);


        if (student != null)
        {
            lblUser.Text = "User is Exist";
            pnStudentDetails.Visible = true;
            lblName.Text = student.StudentName;
            lblContact.Text = student.Mobile;
            imgStudent.ImageUrl = student.PPSizePhoto;
            hfStudentID.Value = student.StudentID;
            getHead(false);

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is Exist')", true);

        }
        else
        {
            lblUser.Text = "User is not exist";
            pnStudentDetails.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is not Exist')", true);
        }
    }
    protected void btnMoneyVerify_OnClick(object sender, EventArgs e)
    {
        STD_Student student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCodeMoney.Text);

        if (student != null)
        {
            lblUserMoney.Text = "User is Exist";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is Exist')", true);
        }
        else
        {
            lblUserMoney.Text = "User is not exist";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is not Exist')", true);
        }

    }
    protected void ddlDrCrOtherTransaction_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDrCrOtherTransaction.SelectedValue == "Cr")
        {
            ddlDebitOrCredit.SelectedValue = "Cr";
            ddlDebitOrCreditMoney.SelectedValue = "Dr";
        }
        else
        {
            ddlDebitOrCredit.SelectedValue = "Dr";
            ddlDebitOrCreditMoney.SelectedValue = "Cr";
        }
    }
}

