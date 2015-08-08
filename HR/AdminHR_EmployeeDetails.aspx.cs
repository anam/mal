using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_AdminHR_EmployeeDetails : System.Web.UI.Page
{
    private decimal _totalSalary = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                var employeeID = Request.QueryString["ID"];
                DataSet dsEmployeeInfo = HR_EmployeeManager.GetHR_EmployeeInfoByEmployeeID(employeeID);
                UCEmployeeInfo1.DsEmployeeInfo = dsEmployeeInfo;

                DataSet dscontact = HR_ContactManager.GetHR_ContactByEmployeeID(employeeID);
                if (dscontact.Tables[0].Rows.Count > 0)
                {
                    UCContact1.DsContact = dscontact;
                }
                else
                {
                    UCContact1.Visible = false;
                }

                DataSet dsDocumnet = HR_DocumentsManager.GetHR_DocumentsByEmployeeID(employeeID);
                DataTable dtDocumnet = dsDocumnet.Tables[0];
                if (dtDocumnet.Rows.Count > 0)
                {
                    lblCvDocs.Text = dtDocumnet.Rows[0]["CvDocs"].ToString(); //dsDocumnet.rowCvDocs.
                    lblJobAgreement.Text = dtDocumnet.Rows[0]["JobAgreement"].ToString(); //dsDocumnet.rowCvDocs.
                }
                DataSet dsOtherDocumntes = HR_OthersDocumentsManager.GetHR_OthersDocumentsByEmployeeID(employeeID);

                if (dsOtherDocumntes != null)
                {

                    gvHR_OthersDocuments.DataSource = dsOtherDocumntes;
                    gvHR_OthersDocuments.DataBind();
                }
                else
                {
                    trOtherDocuments.Visible = false;
                }
               

                // HR_OthersDocumentsManager.LoadHR_OthersDocumentsPage(gvHR_OthersDocuments, rptPager, pageIndex, ddlPageSize);
                DataSet dsJobPosting = HR_JobPostingManager.GetHR_JobPostingByEmployeeID(employeeID);
                DataTable dtJobPosting = dsJobPosting.Tables[0];
                if (dtJobPosting.Rows.Count > 0)
                {
                    lblDepartment.Text = dtJobPosting.Rows[0]["DepartmentName"].ToString();
                    lblDesignationName.Text = dtJobPosting.Rows[0]["DesignationName"].ToString();
                    lblJobLocation.Text = dtJobPosting.Rows[0]["JobLocation"].ToString();
                    lblSupervisorName.Text = dtJobPosting.Rows[0]["SupervisorName"].ToString();
                    lblEndDate.Text = dtJobPosting.Rows[0]["EndDate"].ToString();
                    lblAddedDate.Text = dtJobPosting.Rows[0]["AddedDate"].ToString();
                    // lblJobResponsibility.Text = dtJobPosting.Rows[0]["JobResponsibility"].ToString();
                    lblSupervisorName.Text = dtJobPosting.Rows[0]["SupervisorName"].ToString();
                    lblStatus.Text = dtJobPosting.Rows[0]["PostingStatus"].ToString();
                }
                else
                {
                    divPositioningInformation.Visible = false;
                }

                //lblDepartment

                //load working and shifting hours

                //   HR_WorkingDaysShiftingManager.LoadHR_WorkingDaysShiftingPage

                DataSet dsWorkingDaysShiftingManger = HR_WorkingDaysShiftingManager.GetHR_WorkingDaysShiftingEmployeeID(employeeID);
                DataTable dtWorkingDaysShifting = dsWorkingDaysShiftingManger.Tables[0];

                if (dtWorkingDaysShifting.Rows.Count > 0)
                {
                    chkSaturday.Checked = dtWorkingDaysShifting.Rows[0]["Saturday"].ToString() == "True" ? true : false;
                    chkSunday.Checked = dtWorkingDaysShifting.Rows[0]["Sunday"].ToString() == "True" ? true : false;
                    chkMonday.Checked = dtWorkingDaysShifting.Rows[0]["Monday"].ToString() == "True" ? true : false;
                    chkTuesday.Checked = dtWorkingDaysShifting.Rows[0]["Tuesday"].ToString() == "True" ? true : false;
                    chkWednesday.Checked = dtWorkingDaysShifting.Rows[0]["Wednesday"].ToString() == "True" ? true : false;
                    chkThrusday.Checked = dtWorkingDaysShifting.Rows[0]["Thrusday"].ToString() == "True" ? true : false;

                    if(dtWorkingDaysShifting.Rows[0]["ShiftStartTime"] != null)
                    {
                    DateTime startDate = Convert.ToDateTime( dtWorkingDaysShifting.Rows[0]["ShiftStartTime"]);
                    lblShiftStartTime.Text = startDate.Hour.ToString() +" : "+ startDate.Minute.ToString();//dtWorkingDaysShifting.Rows[0]["ShiftStartTime"].ToString();
                    }
                    if (dtWorkingDaysShifting.Rows[0]["ShiftEndTime"] != null)
                    {
                        DateTime endDate = Convert.ToDateTime(dtWorkingDaysShifting.Rows[0]["ShiftEndTime"]);
                        lbShiftEndTime.Text = endDate.Hour.ToString() + " : " + endDate.Minute.ToString();// dtWorkingDaysShifting.Rows[0]["ShiftEndTime"].ToString();
                    }
                    lblDescription.Text = dtWorkingDaysShifting.Rows[0]["Description"].ToString();
                }
                else
                {
                    divShiftingWorkingDay.Visible = false;
                }

                //attandance rules

                DataSet dsAttandanceRules = HR_AttendenceRulesManager.GetHR_AttendenceRulesByEmployeeID(employeeID);
                DataTable dtAttandanceRules = dsAttandanceRules.Tables[0];
                if (dtAttandanceRules.Rows.Count > 0)
                {
                    lblRules.Text = dtAttandanceRules.Rows[0]["Rules"].ToString();
                    lblUnit.Text = dtAttandanceRules.Rows[0]["Unit"].ToString();
                    lblTime.Text = dtAttandanceRules.Rows[0]["Time"].ToString();
                }
                else
                {
                    divAttendanceRules.Visible = false;
                }


                HR_LunchRule dsLunchRule = HR_LunchRuleManager.GetHR_LunchRuleByEmployeeID(employeeID);
                //DataTable dtLunchRule = dsLunchRule.Tables[0];
                if (dsLunchRule!=null)
                {
                    lblLUnchAllowed.Text = dsLunchRule.LunchFlag.ToString() ;
                    lblLunchStartTimeMins.Text = dsLunchRule.LunchTimeStart.Minute.ToString();
                    lblLunchStartTimeHours.Text = dsLunchRule.LunchTimeStart.Hour.ToString();
                    lblLunchEndTimeHours.Text = dsLunchRule.LunchTimeEnd.Hour.ToString();

                    lblLunchEndTimeMins.Text = dsLunchRule.LunchTimeEnd.Minute.ToString();

                    lblLunchFlexibleTimeHours.Text = "00";
                    lblLunchFlexibleTimeMins.Text = dsLunchRule.LunchFlexibleTimeMins.ToString();
                    //LunchTimeAllowed
                }
                else
                {
                    divLunchRules.Visible = false;
                }
                EmployeeSalaryCalculation(employeeID);
                EmployeeProvidentFund(employeeID);
                EmployeeOverTimeAmount(employeeID);
                EmployeeSalaryIncrementAmount(employeeID);
                EmployeeTaxAmount(employeeID);
                EmployeeSalaryAdjustmentList(employeeID);
                EmployeeBenifit(employeeID);
                LoadEducationalBackground(employeeID);
                EmployeeBankAccountInfo(employeeID);
                EmployeeJobExperience(employeeID);
            }
        }

    }

    private void LoadEducationalBackground(string employerID)
    {

        DataSet dseducation = COMN_EducatinalBackgroundManager.GetAllCOMN_EducatinalBackgroundsByEmployerID(employerID);

        // gvCOMN_EducatinalBackground.DataSource = dseducation;
        // gvCOMN_EducatinalBackground.DataBind();

        if (dseducation.Tables[0].Rows.Count > 0)
        {
            gvCOMN_EducatinalBackground.DataSource = dseducation;
            gvCOMN_EducatinalBackground.DataBind();
        }
        else
        {
            divEducational.Visible = false;
        }
    }

    private decimal EmployeeSalaryCalculation(string employeeID)
    {
        HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(employeeID);
        decimal salaryBasicOrGross = 0;
        if (employeeSalary == null)
        {
            divSalaryRules.Visible = false;
            return 0;
        }
        if (employeeSalary.IsGross)
        {
            salaryBasicOrGross = employeeSalary.GrossAmount;
        }
        else
        {
            salaryBasicOrGross = employeeSalary.BasicAmount;
        }

        DataSet employeeSalaryRulesDataSet = HR_EmployeeSalaryRulesManager.GetHR_EmployeeSalaryRulesByEmployeeID(employeeID);
        decimal totalSalary = 0;

        foreach (DataRow row in employeeSalaryRulesDataSet.Tables[0].Rows)
        {
            decimal calValue = 0;
            if (row["RulesOperator"].ToString() == "=")
            {
                calValue = salaryBasicOrGross;
                row["PackageID"] = (object)calValue;
            }
            else if (row["RulesOperator"].ToString() == "/")
            {
                calValue = salaryBasicOrGross / Convert.ToDecimal(row["RulesValue"].ToString());
                row["PackageID"] = (object)calValue;
            }
            else if (row["RulesOperator"].ToString() == "*")
            {
                calValue = salaryBasicOrGross * Convert.ToDecimal(row["RulesValue"].ToString());
                row["PackageID"] = (object)calValue;
            }
            else if (row["RulesOperator"].ToString() == "+")
            {
                calValue = salaryBasicOrGross + Convert.ToDecimal(row["RulesValue"].ToString());
                row["PackageID"] = (object)calValue;
            }
            else if (row["RulesOperator"].ToString() == "-")
            {
                calValue = salaryBasicOrGross - Convert.ToDecimal(row["RulesValue"].ToString());
                row["PackageID"] = (object)calValue;
            }
            else if (row["RulesOperator"].ToString() == "%")
            {
                calValue = salaryBasicOrGross * (Convert.ToDecimal(row["RulesValue"].ToString()) / 100);
                row["PackageID"] = (object)calValue;
            }
            totalSalary += calValue;

            if (employeeSalary.IsGross)
            {
                lblDefinedSalary.Text = "Gross Salary : " + employeeSalary.GrossAmount.ToString("N2");
                lblTotalSalary.Text = "Total Salary : " + employeeSalary.GrossAmount.ToString("N2");
            }
            else
            {
                lblDefinedSalary.Text = "Basic Salary : " + employeeSalary.BasicAmount.ToString("N2");
                lblTotalSalary.Text = "Total Salary : " + totalSalary.ToString("N2");
            }
        }

        gridViewEmployeeSalDetail.DataSource = employeeSalaryRulesDataSet;
        gridViewEmployeeSalDetail.DataBind();
        _totalSalary = totalSalary;
        return totalSalary;
    }

    private void EmployeeProvidentFund(string employeeID)
    {
        HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(employeeID); 
        HR_ProvidentfundContribution providentfundContribution = HR_ProvidentfundContributionManager.GetHR_ProvidentfundContributionByEmployeeID(employeeID);
        HR_ProvidentfundRules providentfundRules = null;
        if (providentfundContribution != null)
        {
            providentfundRules = HR_ProvidentfundRulesManager.GetHR_ProvidentfundRulesByProvidentfundRulesID(providentfundContribution.ProvidentfundRulesID);
        }
        if (employeeSalary != null)
        {
            if (providentfundRules != null)
            {
                if (providentfundRules.IsGrossPortion)
                {
                    if (employeeSalary.GrossAmount == 0)
                    {
                        double percent =0;
                        percent = 100 / 60;  // percentage ( 100/60);
                        employeeSalary.GrossAmount = employeeSalary.BasicAmount * (decimal)percent;
                    }
                    providentfundContribution.Amount = employeeSalary.GrossAmount * providentfundRules.Value;
                }
                else
                {
                    if (employeeSalary.BasicAmount == 0)
                    {
                        double percent = 0.6; // percentage ( 60 / 100);
                        employeeSalary.BasicAmount = employeeSalary.GrossAmount * (decimal)percent;
                    }
                    providentfundContribution.Amount = employeeSalary.BasicAmount * (decimal)(providentfundRules.Value / 100);  // providentfundRules.Value is percentage of salary
                }
            }
        }
        if (providentfundContribution != null)
        {
            lblProvidentFundAmount.Text = providentfundContribution.Amount.ToString("N2") + " TK";
        }
        else
        {
            divProvidendFund.Visible = false;
        }
    }

    private void EmployeeOverTimeAmount(string employeeID)
    {
        try
        {
            HR_EmployeeOverTimePackage employeeOverTimePackage = HR_EmployeeOverTimePackageManager.GetHR_EmployeeOverTimePackageByEmployeeID(employeeID);
            HR_OverTimePackage overTimePackage = HR_OverTimePackageManager.GetHR_OverTimePackageByOverTimePackageID(employeeOverTimePackage.OverTimePackageID);
            if (employeeOverTimePackage != null)
            {
                if (overTimePackage == null)
                {
                    lblOverTimeAmountPerMonth.Text = (employeeOverTimePackage.OverTimeTakaPerHour * Convert.ToDecimal(employeeOverTimePackage.DayMonth)).ToString("N2");
                }
                else
                {
                    lblOverTimeAmountPerMonth.Text = (employeeOverTimePackage.OverTimeTakaPerHour * Convert.ToDecimal(employeeOverTimePackage.DayMonth) * Convert.ToDecimal(overTimePackage.OverTimeFormula)).ToString("N2");
                }
            }
            else
            {
                divOvertimeRules.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void EmployeeSalaryIncrementAmount(string employeeID)
    {
        HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(employeeID); // salary will be Basic or Gross , it is not accurate calculation
        if (employeeSalary != null)
        {
            HR_SalaryIncrementPackageRules salaryIncrementPackageRules = HR_SalaryIncrementPackageRulesManager.GetHR_SalaryIncrementPackageRulesByEmployeeID(employeeID); // not define Basic or Gross , it is not accurate calculation
            if (salaryIncrementPackageRules != null)
            {
                HR_SalaryIncrementPackage salaryIncrementPackage = HR_SalaryIncrementPackageManager.GetHR_SalaryIncrementPackageBySalaryIncrementPackageID(salaryIncrementPackageRules.SalaryIncrementPackageID);

                decimal SalaryIncrementPercent = Convert.ToDecimal(salaryIncrementPackage.SalaryIncrementFormula) / 100;

                if (employeeSalary.IsGross)
                {
                    if (employeeSalary.GrossAmount == 0)
                    {
                        double percent = 0.6;
                        percent = 100 / 60;  // percentage ( 100/60);
                        employeeSalary.GrossAmount = employeeSalary.BasicAmount * (decimal)percent;
                    }
                    lblSalaryIncrement.Text = ": " + (employeeSalary.GrossAmount * SalaryIncrementPercent).ToString("N2") + " Yearly";
                }
                else
                {
                    if (employeeSalary.BasicAmount == 0)
                    {
                        double percent = 0.6; // percentage ( 60 / 100);
                        employeeSalary.BasicAmount = employeeSalary.GrossAmount * (decimal)percent;
                    }
                    lblSalaryIncrement.Text = ": " + (employeeSalary.BasicAmount * SalaryIncrementPercent).ToString("N2") + " Yearly";
                }

            }
            else
            {
                divSalaryIncrement.Visible = false;
            }
        }
    }

    private void EmployeeTaxAmount(string employeeID)
    {
        HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(employeeID); // salary will be Basic or Gross , it is not accurate calculation
        if (employeeSalary != null)
        {
            HR_SalaryTaxPackageRules salaryTaxPackageRules = HR_SalaryTaxPackageRulesManager.GetHR_SalaryTaxPackageRulesByEmployeeID(employeeID); // not define Basic or Gross , it is not accurate calculation
            if (salaryTaxPackageRules != null)
            {
                HR_SalaryTaxPackage salaryTaxPackage = HR_SalaryTaxPackageManager.GetHR_SalaryTaxPackageBySalaryTaxPackagePackageID(salaryTaxPackageRules.SalaryTaxPackageID);
                if (salaryTaxPackage != null)
                {
                    if (employeeSalary.IsGross)
                    {
                        //lblTaxAmount.Text = (_totalSalary * Convert.ToDecimal(salaryTaxPackage.SalaryTaxPackageFormula)).ToString("N2"); // SalaryTaxPackageFormula it string need correction formula or rethink about it.
                        lblTaxAmount.Text = (employeeSalary.GrossAmount * Convert.ToDecimal(salaryTaxPackage.SalaryTaxPackageFormula)).ToString("N2"); // SalaryTaxPackageFormula it string need correction formula or rethink about it.
                    }
                    else
                    {
                        lblTaxAmount.Text = (employeeSalary.BasicAmount * Convert.ToDecimal(salaryTaxPackage.SalaryTaxPackageFormula)).ToString("N2"); // SalaryTaxPackageFormula it string need correction formula or rethink about it.
                    }
                }
            }
            else
            {
                divTaxRules.Visible = false;
            }
        }
        else
        {
            divTaxRules.Visible = false;
        }
    }

    private void EmployeeSalaryAdjustmentList(string employeeID)
    {
        HR_SalaryAdjustmentListRules salaryAdjustmentListRules = HR_SalaryAdjustmentListRulesManager.GetHR_SalaryAdjustmentListByEmployeeID(employeeID);
        if (salaryAdjustmentListRules != null)
        {
            DataSet dsSalaryAdjustmentList = HR_SalaryAdjustmentListManager.GetSalaryAdjustmentListBySalaryAdjustmenGroupID(salaryAdjustmentListRules.SalaryAdjustmentGroupID);
            if (dsSalaryAdjustmentList.Tables[0].Rows.Count > 0)
            {
                gvSalaryAdjustmentList.DataSource = dsSalaryAdjustmentList.Tables[0];
                gvSalaryAdjustmentList.DataBind();
            }
            else
            {
                divSalaryAdjustment.Visible = false;
            }
        }
        else
        {
            divSalaryAdjustment.Visible = false;
        }
    }

    private void EmployeeBenifit(string employeeID)
    {
        HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(employeeID); // salary will be Basic or Gross , it is not accurate calculation
        if (employeeSalary != null)
        {
            HR_BenifitPackageRules benifitPackageRules = HR_BenifitPackageRulesManager.GetHR_BenifitPackageRulesByEmployeeID(employeeID);
            if (benifitPackageRules != null)
            {
                HR_BenifitPackage benifitPackage = HR_BenifitPackageManager.GetHR_BenifitPackageByBenifitPackageID(benifitPackageRules.BenifitPackageID);
                if (employeeSalary.IsGross)
                {
                   //lblBenifit.Text = "Eid Bonus : " + (_totalSalary * Convert.ToDecimal(benifitPackage.BebifitFormula)).ToString("N2");
                    if (employeeSalary.GrossAmount == 0)
                    {
                        double percent = 0.6;
                        percent = 100 / 60;  // percentage ( 100/60);
                        employeeSalary.GrossAmount = employeeSalary.BasicAmount * (decimal)percent;
                    }
                    lblBenifit.Text = "Eid Bonus : " + (employeeSalary.GrossAmount * (Convert.ToDecimal(benifitPackage.BebifitFormula)/100)).ToString("N2");
                }
                else
                {
                    //lblBenifit.Text = "Eid Bonus : " + (_totalSalary * Convert.ToDecimal(benifitPackage.BebifitFormula)).ToString("N2");
                    if (employeeSalary.BasicAmount == 0)
                    {
                        double percent = 0.6; // percentage ( 60 / 100);
                        employeeSalary.BasicAmount = employeeSalary.GrossAmount * (decimal)percent;
                    }
                    lblBenifit.Text = "Eid Bonus : " + (employeeSalary.BasicAmount *( Convert.ToDecimal(benifitPackage.BebifitFormula)/100)).ToString("N2");// Formula value is percentage
                }
            }
            else
            {
                divBenifitRules.Visible = false;
            }
        }
        else
        {
            divBenifitRules.Visible = false;
        }
    }

    private void EmployeeBankAccountInfo(string employeeID)
    {
        HR_BankAccount bankAccount = HR_BankManager.GetHR_BankAccountByEmployeeID(employeeID);
        if (bankAccount != null)
        {
            lblBankAccountNo.Text = bankAccount.AccountName;
            lblAccountName.Text = bankAccount.AccountName;
            lblBankName.Text = bankAccount.BankName;
            lblBankAddress.Text = bankAccount.BankAddress;
            lblContactPerson.Text = bankAccount.ContactPerson;
        }
        else
        {
            divBankAccount.Visible = false;
        }
    }

    private void EmployeeJobExperience(string employeeID)
    {
        DataSet jobExperienceDataSet = HR_JobExperienceManager.GetHR_JobExperienceByEmployeeID(employeeID);
        if (jobExperienceDataSet.Tables[0].Rows.Count > 0)
        {
            gvJobExperience.DataSource = jobExperienceDataSet.Tables[0];
            gvJobExperience.DataBind();
        }
        else
        {
            divJobExperience.Visible = false;
        }
    }

    protected void btnOtherDocuments_Click(object sender, EventArgs e)
    {

    }
    protected void btnPostingInformation_Click(object sender, EventArgs e)
    {
        //btnPostingInformation.
    }
}