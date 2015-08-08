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
public partial class AdminHR_EmployeeTerminate : System.Web.UI.Page
{
    //static DateTime _joiningDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                //Session["doubleEntry"];
                Session.Remove("doubleEntry");
                txtCUCCheckDate.Text = DateTime.Today.ToString("dd MMM yyyy");
                loadBank();
                var employeeID = Request.QueryString["ID"];
                DataSet dsEmployeeInfo = HR_EmployeeManager.GetHR_EmployeeInfoByEmployeeID(employeeID);
                UCEmployeeInfo1.DsEmployeeInfo = dsEmployeeInfo;
                HR_Employee employee = HR_EmployeeManager.GetHR_EmployeeByEmployeeID(employeeID);
                if (employee != null)
                 {
                    //if (employee.JoiningDate!=null)
                    //{
                    //    _joiningDate = employee.JoiningDate;
                    //}
                    if (employee.Flag == false)
                    {
                        txtResignDescription.Text = employee.ResignDescription;
                        txtResignDate.Text = employee.ResignDate.ToString("dd MMM yyyy");
                        btnSave.Enabled = false;
                        GetPFRegisterInfoAndWithdrawAmount();
                        btnSave.Visible = false;
                    }
                    else
                    {
                        CalculateProvidentFund();
                        //GetPFRegisterInfo();
                        txtResignDate.Text = DateTime.Now.ToString("dd MMM yyyy");
                    }
                }
                txtResignDate_OnTextChanged(sender, e);
                ddlAccountForMoney_SelectedIndexChanged(this,new EventArgs());
            }
        }
    }

    protected void GetPFRegisterInfo()
    {
        var employeeID = Request.QueryString["ID"];
        DataSet totalFund = HR_ProvidentFundRegisterManager.GetHR_PFRegisterByEmpIDTotalFund(employeeID);
        if (totalFund != null)
        {
            if (totalFund.Tables[0].Rows.Count > 0)
            {
                DataTable tableTotalFund = totalFund.Tables[0];
                foreach (DataRow row in totalFund.Tables[0].Rows)
                {
                    txtEmpContributionAmount.Text = decimal.Parse(row["EPF"].ToString()).ToString("00");
                    txtComContributionAmount.Text = decimal.Parse(row["CPF"].ToString()).ToString("00");
                    txtTotalContribution.Text = decimal.Parse(row["TotalPFAmount"].ToString()).ToString("00");

                    if (txtEmpContributionAmount.Text.Trim() == string.Empty)
                    {
                        txtEmpContributionAmount.Text = "0";
                    }

                    if (txtComContributionAmount.Text.Trim() == string.Empty)
                    {
                        txtComContributionAmount.Text = "0";
                    }

                    if (txtTotalContribution.Text.Trim() == string.Empty)
                    {
                        txtTotalContribution.Text = "0";
                    }
                }
            }
            else
            {
                txtEmpContributionAmount.Text = "0";
                txtComContributionAmount.Text = "0";
                txtTotalContribution.Text = "0";
            }
        }
        else
        {
            txtEmpContributionAmount.Text = "0";
            txtComContributionAmount.Text = "0";
            txtTotalContribution.Text = "0";
        }
    }

    private void CalculateProvidentFund()
    {
        DataSet dsJournal = ACC_JournalManager.GetACC_JournalByHeadIDByAllByUserID(4, 30, 0, Request.QueryString["ID"],2, "","");
        decimal EPF = 0;
        decimal CPF = 0;
        foreach (DataRow dr in dsJournal.Tables[0].Rows)
        {
            if (dr["AccountID"].ToString() == "46")//EPF
            {
                EPF += (decimal.Parse(dr["Credit"].ToString())-decimal.Parse(dr["Debit"].ToString()));
            }
            else
            if (dr["AccountID"].ToString() == "47")//CPF
            {
                CPF += (decimal.Parse(dr["Credit"].ToString()) - decimal.Parse(dr["Debit"].ToString()));
            }
        }

        txtEmpContributionAmount.Text = EPF.ToString("00");
        txtComContributionAmount.Text = CPF.ToString("00");

        txtTotalContribution.Text = (EPF + CPF).ToString("00");


    }

    protected void GetPFRegisterInfoAndWithdrawAmount()
    {
       
        var employeeID = Request.QueryString["ID"];
        DataSet totalFund = HR_ProvidentFundRegisterManager.GetHR_PFRegisterByEmpIDTotalFund(employeeID);
        if (totalFund != null)
        {
            if (totalFund.Tables[0].Rows.Count > 0)
            {
                DataTable tableTotalFund = totalFund.Tables[0];
                foreach (DataRow row in totalFund.Tables[0].Rows)
                {
                    txtEmpContributionAmount.Text = decimal.Parse(row["EPF"].ToString()).ToString("00");
                    txtComContributionAmount.Text = decimal.Parse(row["CPF"].ToString()).ToString("00");
                    txtTotalContribution.Text = decimal.Parse(row["TotalPFAmount"].ToString()).ToString("00");
                    lblEmpPortionFund.Text = decimal.Parse(row["WithdrawAmount"].ToString()).ToString("00");
                    lblReturnFundToCompany.Text = (Convert.ToDouble(row["TotalPFAmount"].ToString()) - Convert.ToDouble(row["WithdrawAmount"].ToString())).ToString("N2");

                    if (txtEmpContributionAmount.Text.Trim() == string.Empty)
                    {
                        txtEmpContributionAmount.Text = "0";
                    }

                    if (txtComContributionAmount.Text.Trim() == string.Empty)
                    {
                        txtComContributionAmount.Text = "0";
                    }

                    if (txtTotalContribution.Text.Trim() == string.Empty)
                    {
                        txtTotalContribution.Text = "0";
                    }
                    lblEmpPortionFundText.Visible = true;
                    lblEmpPortionFund.Visible = true;
                 
                    lblReturnFundToCompanyText.Visible = true;
                    lblReturnFundToCompany.Visible = true;
                   
                }
            }
            else
            {
                txtEmpContributionAmount.Text = "0";
                txtComContributionAmount.Text = "0";
                txtTotalContribution.Text = "0";
            }
        }
        else
        {
            txtEmpContributionAmount.Text = "0";
            txtComContributionAmount.Text = "0";
            txtTotalContribution.Text = "0";
        }
    }

    protected void txtCPFFundRight_OnTextChanged(object sender, EventArgs e)
    {
        if (txtCPFFundRight.Text.Trim() != string.Empty)
        {
            double cpfFundPercent = Convert.ToDouble(txtCPFFundRight.Text.Trim());
            if (txtComContributionAmount.Text.Trim() != string.Empty)
            {
                double empPortionFund = 0, ruturnFundToCom = 0;
                cpfFundPercent = Convert.ToDouble(txtComContributionAmount.Text.Trim())*(cpfFundPercent/100);
                if (txtComContributionAmount.Text.Trim() != string.Empty)
                {                    
                    double comContribution = Convert.ToDouble(txtComContributionAmount.Text.Trim());
                    empPortionFund = Convert.ToDouble(txtEmpContributionAmount.Text.Trim()) + cpfFundPercent;
                    ruturnFundToCom = comContribution - cpfFundPercent;
                }

                lblEmpPortionFundText.Visible = true;
                lblEmpPortionFund.Visible = true;
                lblEmpPortionFund.Text = empPortionFund.ToString("00");//empPortionFund.ToString("n2");
                lblReturnFundToCompanyText.Visible = true;
                lblReturnFundToCompany.Visible = true;
                lblReturnFundToCompany.Text = ruturnFundToCom.ToString("00");//ruturnFundToCom.ToString("n2")

                txtFinalAmountToWithDraw.Text = (decimal.Parse(lblEmpPortionFund.Text) + decimal.Parse(txtSecurityMoney.Text) + decimal.Parse(txtRemainingSalary.Text) - decimal.Parse(txtAdvanceSalary.Text)).ToString("00");
            }
        }
        //txtResignDate_OnTextChanged(this, new EventArgs());
    }


   
    private void getHeadMoney(string UserID, string UserName,int userTypeID)
    {
        int HeadID = 0;
        string headNameMoney = "";
        DataSet dsHeadUser = ACC_HeadUserManager.GetACC_UserByUserIDnUserTypeIDnAccountID(UserID, userTypeID, int.Parse(ddlAccountForMoney.SelectedValue));
        if (dsHeadUser.Tables[0].Rows.Count == 0)
        {
            //need to create the dead for this user
            ACC_Head aCC_Head = new ACC_Head();
            //	aCC_Head.HeadID=  int.Parse(ddlHeadID.SelectedValue);
            aCC_Head.HeadName = ddlAccountForMoney.SelectedItem.Text + UserName;
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
            aCC_HeadUser.UserTypeID = userTypeID;
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

    protected void txtResignDate_OnTextChanged(object sender, EventArgs e)
    {
        var employeeID = Request.QueryString["ID"];
        HR_Employee employee = HR_EmployeeManager.GetHR_EmployeeByEmployeeID(employeeID);
        hfEmployeeID.Value = employee.EmployeeID;
        hfEmployeeName.Value = employee.EmployeeName;
        hfEmployeeNo.Value = employee.EmployeeNo;
        
        if (employee != null)
        {
            if (employee.JoiningDate != null && employee.JoiningDate != DateTime.MinValue)
            {
                //_joiningDate = employee.JoiningDate;
                if (txtResignDate.Text != string.Empty)
                {
                    DateTime resignDate = Convert.ToDateTime(txtResignDate.Text);
                    TimeSpan totalTS = resignDate.Subtract(employee.JoiningDate);
                    int totalDay = totalTS.Days;
                    int totalYear = totalDay / 365;
                    totalDay = totalDay % 365;
                    int totalMonth = totalDay/30;
                    totalDay = totalDay % 30;
                    int andDay = totalDay;
                    lblServiceLength.Text = "Service length : " + totalYear.ToString() + " year(s) " + totalMonth.ToString() + " month(s) " + andDay.ToString() + " day(s)";

                    List<HR_ProvidentFundSetup> providentFundSetupColl = HR_ProvidentFundSetupManager.GetHR_ProvidentFundSetupColl();
                    foreach (HR_ProvidentFundSetup pfSetup in providentFundSetupColl)
                    {
                        if (totalYear >= pfSetup.ServiceLenStartYear && totalYear < pfSetup.ServiceLenEndYear)
                        {
                            if (pfSetup.FundTypeID == 2)
                            {
                                txtCPFFundRight.Text = pfSetup.FundPercentForEmp.ToString();
                                txtCPFFundRight_OnTextChanged(this, new EventArgs());
                                break;
                            }
                        }
                    }


                    #region Calculate the remaining salary
                    ACC_EmployPayRoleSalary alreadyPostedSalary = ACC_EmployPayRoleSalaryManager.GetEmployPayRoleSalaryByEmployeeIDnSalaryOfDate(DateTime.Parse(txtResignDate.Text).ToString("MMMM, yyyy"),Request.QueryString["ID"]);

                    if (alreadyPostedSalary == null)
                    {
                        lblSalaryBreakDown.Text = SalaryDetailBreakdown();
                    }
                    else
                    {
                        txtRemainingSalary.Text = "0";
                        txtSalaryOfThisMonth.Text = "0";
                        //txtFinalAmountToWithDraw.Text =( decimal.Parse(lblEmpPortionFund.Text) - decimal.Parse(txtAdvanceSalary.Text) ).ToString("00");

                        DataTable securityAmountTable = HR_EmployeeManager.GetEmployeeSecurityAmountInfo();

                        DataRow[] securityMoneyOfEmp = securityAmountTable.Select("EmployeeID='" + Request.QueryString["ID"] + "'");
                        
                        if (securityMoneyOfEmp.Length == 1)
                        {
                            txtSecurityMoney.Text = securityMoneyOfEmp[0][1].ToString();
                        }
                    }

                    txtFinalAmountToWithDraw.Text = (decimal.Parse(lblEmpPortionFund.Text) + decimal.Parse(txtSecurityMoney.Text) + decimal.Parse(txtRemainingSalary.Text) - decimal.Parse(txtAdvanceSalary.Text)).ToString("00");


                    if (decimal.Parse(txtFinalAmountToWithDraw.Text) == 0)
                    {
                        btnJournalEntry.Visible = true;
                    }
                    else if (decimal.Parse(txtFinalAmountToWithDraw.Text) < 0)
                    {
                        btnJournalEntry.Visible = false;
                        lblMessageAdvanceSalaryIsBigger.Text = "Your Advanc Salary is more than the money you will get form Office.<br/>So please return that money First.<br/>Click <a href='~/Accounting/JournalDoubleEntryCommon.aspx?DrOrCr=Dr&OtherTransaction=1&Amount=" + txtFinalAmountToWithDraw.Text + "'>here</a> to take that money";
                    }
                    else
                    {
                        btnJournalEntry.Visible = false;
                    }
                    
                    #endregion
                }
            }
        }
    }

    private String SalaryDetailBreakdown()
    {
        
        DataSet employeeDS = HR_EmployeeManager.GetAllHR_EmployeeMinuesPayrollSalaryEmpByEmployeeID(Request.QueryString["ID"]);
        DataTable advanceSalaryTable = HR_EmployeeManager.GetEmployeeAdvanceSalaryInfo();
        DataTable securityAmountTable = HR_EmployeeManager.GetEmployeeSecurityAmountInfo();
        
        if (employeeDS.Tables[0].Rows.Count > 0)
        {
            int count = 0;
            string salaryBreakDown = "";
            foreach (DataRow employeeRow in employeeDS.Tables[0].Rows)
            {
                count++;
                double salaryAmount = 0;
                HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(employeeRow["EmployeeID"].ToString());
                if (employeeSalary == null)
                {
                    return "";
                }
                if (employeeSalary.IsGross)
                {
                    salaryAmount = Convert.ToDouble(employeeSalary.GrossAmount);
                }
                else
                {
                    salaryAmount = Convert.ToDouble(employeeSalary.BasicAmount);
                }

                int noOfDaysInthisMonth = 30;//DateTime.DaysInMonth(DateTime.Parse(txtResignDate.Text).Year, DateTime.Parse(txtResignDate.Text).Month);
                int noOfDaysWorked = int.Parse(DateTime.Parse(txtResignDate.Text).ToString("dd"));

                salaryAmount = double.Parse(((salaryAmount / noOfDaysInthisMonth) * noOfDaysWorked).ToString("00"));
               
                DataSet employeeSalaryRulesDataSet = HR_EmployeeSalaryRulesManager.GetHR_EmployeeSalaryRulesByEmployeeID(employeeRow["EmployeeID"].ToString());

                
                double totalSalary = 0;
                
                foreach (DataRow row in employeeSalaryRulesDataSet.Tables[0].Rows)
                {
                    double calValue = 0;

                    if (row["RulesOperator"].ToString() == "=")
                    {
                        calValue = salaryAmount;
                        row["PackageID"] = (object)calValue;
                    }
                    else if (row["RulesOperator"].ToString() == "/")
                    {
                        calValue = salaryAmount / Convert.ToDouble(row["RulesValue"].ToString());
                        row["PackageID"] = (object)calValue;
                    }
                    else if (row["RulesOperator"].ToString() == "*")
                    {
                        calValue = salaryAmount * Convert.ToDouble(row["RulesValue"].ToString());
                        row["PackageID"] = (object)calValue;
                    }
                    else if (row["RulesOperator"].ToString() == "+")
                    {
                        calValue = salaryAmount + Convert.ToDouble(row["RulesValue"].ToString());
                        row["PackageID"] = (object)calValue;
                    }
                    else if (row["RulesOperator"].ToString() == "-")
                    {
                        calValue = salaryAmount - Convert.ToDouble(row["RulesValue"].ToString());
                        row["PackageID"] = (object)calValue;
                    }
                    else if (row["RulesOperator"].ToString() == "%")
                    {
                        calValue = salaryAmount * (Convert.ToDouble(row["RulesValue"].ToString()) / 100);
                        row["PackageID"] = (object)calValue;
                    }

                    salaryBreakDown += row["PackageRulesName"].ToString() + ":" + calValue.ToString("00")+";";

                    totalSalary += double.Parse(calValue.ToString("00"));
                }

                txtSalaryOfThisMonth.Text = totalSalary.ToString("00");

                DataRow[] advSalaryOfEmp = advanceSalaryTable.Select("EmployeeID='" + employeeRow["EmployeeID"].ToString() + "'");
                DataRow[] securityMoneyOfEmp = securityAmountTable.Select("EmployeeID='" + employeeRow["EmployeeID"].ToString() + "'");
                if (advSalaryOfEmp.Length == 1)
                {
                    txtAdvanceSalary.Text = advSalaryOfEmp[0][1].ToString();
                }

                if (securityMoneyOfEmp.Length == 1)
                {
                    txtSecurityMoney.Text = securityMoneyOfEmp[0][1].ToString();
                }

                txtRemainingSalary.Text = totalSalary.ToString("00");
            }

            return salaryBreakDown;
        }
        return "";
    }

    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (decimal.Parse(hfHeadIDMoney.Value) == 0)
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


            List<ACC_CUCCheck> aCC_CUCCheckList = new List<ACC_CUCCheck>();
            if (Session["cucCheck"] != null)
            {
                aCC_CUCCheckList = (List<ACC_CUCCheck>)Session["cucCheck"];
            }

            if (ddlAccountForMoney.SelectedValue == "2")
            {
                ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck();
                //	aCC_CUCCheck.CUCCheckID=  int.Parse(ddlCUCCheckID.SelectedValue);
                aCC_CUCCheck.CUCCheckName = lblHeadNameMoney.Text;
                aCC_CUCCheck.CUCCheckNo = txtCUCCheckNo.Text;
                aCC_CUCCheck.BankAccountID = int.Parse(ddlBank.SelectedValue);
                aCC_CUCCheck.CheckDate = DateTime.Parse(txtCUCCheckDate.Text);
                aCC_CUCCheck.PaytoHeadID = int.Parse(hfHeadIDMoney.Value);
                aCC_CUCCheck.JournalID = journalID;
                aCC_CUCCheck.Amount = decimal.Parse(txtAmountToPay.Text);
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

            ACC_Journal aCC_Journal = new ACC_Journal();
            aCC_Journal.JournalID = doubleEntry.Count;
            aCC_Journal.HeadID = int.Parse(hfHeadIDMoney.Value);
            aCC_Journal.HeadName = lblHeadNameMoney.Text;
            aCC_Journal.Debit = 0;
            aCC_Journal.Credit = decimal.Parse(txtAmountToPay.Text);
            aCC_Journal.JournalMasterID = int.Parse("1");
            aCC_Journal.JournalVoucherNo = "";//temporay we are using to manage the check #
            aCC_Journal.UserID = hfUserID.Value;
            aCC_Journal.AccountID = int.Parse(ddlAccountForMoney.SelectedValue);
            aCC_Journal.UserTypeID = int.Parse(hfUserTypeID.Value);
            aCC_Journal.AddedBy = Profile.card_id;
            aCC_Journal.AddedDate = DateTime.Now;
            aCC_Journal.UpdatedBy = Profile.card_id;
            aCC_Journal.UpdateDate = DateTime.Now;
            aCC_Journal.RowStatusID = 1;
            aCC_Journal.IsNotCheck = ddlAccountForMoney.SelectedValue == "42" ? false : true;

            doubleEntry.Add(aCC_Journal);
            Session["doubleEntry"] = doubleEntry;

            btnSave.Visible = false;
            
            lblPaidAmount.Text = (decimal.Parse(lblPaidAmount.Text) + decimal.Parse(txtAmountToPay.Text)).ToString("00");
            txtAmountToPay.Text = "0";
            loadJournal();
            loadSubmitButton();

        }
        catch (Exception ex)
        {
        }

    }

    private void loadJournal()
    {
        List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
        doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];

        gvACC_Journal.DataSource = doubleEntry;
        gvACC_Journal.DataBind();
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
                lblPaidAmount.Text = (decimal.Parse(lblPaidAmount.Text) - doubleEntry[Convert.ToInt32(linkButton.CommandArgument)].Credit).ToString("00");
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

    private void loadSubmitButton()
    {

        if (decimal.Parse(txtFinalAmountToWithDraw.Text) == decimal.Parse(lblPaidAmount.Text))
        {
            btnJournalEntry.Visible = true;
            txtAmountToPay.Visible = false;
        }
        else
        {
            btnJournalEntry.Visible = false;
        }
    }

    protected void ddlAccountForMoney_SelectedIndexChanged(object sender, EventArgs e)
    {
        string UserID = "";
        string UserName = "";
        int UserTypeID = 0;
        
        if (ddlAccountForMoney.SelectedIndex == 0)
        {
            UserID = Profile.card_id;

            UserName = "(" + Profile.No + ")" + Profile.Name;
            hfUserNo.Value = Profile.No;
            UserTypeID = 2;            
            cashAtBank.Visible = false;
        }
        else
        {
            UserID = ddlBank.SelectedValue;
            UserName = ddlBank.SelectedItem.Value;
            hfUserNo.Value = UserID;
            UserTypeID = 3;
            cashAtBank.Visible = true;
        }

        hfUserID.Value = UserID;
        hfUserName.Value = UserName;
        hfUserTypeID.Value = UserTypeID.ToString();
        getHeadMoney(UserID, UserName,UserTypeID);
    }

    private void loadBank()
    {

        try
        {
            DataSet dsbank = ACC_BankAccountManager.GetDropDownListAllACC_BankAccount(); //3 for user type Bank
            ddlBank.Items.Clear();
            foreach (DataRow dr in dsbank.Tables[0].Rows)
            {
                ListItem litems = new ListItem(dr["BankAccountName"].ToString() + "(" + dr["AccountNo"].ToString() + ") ", dr["BankAcountID"].ToString());
                ddlBank.Items.Add(litems);
            }
            ddlBank.DataBind();
            ddlBank.Items.Insert(0, new ListItem("Select Bank Account >>", "0"));
        }
        catch (Exception ex)
        { }
    }

    protected void btnJournalEntry_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            #region Update preentry process

            HR_Employee employee = new HR_Employee();
            employee.EmployeeID = Convert.ToString(Request.QueryString["ID"]);
            employee.ResignDescription = txtResignDescription.Text.Trim();
            employee.ResignDate = Convert.ToDateTime(txtResignDate.Text.Trim());
            employee.Flag = false;

            string userID = Profile.card_id;
            employee.ModifiedBy = userID;
            employee.ModifiedDate = DateTime.Now;

            HR_ProvidentFundRegister providentFundRegister = new HR_ProvidentFundRegister();
            if (lblEmpPortionFund.Text.Trim() != string.Empty)
            {
                providentFundRegister.EmployeeID = Convert.ToString(Request.QueryString["ID"]);
                providentFundRegister.PayrollMonthDate = DateTime.Now;
                providentFundRegister.WithdrawAmount = Convert.ToDecimal(lblEmpPortionFund.Text.Trim());
                providentFundRegister.WithdrawLastDate = DateTime.Now;
                providentFundRegister.AddedBy = userID;
                providentFundRegister.AddedDate = DateTime.Now;

            }
            bool isUpdate = HR_EmployeeManager.UpdateHR_EmployeeResignInfo(employee);
            if (isUpdate)
            {
                if (providentFundRegister.EmployeeID != string.Empty)
                {
                    HR_ProvidentFundRegisterManager.InsertHR_ProvidentFundRegisterWithdrawAmount(providentFundRegister);
                }
                lblMessage.Text = "Information is saved successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }

            if (Convert.ToDecimal(txtRemainingSalary.Text) > 0)
            {
                ACC_EmployPayRoleSalary paySalary = new ACC_EmployPayRoleSalary();
                paySalary.AddedBy = userID;
                paySalary.AddedDate = DateTime.Now;
                paySalary.UpdatedBy = userID;
                paySalary.UpdatedDate = DateTime.Now;
                paySalary.EmployeeID = Request.QueryString["ID"];
                paySalary.SalaryAmount = Convert.ToDecimal(txtRemainingSalary.Text);
                paySalary.PaidSalaryAmount = Convert.ToDecimal("0");
                paySalary.UnpaidSalaryAmount = Convert.ToDecimal(txtRemainingSalary.Text);
                paySalary.Status = 35;
                paySalary.RowStatusID = 1;
                paySalary.SalaryOfDate = DateTime.Parse(txtResignDate.Text).ToString("MMMM, yyyy");
                paySalary.ExtraField1 = lblSalaryBreakDown.Text;
                paySalary.ExtraField2 = paySalary.SalaryAmount.ToString("00");
                paySalary.ExtraField3 = string.Empty;
                paySalary.ExtraField4 = string.Empty;
                paySalary.ExtraField5 = string.Empty;
                paySalary.ExtraField6 = string.Empty;
                paySalary.ExtraField7 = string.Empty;
                paySalary.ExtraField8 = string.Empty;
                paySalary.ExtraField9 = string.Empty;
                paySalary.ExtraField10 = string.Empty;

                int insertedID = ACC_EmployPayRoleSalaryManager.InsertEmployPayRoleSalary(paySalary);
            }
            #endregion

            #region Journal entry
            List<ACC_Journal> doubleEntry = new List<ACC_Journal>();
            doubleEntry = (List<ACC_Journal>)Session["doubleEntry"];

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
                    int temp = eachJournal.JournalID;
                    string checkno = eachJournal.JournalVoucherNo;

                    eachJournal.JournalVoucherNo = "";
                    eachJournal.JournalMasterID = aCC_JournalMaster.JournalMasterID;
                    eachJournal.JournalID = ACC_JournalManager.InsertACC_Journal(eachJournal);

                    foreach (ACC_CUCCheck cucCheck in cucChecks)
                    {
                        if (temp == cucCheck.PaytoHeadID)
                        {
                            cucCheck.PaytoHeadID = eachJournal.JournalID;
                            ACC_CUCCheckManager.InsertACC_CUCCheck(cucCheck);
                        }
                    }
                }
            }
            if (Session["cucCheck"] != null) Session.Remove("cucCheck");
            if (Session["doubleEntry"] != null) Session.Remove("doubleEntry");

            #endregion
            /*
             * <option value="46">Employee Provident Fund</option>
             * <option value="47" selected="selected">Company Provident Fund</option>
             * <option value="3" selected="selected">Advance Salary</option>
             * <option value="17" selected="selected">Employee(Fulltime) Salary</option>
             * <option value="49" selected="selected">Allowance (Provident Fund)</option>
             */
            
            decimal advanceSalaryAmount = decimal.Parse(txtAdvanceSalary.Text);
            decimal salaryOfthisMonth = decimal.Parse(txtSalaryOfThisMonth.Text);
            decimal totalJournalEntryMoney = decimal.Parse(txtFinalAmountToWithDraw.Text);
            decimal EPFMoney = decimal.Parse(txtEmpContributionAmount.Text);
            decimal CPFMoney =decimal.Parse(lblEmpPortionFund.Text) - decimal.Parse(txtEmpContributionAmount.Text);

            //CPF need to process
            //Refund CPF
            if (decimal.Parse(lblReturnFundToCompany.Text) > 0)
            {
                processRefundCPF(decimal.Parse(lblReturnFundToCompany.Text));
            }

            #region Advance Salary process

            //advance salary deduction form the fulltime salary
            if (advanceSalaryAmount > 0)
            {
                if (salaryOfthisMonth > 0)
                {
                   if (advanceSalaryAmount <= salaryOfthisMonth)
                    {
                       processAdvanceSalary(advanceSalaryAmount);
                       advanceSalaryAmount = 0;
                       salaryOfthisMonth -= advanceSalaryAmount;
                    }
                    else
                    {
                        processAdvanceSalary(salaryOfthisMonth);
                        salaryOfthisMonth = 0;
                        advanceSalaryAmount -= salaryOfthisMonth;
                    }
                }
            }
            
            //remaining salary deduction from the Employee Provident fund contribution
            if (advanceSalaryAmount > 0)
            {
                if (EPFMoney > 0)
                {
                    if (advanceSalaryAmount <= EPFMoney)
                    {
                        processAdvanceSalaryFromEPF(advanceSalaryAmount);
                        advanceSalaryAmount = 0;
                        EPFMoney -= advanceSalaryAmount;
                    }
                    else
                    {
                        processAdvanceSalaryFromEPF(EPFMoney);
                        EPFMoney = 0;
                        advanceSalaryAmount -= EPFMoney;
                    }
                }
            }
            bool IsNeedtoCollectMoneyFortheAdvanceSalary = false;
            //remaining salary deduction from the Company Provident fund contribution
            if (advanceSalaryAmount > 0)
            {
                if (CPFMoney > 0)
                {
                    if (advanceSalaryAmount <= CPFMoney)
                    {
                        processAdvanceSalaryFromCPF(advanceSalaryAmount);
                        advanceSalaryAmount = 0;
                        CPFMoney -= advanceSalaryAmount;
                    }
                    else
                    {
                        processAdvanceSalaryFromCPF(EPFMoney);
                        CPFMoney = 0;
                        advanceSalaryAmount -= CPFMoney;
                        IsNeedtoCollectMoneyFortheAdvanceSalary = true;
                    }
                }
            }
            #endregion

            #region Fulltime Salary Process
            if (salaryOfthisMonth > 0)
            {
                processFullTimeSalary(salaryOfthisMonth, aCC_JournalMaster.JournalMasterID);
                totalJournalEntryMoney -= salaryOfthisMonth;
                salaryOfthisMonth = 0;
            }
            #endregion

            #region EPF Process
            if (EPFMoney > 0)
            {
                processEPF(EPFMoney, aCC_JournalMaster.JournalMasterID);
                totalJournalEntryMoney -= EPFMoney;
                EPFMoney = 0;
            }
            #endregion

            #region CPF Process
            if (CPFMoney > 0)
            {
                processCPF(CPFMoney, aCC_JournalMaster.JournalMasterID);
                totalJournalEntryMoney -= CPFMoney;
                CPFMoney = 0;
            }
            #endregion

            if (decimal.Parse(txtSalaryOfThisMonth.Text) > 0)
            {
                DataSet dsHeadUserFulltimeSalary = ACC_HeadUserManager.GetACC_UserByUserIDnUserTypeIDnAccountID(hfEmployeeID.Value, 2, int.Parse(ddlAccountForMoney.SelectedValue));
            }
           
            //if (IsNeedtoCollectMoneyFortheAdvanceSalary)
            //{
            //    Response.Redirect("");
            //}
            btnJournalEntry.Visible = false;
        }
    }

    private void processFullTimeSalary(decimal amount,int journalMasterID)
    {
        try
        {
            ACC_Journal advSalaryACC_Journal = new ACC_Journal();
            advSalaryACC_Journal.UserID = Request.QueryString["ID"];
            advSalaryACC_Journal.JournalMasterID = journalMasterID;
            advSalaryACC_Journal.Balance = amount;
            advSalaryACC_Journal.AddedBy = Profile.card_id;
            advSalaryACC_Journal.AddedDate = DateTime.Now;
            advSalaryACC_Journal.UpdatedBy = Profile.card_id;
            advSalaryACC_Journal.UpdateDate = DateTime.Now;
            advSalaryACC_Journal.SalaryOfDate = DateTime.Parse(txtResignDate.Text).ToString("MMMM, yyyy");
            ACC_AccountingCommonManager.ProcessACC_FullTimeSalary(Request.QueryString["ID"], advSalaryACC_Journal);
        }
        catch (Exception ex)
        { }
    }

    private void processEPF(decimal amount, int journalMasterID)
    {
        try
        {
            ACC_Journal advSalaryACC_Journal = new ACC_Journal();
            advSalaryACC_Journal.UserID = Request.QueryString["ID"];
            advSalaryACC_Journal.JournalMasterID = journalMasterID;
            advSalaryACC_Journal.Balance = amount;
            advSalaryACC_Journal.AddedBy = Profile.card_id;
            advSalaryACC_Journal.AddedDate = DateTime.Now;
            advSalaryACC_Journal.UpdatedBy = Profile.card_id;
            advSalaryACC_Journal.UpdateDate = DateTime.Now;
            ACC_AccountingCommonManager.ProcessACC_EPF(Request.QueryString["ID"], advSalaryACC_Journal);
        }
        catch (Exception ex)
        { }
    }

    private void processCPF(decimal amount, int journalMasterID)
    {
        try
        {
            ACC_Journal advSalaryACC_Journal = new ACC_Journal();
            advSalaryACC_Journal.UserID = Request.QueryString["ID"];
            advSalaryACC_Journal.JournalMasterID = journalMasterID;
            advSalaryACC_Journal.Balance = amount;
            advSalaryACC_Journal.AddedBy = Profile.card_id;
            advSalaryACC_Journal.AddedDate = DateTime.Now;
            advSalaryACC_Journal.UpdatedBy = Profile.card_id;
            advSalaryACC_Journal.UpdateDate = DateTime.Now;
            ACC_AccountingCommonManager.ProcessACC_CPF(Request.QueryString["ID"], advSalaryACC_Journal);
        }
        catch (Exception ex)
        { }
    }

    private void processAdvanceSalary(decimal amount)
    {
        try
        {
            ACC_Journal advSalaryACC_Journal = new ACC_Journal();
            advSalaryACC_Journal.UserID = Request.QueryString["ID"];
            advSalaryACC_Journal.Balance = amount;
            advSalaryACC_Journal.AddedBy = Profile.card_id;
            advSalaryACC_Journal.AddedDate = DateTime.Now;
            advSalaryACC_Journal.UpdatedBy = Profile.card_id;
            advSalaryACC_Journal.UpdateDate = DateTime.Now;
            advSalaryACC_Journal.SalaryOfDate = DateTime.Parse(txtResignDate.Text).ToString("MMMM, yyyy");
            ACC_AccountingCommonManager.ProcessACC_AdvanceSalary(Request.QueryString["ID"], advSalaryACC_Journal);
        }
        catch (Exception ex)
        { }
    }

    private void processAdvanceSalaryFromEPF(decimal amount)
    {
        try
        {
            ACC_Journal advSalaryACC_Journal = new ACC_Journal();
            advSalaryACC_Journal.UserID = Request.QueryString["ID"];
            advSalaryACC_Journal.Balance = amount;
            advSalaryACC_Journal.AddedBy = Profile.card_id;
            advSalaryACC_Journal.AddedDate = DateTime.Now;
            advSalaryACC_Journal.UpdatedBy = Profile.card_id;
            advSalaryACC_Journal.UpdateDate = DateTime.Now;
            ACC_AccountingCommonManager.ProcessACC_AdvanceSalaryFromEPF(Request.QueryString["ID"], advSalaryACC_Journal);
        }
        catch (Exception ex)
        { }
    }

    private void processAdvanceSalaryFromCPF(decimal amount)
    {
        try
        {
            ACC_Journal advSalaryACC_Journal = new ACC_Journal();
            advSalaryACC_Journal.UserID = Request.QueryString["ID"];
            advSalaryACC_Journal.Balance = amount;
            advSalaryACC_Journal.AddedBy = Profile.card_id;
            advSalaryACC_Journal.AddedDate = DateTime.Now;
            advSalaryACC_Journal.UpdatedBy = Profile.card_id;
            advSalaryACC_Journal.UpdateDate = DateTime.Now;
            ACC_AccountingCommonManager.ProcessACC_AdvanceSalaryFromCPF(Request.QueryString["ID"], advSalaryACC_Journal);
        }
        catch (Exception ex)
        { }
    }

    private void processRefundCPF(decimal amount)
    {
        try
        {
            ACC_Journal RefundCPFACC_Journal = new ACC_Journal();
            RefundCPFACC_Journal.UserID = Request.QueryString["ID"];
            RefundCPFACC_Journal.Balance = amount;
            RefundCPFACC_Journal.AddedBy = Profile.card_id;
            RefundCPFACC_Journal.AddedDate = DateTime.Now;
            RefundCPFACC_Journal.UpdatedBy = Profile.card_id;
            RefundCPFACC_Journal.UpdateDate = DateTime.Now;
            ACC_AccountingCommonManager.ProcessACC_RefundCPF(Request.QueryString["ID"], RefundCPFACC_Journal);
        }
        catch (Exception ex)
        { }
    }
    protected void txtAmountToPay_TextChanged(object sender, EventArgs e)
    {
        if (decimal.Parse(txtAmountToPay.Text) == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Please select the Account for Money entry.')", true);
            return;
        }
        else
        {
            if ((decimal.Parse(txtAmountToPay.Text) > (decimal.Parse(txtFinalAmountToWithDraw.Text) - decimal.Parse(lblPaidAmount.Text))) && ((decimal.Parse(txtFinalAmountToWithDraw.Text) - decimal.Parse(lblPaidAmount.Text))>=0))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Money can not be greater.')", true);
                return;
            }
            else
            {
                btnSave.Visible = true;
            }
        }
    }
}

