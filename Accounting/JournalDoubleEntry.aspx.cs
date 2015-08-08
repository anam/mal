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
    public static List<ACC_Journal> doubleEntry = new List<ACC_Journal>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doubleEntry.Clear();
            UserTypeIDLoad();
            AccountIDLoad();

            if (Request.QueryString["AccountID"] != null)
            {
                ddlAccountID.SelectedValue = Request.QueryString["AccountID"];
            }

            if (Request.QueryString["UserTypeID"] != null)
            {
                ddlUserTypeID.SelectedValue = Request.QueryString["UserTypeID"];
                ddlUserTypeID_SelectedIndexChanged(this, new EventArgs());

                if (Request.QueryString["EmployeeID"] != null)
                {
                    ddlAccountingUser.SelectedValue = Request.QueryString["EmployeeID"];
                    txtAmount.Text = Request.QueryString["Amount"];

                    txtStudentCode.Visible = false;

                    getHead(false);
                }

                ddlUserTypeIDMoney.SelectedValue = Request.QueryString["UserTypeID"];
                ddlUserTypeIDMoney_SelectedIndexChanged(this, new EventArgs());
            }


            if (Request.QueryString["StudentCode"] != null)
            {
                txtStudentCode.Visible = true;
                ddlAccountingUser.Visible = false;
                txtAmount.Text = Request.QueryString["Amount"];
                txtStudentCode.Text = Request.QueryString["StudentCode"];
                getHead(false);
            }
            if (Request.QueryString["UserTypeIDMoney"] != null)
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
                    //ddlAccountingUserMoney.SelectedValue = Request.QueryString["UserTypeIDMoney"];
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
                ds = ACC_AccountManager.GetACC_AccountBySubBasicAccountID(int.Parse(Request.QueryString["SubBasicAccountID"] == null ? "1" : Request.QueryString["SubBasicAccountID"]), true);
                ddlAccountID.DataValueField = "AccountID";
                ddlAccountID.DataTextField = "AccountName";
                ddlAccountID.DataSource = ds.Tables[0];
                ddlAccountID.DataBind();
                ddlAccountID.Items.Insert(0, new ListItem("Select Account >>", "0"));
            }

            ds = ACC_AccountManager.GetACC_AccountByBasicAccountID(1, true);
            ddlAccountForMoney.DataValueField = "AccountID";
            ddlAccountForMoney.DataTextField = "AccountName";
            ddlAccountForMoney.DataSource = ds.Tables[0];
            ddlAccountForMoney.DataBind();
            ddlAccountForMoney.Items.Insert(0, new ListItem("Select Account >>", "0"));
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
                    aCC_Journal.UserID = hfStudentID.Value;
                    aCC_Journal.AccountID = int.Parse(ddlAccountID.SelectedValue);
                    aCC_Journal.UserTypeID = int.Parse(ddlUserTypeID.SelectedValue);
                    aCC_Journal.AddedBy = Profile.card_id;
                    aCC_Journal.AddedDate = DateTime.Now;
                    aCC_Journal.UpdatedBy = Profile.card_id;
                    aCC_Journal.UpdateDate = DateTime.Now;
                    aCC_Journal.RowStatusID = 1;

                    doubleEntry.Add(aCC_Journal);

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

                doubleEntry.Add(aCC_Journal);

                loadJournal();
                loadSubmitButton();
            }
        }

        catch (Exception ex)
        {
        }
    }

    private void loadSubmitButton()
    {
        decimal debit = 0;
        decimal credit = 0;

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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //doubleEntry[int.Parse(hfJournalID.Value)].JournalID = doubleEntry.Count;
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
        txtNewCompany.Visible = false;
        //ibtnRefresh.Visible = false;
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
                        ddlAccountingUser.DataValueField = "EmployeeID";
                        ddlAccountingUser.DataTextField = "EmployeeName";
                        ddlAccountingUser.DataSource = ds.Tables[0];
                        ddlAccountingUser.DataBind();
                        ddlAccountingUser.Items.Insert(0, new ListItem("Select >>", "0"));
                    }
                    break;
                case "3":
                    {
                        txtStudentCode.Visible = false;
                        ddlAccountingUser.Visible = true;
                        btnVarify.Visible = false;
                        DataSet ds = ACC_AccountingUserManager.GetACC_UserTypeByUserTypeID(3, true);
                        ddlAccountingUser.DataValueField = "AccountingUserID";
                        ddlAccountingUser.DataTextField = "AccountingUserName";
                        ddlAccountingUser.DataSource = ds.Tables[0];
                        ddlAccountingUser.DataBind();
                        ddlAccountingUser.Items.Insert(0, new ListItem("Select >>", "0"));
                        ddlAccountingUser.Items.Insert(ddlAccountingUser.Items.Count, new ListItem("New Company", "-1"));
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
            UserName = ddlAccountingUser.SelectedItem.Text;
        }
        else
        {
            UserID = txtStudentCode.Text;
            UserName = txtStudentCode.Text;
        }

        if (IsNewCompany)
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
                    aCC_Head.HeadName = ddlAccountID.SelectedItem.Text + " --> " + UserName;
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
        hfHeadID.Value = HeadID.ToString();
        lblHeadName.Text = headName;
    }
    private void getHeadMoney(bool IsNewCompany)
    {
        string UserID = "";
        string UserName = "";
        if (ddlAccountingUserMoney.Visible != false)
        {
            UserID = ddlAccountingUserMoney.SelectedValue;
            UserName = ddlAccountingUserMoney.SelectedItem.Text;
        }
        else
        {
            UserID = txtStudentCodeMoney.Text;
            UserName = txtStudentCodeMoney.Text;
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

        DataSet dsHeadUser = ACC_HeadUserManager.GetACC_UserByUserIDnUserTypeIDnAccountID(UserID, int.Parse(ddlUserTypeIDMoney.SelectedValue), int.Parse(ddlAccountForMoney.SelectedValue));
        int HeadID = 0;
        string headNameMoney = "";
        if (dsHeadUser.Tables[0].Rows.Count == 0)
        {
            //need to create the dead for this user
            ACC_Head aCC_Head = new ACC_Head();
            //	aCC_Head.HeadID=  int.Parse(ddlHeadID.SelectedValue);
            aCC_Head.HeadName = ddlAccountForMoney.SelectedItem.Text + " --> " + UserName;
            headNameMoney = aCC_Head.HeadName;
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

        hfHeadIDMoney.Value = HeadID.ToString();
        lblHeadNameMoney.Text = headNameMoney;
    }
    private void loadJournal()
    {
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
        try
        {
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
                    aCC_Journal.JournalVoucherNo = "";
                    aCC_Journal.UserID = txtStudentCodeMoney.Text;
                    aCC_Journal.AccountID = int.Parse(ddlAccountForMoney.SelectedValue);
                    aCC_Journal.UserTypeID = int.Parse(ddlUserTypeIDMoney.SelectedValue);
                    aCC_Journal.AddedBy = Profile.card_id;
                    aCC_Journal.AddedDate = DateTime.Now;
                    aCC_Journal.UpdatedBy = Profile.card_id;
                    aCC_Journal.UpdateDate = DateTime.Now;
                    aCC_Journal.RowStatusID = 1;

                    doubleEntry.Add(aCC_Journal);

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
                aCC_Journal.JournalVoucherNo = "";
                aCC_Journal.UserID = ddlAccountingUserMoney.SelectedValue;
                aCC_Journal.AccountID = int.Parse(ddlAccountForMoney.SelectedValue);
                aCC_Journal.UserTypeID = int.Parse(ddlUserTypeIDMoney.SelectedValue);
                aCC_Journal.AddedBy = Profile.card_id;
                aCC_Journal.AddedDate = DateTime.Now;
                aCC_Journal.UpdatedBy = Profile.card_id;
                aCC_Journal.UpdateDate = DateTime.Now;
                aCC_Journal.RowStatusID = 1;

                doubleEntry.Add(aCC_Journal);

                loadJournal();

                loadSubmitButton();
            }
        }

        catch (Exception ex)
        {
        }


    }
    protected void ddlUserTypeIDMoney_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtNewCompanyMoney.Visible = false;
        //ibtnRefresh.Visible = false;
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
                        DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
                        ddlAccountingUserMoney.DataValueField = "EmployeeID";
                        ddlAccountingUserMoney.DataTextField = "EmployeeName";
                        ddlAccountingUserMoney.DataSource = ds.Tables[0];
                        ddlAccountingUserMoney.DataBind();
                        ddlAccountingUserMoney.Items.Insert(0, new ListItem("Select >>", "0"));
                    }
                    break;
                case "3":
                    {
                        txtStudentCodeMoney.Visible = false;
                        ddlAccountingUserMoney.Visible = true;
                        btnMoneyVerify.Visible = false;
                        DataSet ds = ACC_AccountingUserManager.GetACC_UserTypeByUserTypeID(3, true);
                        ddlAccountingUserMoney.DataValueField = "AccountingUserID";
                        ddlAccountingUserMoney.DataTextField = "AccountingUserName";
                        ddlAccountingUserMoney.DataSource = ds.Tables[0];
                        ddlAccountingUserMoney.DataBind();
                        ddlAccountingUserMoney.Items.Insert(0, new ListItem("Select >>", "0"));
                        ddlAccountingUserMoney.Items.Insert(ddlAccountingUserMoney.Items.Count, new ListItem("New Company", "-1"));
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
            txtNewCompanyMoney.Visible = true;
            ibtnRefreshMoney.Visible = true;
        }
        else
        {
            txtNewCompanyMoney.Visible = false;
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
            txtNewCompany.Visible = true;
            ibtnRefresh.Visible = true;
        }
        else
        {
            txtNewCompany.Visible = false;
            ibtnRefresh.Visible = false;
            getHead(false);
        }
    }

    private void showACC_VoucherEntry(int journalID)
    {
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
            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;

            doubleEntry.RemoveAt(Convert.ToInt32(linkButton.CommandArgument));
            for (int i = 0; i < doubleEntry.Count; i++)
            {
                doubleEntry[i].JournalID = i;
            }

            loadJournal();
        }
        catch (Exception ex)
        { }
    }
    protected void btnJournalEntry_Click(object sender, EventArgs e)
    {
        ACC_JournalMaster aCC_JournalMaster = new ACC_JournalMaster();
        aCC_JournalMaster.JournalMasterName = "";
        aCC_JournalMaster.AddedBy = Profile.card_id;
        aCC_JournalMaster.AddedDate = DateTime.Now;
        aCC_JournalMaster.UpdatedBy = Profile.card_id;
        aCC_JournalMaster.UpdateDate = DateTime.Now;
        aCC_JournalMaster.RowStatusID = 1;
        aCC_JournalMaster.JournalMasterID = ACC_JournalMasterManager.InsertACC_JournalMaster(aCC_JournalMaster);

        foreach (ACC_Journal eachJournal in doubleEntry)
        {
            eachJournal.JournalMasterID = aCC_JournalMaster.JournalMasterID;
            ACC_JournalManager.InsertACC_Journal(eachJournal);
        }

        lblMessage.Text = "Journal Entry Successful";
        if (Request.QueryString["AccountID"] != null)
        {
            if (int.Parse(Request.QueryString["AccountID"]) >= 29 && int.Parse(Request.QueryString["AccountID"]) <= 37)
            {
                lblMessage.Text += " <a href='../Accounting/MoneyReceipt.aspx?StudentID=" + hfStudentID.Value + "&Amount=" + lblDebit.Text + "' target='_blank'>Click here to Print the receipt</a>";
            }
            else
                if (int.Parse(Request.QueryString["AccountID"]) >= 17 && int.Parse(Request.QueryString["AccountID"]) <= 19)
                {
                    lblMessage.Text += " <a href='../Accounting/ViewTeacherMoneyReceit.aspx?EmployeeID=" + ddlAccountingUser.SelectedValue + "&Amount=" + lblDebit.Text + "' target='_blank'>Click here to Print the receipt</a>";
                }
        }
        lblMessage.ForeColor = System.Drawing.Color.Green;
    }
    protected void txtStudentCode_OnTextChanged(object sender, EventArgs e)
    {
        getHead(false);
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
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is Exist')", true);

        }
        else
        {
            lblUser.Text = "User is not exist";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Student Code is not Exist')", true);
        }
       
    }
    protected void btnMoneyVerify_OnClick(object sender, EventArgs e)
    {
        STD_Student student = STD_StudentManager.GetHR_StudnetByStudentCode(txtStudentCodeMoney.Text);
       
        if (student!=null)
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
}

