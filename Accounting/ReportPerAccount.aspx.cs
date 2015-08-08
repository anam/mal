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
     static decimal totalDebit = 0;
     static decimal totalCredit = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BasicAccountIDLoad();
            UserTypeIDLoad();
        }
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

    protected void ddlAccountingUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (ddlAccountingUser.SelectedItem.Text == "New Company")
        {
            txtNewCompany.Visible = true;
            ibtnRefresh.Visible = true;
        }
        else
        {
            txtNewCompany.Visible = false;
            ibtnRefresh.Visible = false;
            if (ddlAccountID.Items.Count != 0)
            {
                if (ddlAccountID.SelectedValue == "0")
                {
                    //lblMessage.Text = "Please select a specific Account";
                    //ddlAccountingUser.SelectedIndex = 0;
                    return;
                }
            }
            else
            {
                //ddlAccountingUser.SelectedIndex = 0;
                return; 
            }
            getHead(false);
        }
    }

    private void getHead(bool IsNewCompany)
    {
        try
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
                lblHeadName.Text = "Sorry this not the page to add new Entry";
            }

            DataSet dsHeadUser = ACC_HeadUserManager.GetACC_UserByUserIDnUserTypeIDnAccountID(UserID, int.Parse(ddlUserTypeID.SelectedValue), int.Parse(ddlAccountID.SelectedValue));
            int HeadID = 0;
            string headName = "";
            if (dsHeadUser.Tables[0].Rows.Count == 0)
            {
                lblHeadName.Text = "No transaction has done for this account before..";
                lblJournal.Visible = false;
                btnAdd.Visible = false;
                return;
            }
            else
            {
                //btnAdd.Visible = true;
                HeadID = int.Parse(dsHeadUser.Tables[0].Rows[0]["HeadID"].ToString());
                headName = dsHeadUser.Tables[0].Rows[0]["HeadName"].ToString();
            }

            hfHeadID.Value = HeadID.ToString();
            lblHeadID.Text = HeadID.ToString();
            lblHeadName.Text = headName;
        }
        catch (Exception ex)
        { }
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        getHead(true);
    }

    protected void txtStudentCode_OnTextChanged(object sender, EventArgs e)
    {
        getHead(false);
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

    private void UserTypeIDLoad()
    {
        try
        {
            DataSet ds = COMN_UserTypeManager.GetDropDownListAllCOMN_UserType();
            foreach (DataRow dr in ds.Tables[0].Rows)
	        {
                if (dr["UserTypeID"].ToString() == "1")
                {
                    dr.Delete();
                }
	
	        }
            ddlUserTypeID.DataValueField = "UserTypeID";
            ddlUserTypeID.DataTextField = "UserTypeName";
            ddlUserTypeID.DataSource = ds.Tables[0];
            ddlUserTypeID.DataBind();
            ddlUserTypeID.Items.Insert(0, new ListItem("Select UserType >>", "0"));

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void AccountIDLoad()
    {
        try
        {
            DataSet ds = ACC_AccountManager.GetACC_AccountBySubBasicAccountID(int.Parse( ddlSubBasicAccountID.SelectedValue),true);
            ddlAccountID.DataValueField = "AccountID";
            ddlAccountID.DataTextField = "AccountName";
            ddlAccountID.DataSource = ds.Tables[0];
            ddlAccountID.DataBind();
            ddlAccountID.Items.Insert(0, new ListItem("Select Account >>", "0"));

            hfHeadID.Value = "0";
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void ddlUserTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        hfHeadID.Value = "0";
        txtStudentCode.Visible = false;
        btnVarify.Visible = false;
        txtNewCompany.Visible = false;
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
                            ListItem item = new ListItem( dr["EmployeeNameNo"].ToString(), dr["EmployeeID"].ToString());
                            ddlAccountingUser.Items.Add(item);
                        }

                    }
                    break;
                case "3":
                    {
                        txtStudentCode.Visible = false;
                        ddlAccountingUser.Visible = true;
                        btnVarify.Visible = false;
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
  
    private bool IsUser(string user)
    {
        STD_Student student = STD_StudentManager.GetHR_StudnetByStudentCode(user);

        if (student != null)
        {
            return true;
        }
        return false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtStudentCode.Visible != false)
            {
                if (!IsUser(txtStudentCode.Text))
                {
                    lblUser.Text = "User is not exist";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('User is not exist')", true);
                }
            }
            else
            {
                
            }

            string dateFrom = "";
            try
            {
                dateFrom=(Convert.ToDateTime(txtDateFrom.Text)).ToShortDateString();
            }
            catch (Exception ex)
            {
            }
            string dateTo ="";
            try
            {
                dateTo = (Convert.ToDateTime(txtDateTo.Text).AddDays(1)).ToShortDateString();
            }
            catch (Exception ex)
            {
            }

            //if ((ddlAccountingUser.SelectedIndex == -1 && ddlUserTypeID.SelectedValue != "1") ||( txtStudentCode.Text =="" && ddlUserTypeID.SelectedValue == "1"))
            //{
            if (int.Parse(hfHeadID.Value) <= 0)
            {
                hfHeadID.Value = "-1";
            }
            //}

            DataSet dsJournal = new DataSet();// ACC_JournalManager.GetACC_JournalByHeadIDByAll(int.Parse(ddlBasicAccountID.SelectedValue), int.Parse(ddlSubBasicAccountID.Items.Count == 0 ? "0" : ddlSubBasicAccountID.SelectedValue), int.Parse(ddlAccountID.Items.Count == 0 ? "0" : ddlAccountID.SelectedValue), int.Parse(hfHeadID.Value), dateFrom, dateTo);
            //if (ddlBasicAccountID.SelectedValue == "0" )
            //{
            //    dsJournal = ACC_JournalManager.GetACC_JournalByHeadIDByAllByUserID(int.Parse(ddlBasicAccountID.SelectedValue), int.Parse(ddlSubBasicAccountID.Items.Count == 0 ? "0" : ddlSubBasicAccountID.SelectedValue), int.Parse(ddlAccountID.Items.Count == 0 ? "0" : ddlAccountID.SelectedValue), ddlAccountingUser.SelectedValue, int.Parse(ddlUserTypeID.SelectedValue), dateFrom, dateTo);
            //}
            //else
            //if (ddlAccountID.Items.Count > 0)
            //{
            //    if (ddlAccountID.SelectedValue != "0" || hfHeadID.Value == "-1")
            //    {
            //        dsJournal = ACC_JournalManager.GetACC_JournalByHeadIDByAll(int.Parse(ddlBasicAccountID.SelectedValue), int.Parse(ddlSubBasicAccountID.Items.Count == 0 ? "0" : ddlSubBasicAccountID.SelectedValue), int.Parse(ddlAccountID.Items.Count == 0 ? "0" : ddlAccountID.SelectedValue), int.Parse(hfHeadID.Value), dateFrom, dateTo);
            //    }
            //    else
            //    {
            //        dsJournal = ACC_JournalManager.GetACC_JournalByHeadIDByAllByUserID(int.Parse(ddlBasicAccountID.SelectedValue), int.Parse(ddlSubBasicAccountID.Items.Count == 0 ? "0" : ddlSubBasicAccountID.SelectedValue), int.Parse(ddlAccountID.Items.Count == 0 ? "0" : ddlAccountID.SelectedValue), ddlAccountingUser.SelectedValue, int.Parse(ddlUserTypeID.SelectedValue), dateFrom, dateTo);
            //    }
            //}
            //else
            //{
            //    if (hfHeadID.Value == "-1")
            //    {
                    
            //        if (ddlAccountingUser.Items.Count > 0)
            //        {
            //            if (ddlAccountingUser.SelectedValue != "0")
            //            {
            //                dsJournal = ACC_JournalManager.GetACC_JournalByHeadIDByAllByUserID(int.Parse(ddlBasicAccountID.SelectedValue), int.Parse(ddlSubBasicAccountID.Items.Count == 0 ? "0" : ddlSubBasicAccountID.SelectedValue), int.Parse(ddlAccountID.Items.Count == 0 ? "0" : ddlAccountID.SelectedValue), ddlAccountingUser.SelectedValue, int.Parse(ddlUserTypeID.SelectedValue), dateFrom, dateTo);
            //            }
            //            else
            //            {
            //                dsJournal = ACC_JournalManager.GetACC_JournalByHeadIDByAll(int.Parse(ddlBasicAccountID.SelectedValue), int.Parse(ddlSubBasicAccountID.Items.Count == 0 ? "0" : ddlSubBasicAccountID.SelectedValue), int.Parse(ddlAccountID.Items.Count == 0 ? "0" : ddlAccountID.SelectedValue), int.Parse(hfHeadID.Value), dateFrom, dateTo);
            //            }
            //        }
            //        else
            //        {
            //            dsJournal = ACC_JournalManager.GetACC_JournalByHeadIDByAll(int.Parse(ddlBasicAccountID.SelectedValue), int.Parse(ddlSubBasicAccountID.Items.Count == 0 ? "0" : ddlSubBasicAccountID.SelectedValue), int.Parse(ddlAccountID.Items.Count == 0 ? "0" : ddlAccountID.SelectedValue), int.Parse(hfHeadID.Value), dateFrom, dateTo);
            //        }
                    
            //    }
            //    else
            dsJournal = ACC_JournalManager.GetACC_JournalByHeadIDByAllByUserID(int.Parse(ddlBasicAccountID.SelectedValue), int.Parse(ddlSubBasicAccountID.Items.Count == 0 ? "0" : ddlSubBasicAccountID.SelectedValue), int.Parse(ddlAccountID.Items.Count == 0 ? "0" : ddlAccountID.SelectedValue), ddlAccountingUser.Items.Count == 0 ? "0" : ddlAccountingUser.SelectedValue, int.Parse(ddlUserTypeID.SelectedValue), dateFrom, dateTo);
            //}

            string html = "<table><tr style='font-weight:bold;'><td  style='background-color:#46BEDF;border:1px solid black;'>S. No.</td><td style='background-color:#46BEDF;border:1px solid black;'>Head Name</td><td style='background-color:#46BEDF;border:1px solid black;'>Date</td><td style='background-color:#46BEDF;border:1px solid black; width:70px;text-align:right;'>Debit</td><td style='background-color:#46BEDF;border:1px solid black;text-align:right; width:70px;'>Credit</td>";
            int serialNo = 1;
            decimal debit = 0;
            decimal credit = 0;

            foreach (DataRow dr in dsJournal.Tables[0].Rows)
            {
                html += "<tr " + (serialNo % 2 == 0 ? "style='background-color:#EBEAEA;'" : "" )+ ">";
                html += "<td style='border:1px solid black;text-align:right;padding-right:5px;'>" + serialNo++ + "</td>";
                html += "<td style='border:1px solid black;'>" + dr["HeadName"].ToString() + "</td>";
                html += "<td style='border:1px solid black;'>" + DateTime.Parse(dr["AddedDate"].ToString()).ToString("dd MMM yyyy") + "</td>";
                html += "<td style='border:1px solid black;text-align:right;'>" + decimal.Parse(dr["Debit"].ToString()).ToString("0,0.00") + "</td>";
                debit += decimal.Parse(dr["Debit"].ToString());
                credit += decimal.Parse(dr["Credit"].ToString());
                html += "<td style='border:1px solid black;text-align:right;'>" + decimal.Parse(dr["Credit"].ToString()).ToString("0,0.00") + "</td>";
                html += "</tr>";
            }


            html += "<tr><td></td><td></td><td>Total:</td><td style='text-align:right;border:1px solid black;'>" + debit.ToString("0,0.00") + "</td><td style='text-align:right;border:1px solid black;'>" + credit.ToString("0,0.00") + "</td>";
            decimal diff = debit - credit;
            html += "<tr><td></td><td></td><td>Balance:</td><td style='text-align:right;border:1px solid black;'>" + (diff > 0 ? "(Dr)" + diff.ToString("0,0.00") : "") + "</td><td style='text-align:right;border:1px solid black;'>" + (diff < 0 ? "(Cr)" + (diff * (-1)).ToString("0,0.00") : "") + "</td>";
            lblJournal.Visible = true;
            lblJournal.Text = html;
           // gvJournal.DataSource = dsJournal;
           //gvJournal.DataBind();
        }

        catch (Exception ex)
        {
        }
    }

    protected void ddlBasicAccountID_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        SubBasicAccountIDLoad();
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

    protected void gvJournal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowIndex == 0)
        {
            totalDebit = 0;
            totalCredit = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDebit = (Label)e.Row.FindControl("lblDebit");
            Label lblCredit = (Label)e.Row.FindControl("lblCredit");
            HiddenField hfRowHeadID = (HiddenField)e.Row.FindControl("hfRowHeadID");
            Label lblAccountHead = (Label)e.Row.FindControl("lblAccountHead");

            totalDebit += Convert.ToDecimal(lblDebit.Text);
            totalCredit += Convert.ToDecimal(lblCredit.Text);

            //ACC_Head acHead = ACC_HeadManager.GetACC_HeadByHeadID(Convert.ToInt32(hfRowHeadID.Value));
            //lblAccountHead.Text = acHead.HeadName;
        }

        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalDebit = (Label)e.Row.FindControl("lblTotalDebit");
            Label lblTotalCredit = (Label)e.Row.FindControl("lblTotalCredit");
            Label lblBalanceDebit = (Label)e.Row.FindControl("lblBalanceDebit");
            Label lblBalanceCredit = (Label)e.Row.FindControl("lblBalanceCredit");

            lblTotalDebit.Text = totalDebit.ToString();
            lblTotalCredit.Text = totalCredit.ToString();
            if (totalCredit > totalDebit)
            {
                lblBalanceDebit.Text = "";
                lblBalanceCredit.Text =  "(Cr) "+(totalCredit - totalDebit).ToString() ;
            }
            else if (totalDebit > totalCredit)
            {
                lblBalanceCredit.Text = "";
                lblBalanceDebit.Text = "(Dr) " + (totalDebit - totalCredit).ToString() ;
            }
            else
            {
                lblBalanceCredit.Text = "";
                lblBalanceDebit.Text = "";
            }
        }
    }
    protected void ddlAccountID_SelectedIndexChanged(object sender, EventArgs e)
    {
        getHead(false);
    }
}

