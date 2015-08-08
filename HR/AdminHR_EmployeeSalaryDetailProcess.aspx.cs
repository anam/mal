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
using System.Globalization;
public partial class AdminHR_EmployeeSalaryDetailProcess : System.Web.UI.Page
{
    private static DataSet _childDataSet = null;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {            
            _loadYears();
            _loadMonths();
            loadEmployee();
            btnPost.Visible = false;
            AllSalaryDate();
        }
    }

    private void AllSalaryDate()
    {
        try
        {
            DataSet ds = ACC_EmployPayRoleSalaryManager.GetACC_AllSalaryDate();
            ddlSalaryOfMonth.DataValueField = "SalaryOfDate";
            ddlSalaryOfMonth.DataTextField = "SalaryOfDate";
            ddlSalaryOfMonth.DataSource = ds.Tables[0];
            ddlSalaryOfMonth.DataBind();
            ddlSalaryOfMonth.Items.Insert(0, new ListItem("Select Month >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void loadEmployee()
    {
        try {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();

            ListItem li = new ListItem("Select Employee...", "0");
            ddlExployeeID.Items.Add(li);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (bool.Parse(dr["Flag"].ToString()) == true)
                {
                    ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeID"].ToString());
                    ddlExployeeID.Items.Add(item);
                }
            }
        }
        catch(Exception ex)
        {}
    }

    #region Private Methods
    private void _loadYears()
    {
        try
        {
            int firstYear = DateTime.Now.Year - 5;
            for (int i = 0; i < 20; i++)
            {
                ddlYears.Items.Add(new ListItem((firstYear + i).ToString()));
            }
            ddlYears.Items.Insert(0, new ListItem("...Select Year...", "0"));
            ddlYears.SelectedValue = firstYear + 5 + "";
        }
        catch (Exception ex)
        {
        }
    }

    private void _loadMonths()
    {
        try
        {
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.TakeWhile(m => m != String.Empty).Select((m, i) => new { Month = i + 1, MonthName = m }).ToList();
            foreach (var month in months)
            {
                ddlMonths.Items.Add(new ListItem(month.MonthName, month.Month.ToString()));
            }

            ddlMonths.Items.Insert(0, new ListItem("...Select Month...", "0"));
            ddlMonths.SelectedValue = DateTime.Now.Month.ToString();

        }
        catch (Exception ex)
        {
        }
    }

    private void SalaryDetailBreakdown()
    {      
  

        DataTable dtSalaryDetail = new DataTable("SalaryDetail");
        DataRow newRow;
        Session["totalLoanDeduction"] = "0";
        double totalGross = 0, totalPFAmount = 0, totalLoanDeduction = 0, totalSalaryPayToEmp = 0;
        dtSalaryDetail.Columns.Add("EmployeeID");
        dtSalaryDetail.Columns.Add("EmployeeNo");
        dtSalaryDetail.Columns.Add("EmployeeName");
        dtSalaryDetail.Columns.Add("DepartmentName");
        dtSalaryDetail.Columns.Add("Designation");
        dtSalaryDetail.Columns.Add("SalaryDetail");
        dtSalaryDetail.Columns.Add("TotalSalary");
        dtSalaryDetail.Columns.Add("SalaryDiduction");
        dtSalaryDetail.Columns.Add("PFAmount");
        dtSalaryDetail.Columns.Add("SecurityAmount");
        
        dtSalaryDetail.Columns.Add("LoanAmount");
        dtSalaryDetail.Columns.Add("GrandTotal");

        List<AbsendSalaryDiduction> salaryDiduction = new List<AbsendSalaryDiduction>();
        salaryDiduction = AbsendSalaryDiductionManager.GetAllAbsendSalaryDiductionsBySalaryOfMonth(ddlMonths.SelectedItem.Text+", "+ddlYears.SelectedItem.Text);

        DataSet employeeDS = HR_EmployeeManager.GetAllHR_EmployeeMinuesPayrollSalaryEmp(ddlMonths.SelectedItem.Text + ", " + ddlYears.SelectedValue);
        DataTable advanceSalaryTable = HR_EmployeeManager.GetEmployeeAdvanceSalaryInfo();
        if (_childDataSet == null)
        {
            _childDataSet = new DataSet();
        }
        else
        {
            _childDataSet.Tables.Clear();
        }
        
        if (employeeDS.Tables[0].Rows.Count > 0)
        {
            int count = 0;
            foreach (DataRow employeeRow in employeeDS.Tables[0].Rows)
            {
                count++;
                double salaryAmount = 0;
                HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(employeeRow["EmployeeID"].ToString());
                if (employeeSalary == null)
                {
                    continue;
                }
                if (employeeSalary.IsGross)
                {
                    salaryAmount = Convert.ToDouble( employeeSalary.GrossAmount);
                }
                else
                {
                    salaryAmount =Convert.ToDouble( employeeSalary.BasicAmount);
                }


                double salaryAmountForProvidentFund = salaryAmount;//calculate the PF as whole month according to Moahsin vi
                
                
                //according to joining date we will calcute the salary amount
                if (DateTime.Parse(employeeRow["JoiningDate"].ToString()).Month == int.Parse(ddlMonths.SelectedValue) && DateTime.Parse(employeeRow["JoiningDate"].ToString()).Year == int.Parse(ddlYears.SelectedValue))
                {
                    int noOfDaysInthisMonth = DateTime.DaysInMonth(int.Parse(ddlYears.SelectedValue), int.Parse(ddlMonths.SelectedValue));
                    int noOfDaysWorked = noOfDaysInthisMonth - DateTime.Parse(employeeRow["JoiningDate"].ToString()).Day +1;

                    salaryAmount = double.Parse(((salaryAmount/noOfDaysInthisMonth)*noOfDaysWorked).ToString("00"));
                }

                DataSet employeeSalaryRulesDataSet = HR_EmployeeSalaryRulesManager.GetHR_EmployeeSalaryRulesByEmployeeID(employeeRow["EmployeeID"].ToString());
                if (employeeSalaryRulesDataSet.Tables[0].Rows.Count == 0) continue;
                
                newRow = dtSalaryDetail.NewRow();
                newRow["EmployeeID"] = employeeRow["EmployeeID"].ToString();
                double salaryDiductionAmount =0;
                foreach (AbsendSalaryDiduction item in salaryDiduction)
                {
                    if (item.EmployeeID == employeeRow["EmployeeID"].ToString())
                    {                        
                        salaryDiductionAmount = double.Parse(item.SalaryDeduction.ToString("0"));
                        break;
                    }
                }

                newRow["SalaryDiduction"] = salaryDiductionAmount;

                newRow["EmployeeNo"] = employeeRow["EmployeeNo"].ToString();
                newRow["EmployeeName"] = employeeRow["EmployeeName"].ToString();
                newRow["Designation"] = employeeRow["DesignationName"].ToString();
                newRow["DepartmentName"] = employeeRow["DepartmentName"].ToString();
                newRow["SecurityAmount"] = employeeSalaryRulesDataSet.Tables[0].Rows[0]["SecurityAmount"].ToString();
                double SecurityAmount = double.Parse(newRow["SecurityAmount"].ToString());

                double totalSalary = 0;
                double basicSalaryPFContribution = 0;
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

                        if (row["PackageRulesName"].ToString().Equals("Basic") == true)
                        {
                            basicSalaryPFContribution = (salaryAmountForProvidentFund * (Convert.ToDouble(row["RulesValue"].ToString()) / 100)) * double.Parse(row["PFVlaue"].ToString()) / 100;//(10/100); // Provident Fund= 10% of basic Salary
                        }
                    }
                    totalSalary += calValue;
                }

                string tableName = employeeRow["EmployeeID"].ToString();

                DataTable childTable = new DataTable();
                childTable = employeeSalaryRulesDataSet.Tables[0].Copy();
                childTable.TableName = tableName;

                _childDataSet.Tables.Add(childTable);

                newRow["TotalSalary"] = totalSalary.ToString("N2");
                totalGross += totalSalary;
                newRow["PFAmount"] = basicSalaryPFContribution.ToString("N2");
                
                totalPFAmount += basicSalaryPFContribution;

                DataRow[] advSalaryOfEmp = advanceSalaryTable.Select("EmployeeID='" + employeeRow["EmployeeID"].ToString() + "'");
                if (advSalaryOfEmp.Length == 1)
                {
                    newRow["LoanAmount"] = advSalaryOfEmp[0][1].ToString();
                }
                newRow["GrandTotal"] = (totalSalary - basicSalaryPFContribution - SecurityAmount -salaryDiductionAmount).ToString("N2");
                totalSalaryPayToEmp += (totalSalary - basicSalaryPFContribution - SecurityAmount - salaryDiductionAmount);
               
                if (totalSalary > 0)
                {
                    dtSalaryDetail.Rows.Add(newRow);

                }                      
            }

            gvSalaryDetailBreakdown.DataSource = dtSalaryDetail;
            gvSalaryDetailBreakdown.DataBind();
            if (dtSalaryDetail != null)
            {
                if (dtSalaryDetail.Rows.Count > 0)
                {
                    ((Label)this.gvSalaryDetailBreakdown.FooterRow.FindControl("lblTotalGross")).Text = totalGross.ToString("N2");
                    ((Label)this.gvSalaryDetailBreakdown.FooterRow.FindControl("lblTotalPFAmount")).Text = totalPFAmount.ToString("N2");
                    if (Session["totalLoanDeduction"] != null)
                    {
                        totalLoanDeduction = Convert.ToDouble(Session["totalLoanDeduction"].ToString());
                    }
                    ((Label)this.gvSalaryDetailBreakdown.FooterRow.FindControl("lblTotalLoanDeduction")).Text = totalLoanDeduction.ToString("N2");
                    ((Label)this.gvSalaryDetailBreakdown.FooterRow.FindControl("lblTotalSalaryPayToEmp")).Text = totalSalaryPayToEmp.ToString("N2");
                }
            }
            
            Session.Remove("totalLoanDeduction");
        }
    }

    #endregion Private Methods

    #region Events
    protected void gvSalaryDetailBreakdown_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfEmployID = (HiddenField )e.Row.FindControl("hfEmployID");
            CheckBox checkedBox = (CheckBox)e.Row.FindControl("chkBoxSelect");
            //checkedBox.Checked = true;
            //Label lblDesignation = (Label)e.Row.FindControl("lblDesignation");
            //string designation = HR_DesignationManager.GetHR_DesignationByDesignationID(Convert.ToInt32(lblDesignation.Text)).DesignationName;
            //lblDesignation.Text = designation;
            GridView gvChild = (GridView)e.Row.FindControl("gvSalaryOnly");
            //gvChild.ShowHeader = false;
            gvChild.DataSource = _childDataSet.Tables[hfEmployID.Value];
            gvChild.DataBind();
        }
    }

    protected void btnSalaryProcessDetails_OnClick(object sender, EventArgs e)
    {
        lblMassage.Text = string.Empty;
        if (Request.QueryString["ID"] != null)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
        }
        SalaryDetailBreakdown();
        if (gvSalaryDetailBreakdown.Rows.Count > 0)
        {
            btnPost.Visible = true;
            btnSelaryPreview.Visible = true;
        }
        else
        {
            btnPost.Visible = false;
            btnSelaryPreview.Visible = false;
            lblMassage.Text = "For this month salary is already processed.";
            lblMassage.ForeColor = System.Drawing.Color.Green;
        }
        UpdatePanel1.Update();
    }

    protected void gvSalaryDetailBreakdown_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        
    }  

    protected void txtLoanDeduction_OnTextChanged(object sender, EventArgs e)
    {
        double totalLoanDeduction = 0;        
        string deductionAmount = ((TextBox)sender).Text;                
        foreach (GridViewRow row in gvSalaryDetailBreakdown.Rows)
        {
            Label lblLoanAmount = (Label)row.FindControl("lblLoanAmount");
            if (lblLoanAmount != null)
            {
                if (Convert.ToDouble(lblLoanAmount.Text.Trim() == string.Empty ? "0" : lblLoanAmount.Text.Trim()) > 0)
                {
                    HiddenField hfEmployID = (HiddenField)row.FindControl("hfEmployID");
                    Label lblTotalSalary = (Label)row.FindControl("lblTotalSalary");
                    Label lblPFAmount = (Label)row.FindControl("lblPFAmount");

                    TextBox txtLoanDed = (TextBox)row.FindControl("txtLoanDeduction");
                    Label lbGrandTotal = (Label)row.FindControl("lblGrandTotal");

                    double salaryTotal = Convert.ToDouble(lblTotalSalary.Text.Trim() == string.Empty ? "0" : lblTotalSalary.Text.Trim());
                    double pfAmount = Convert.ToDouble(lblPFAmount.Text.Trim() == string.Empty ? "0" : lblPFAmount.Text.Trim());
                    double loanDed = Convert.ToDouble(txtLoanDed.Text.Trim() == string.Empty ? "0" : txtLoanDed.Text.Trim());
                    double grandTotal = 0;
                    grandTotal = salaryTotal - pfAmount;
                    if (loanDed > grandTotal)
                    {
                        loanDed = 0;
                        txtLoanDed.Text = "0";
                    }
                    else
                    {                        
                        grandTotal = salaryTotal - pfAmount - loanDed;
                        lbGrandTotal.Text = grandTotal.ToString();
                        totalLoanDeduction += loanDed;
                    }
                }
                else
                {
                    TextBox txtLoanDed = (TextBox)row.FindControl("txtLoanDeduction");
                    txtLoanDed.Text = "0";
                    //deductionAmount.
                }
            }
        }
        Session["totalLoanDeduction"] = totalLoanDeduction;
    }    

    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            int newEntry = 0;
            int prevEntry = 0;

            
            string userID = Profile.card_id;
           
            List<string> newPostings = new List<string>();
            List<string> prevPostings = new List<string>();
            foreach (GridViewRow row in gvSalaryDetailBreakdown.Rows)
            {
                CheckBox chkBox = (CheckBox)row.FindControl("chkBoxSelect");
                if (chkBox.Checked)
                {
                    HiddenField hfEmployID = (HiddenField)row.FindControl("hfEmployID");
                    Label lblTotalSalary = (Label)row.FindControl("lblTotalSalary");
                    Label lblEmployeeName = (Label)row.FindControl("lblEmployeeName");
                    Label lblPFAmount = (Label)row.FindControl("lblPFAmount");
                    Label lblSecurityAmount = (Label)row.FindControl("lblSecurityAmount");
                    GridView gridViewSalaryBreakdown = (GridView)row.FindControl("gvSalaryOnly");

                    TextBox txtLoanDeduction = (TextBox)row.FindControl("txtLoanDeduction");
                    Label lbGrandTotal = (Label)row.FindControl("lblGrandTotal");

                    ACC_EmployPayRoleSalary paySalary = new ACC_EmployPayRoleSalary();
                    paySalary.AddedBy = userID;
                    paySalary.AddedDate = DateTime.Now;
                    paySalary.UpdatedBy = userID;
                    paySalary.UpdatedDate = DateTime.Now;
                    paySalary.EmployeeID = hfEmployID.Value;
                    paySalary.SalaryAmount = Convert.ToDecimal(lbGrandTotal.Text);
                    paySalary.PaidSalaryAmount = Convert.ToDecimal("0");
                    paySalary.UnpaidSalaryAmount = Convert.ToDecimal(lbGrandTotal.Text);
                    paySalary.Status = 1;
                    paySalary.RowStatusID = 1;
                    paySalary.SalaryOfDate = ddlMonths.SelectedItem.Text + ", " + ddlYears.SelectedValue;

                    string salBreakDownHistory = string.Empty;
                    foreach (GridViewRow salBreakRow in gridViewSalaryBreakdown.Rows)
                    {
                        Label lblDescription = (Label)salBreakRow.FindControl("lblDescription");
                        Label lblSalaryValue = (Label)salBreakRow.FindControl("lblSalaryValue");
                        salBreakDownHistory += lblDescription.Text + ":" + lblSalaryValue.Text+";";
                    }
                    paySalary.ExtraField1 = salBreakDownHistory;
                    paySalary.ExtraField2 = lblTotalSalary.Text.Trim();
                    paySalary.ExtraField3 = string.Empty;
                    paySalary.ExtraField4 = string.Empty;
                    paySalary.ExtraField5 = string.Empty;
                    paySalary.ExtraField6 = string.Empty;
                    paySalary.ExtraField7 = string.Empty;
                    paySalary.ExtraField8 = Convert.ToDecimal(lbGrandTotal.Text).ToString("0.0");
                    paySalary.ExtraField9 = string.Empty;
                    paySalary.ExtraField10 = string.Empty;

                    int insertedID = ACC_EmployPayRoleSalaryManager.InsertEmployPayRoleSalary(paySalary);
                    if (insertedID > 0)
                    {
                        List<HR_ProvidentFundRegister> providentFundRegisterColl = new List<HR_ProvidentFundRegister>();
                        HR_ProvidentFundRegister pfRegister = new HR_ProvidentFundRegister();
                        pfRegister.EmployeeID = hfEmployID.Value;
                        pfRegister.ExtraField1 = insertedID.ToString();
                        pfRegister.PayrollMonthDate = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(ddlYears.SelectedValue), Convert.ToInt32(ddlMonths.SelectedValue)) + " " + ddlMonths.SelectedItem.Text + " " + ddlYears.SelectedValue);
                        pfRegister.EPF = Convert.ToDecimal(lblPFAmount.Text);
                        pfRegister.CPF = Convert.ToDecimal(lblPFAmount.Text);
                        pfRegister.ExtraField2 = paySalary.ExtraField8;
                        pfRegister.TotalPFAmount = pfRegister.EPF + pfRegister.CPF;
                        //pfRegister.WithdrawLastDate = Nullable<DateTime>;
                        pfRegister.AddedBy = userID;
                        pfRegister.AddedDate = DateTime.Now;
                        pfRegister.RowStatusID = 1;
                        providentFundRegisterColl.Add(pfRegister);
                        HR_ProvidentFundRegisterManager.InsertHR_ProvidentFundRegister(providentFundRegisterColl);
                        providentFundRegisterColl.Clear();

                        if (Convert.ToDecimal(lblPFAmount.Text) != 0)
                        {
                            ACC_Journal pfACC_Journal = new ACC_Journal();
                            pfACC_Journal.UserID = hfEmployID.Value;
                            pfACC_Journal.Balance = Convert.ToDecimal(lblPFAmount.Text);
                            pfACC_Journal.AddedBy = userID;
                            pfACC_Journal.AddedDate = DateTime.Now;
                            pfACC_Journal.UpdatedBy = userID;
                            pfACC_Journal.UpdateDate = DateTime.Now;
                            pfACC_Journal.EmployPayRoleSalaryID = insertedID;
                            ACC_AccountingCommonManager.ProcessACC_ProvidentFund(hfEmployID.Value, pfACC_Journal);
                        }

                        if (Convert.ToDecimal(lblSecurityAmount.Text) != 0)
                        {
                            ACC_Journal pfACC_Journal = new ACC_Journal();
                            pfACC_Journal.UserID = hfEmployID.Value;
                            pfACC_Journal.Balance = Convert.ToDecimal(lblSecurityAmount.Text);
                            pfACC_Journal.AddedBy = userID;
                            pfACC_Journal.AddedDate = DateTime.Now;
                            pfACC_Journal.UpdatedBy = userID;
                            pfACC_Journal.UpdateDate = DateTime.Now;
                            pfACC_Journal.EmployPayRoleSalaryID = insertedID;
                            ACC_AccountingCommonManager.ProcessACC_SecurityAmount(hfEmployID.Value, pfACC_Journal);
                        }


                        if (txtLoanDeduction.Text.Trim() != string.Empty)
                        {
                            ACC_Journal advSalaryACC_Journal = new ACC_Journal();
                            advSalaryACC_Journal.UserID = hfEmployID.Value;
                            advSalaryACC_Journal.Balance = Convert.ToDecimal(txtLoanDeduction.Text);
                            advSalaryACC_Journal.AddedBy = userID;
                            advSalaryACC_Journal.AddedDate = DateTime.Now;
                            advSalaryACC_Journal.UpdatedBy = userID;
                            advSalaryACC_Journal.UpdateDate = DateTime.Now;
                            advSalaryACC_Journal.SalaryOfDate = paySalary.SalaryOfDate;
                            ACC_AccountingCommonManager.ProcessACC_AdvanceSalary(hfEmployID.Value, advSalaryACC_Journal);
                        }

                        newEntry++;
                        //"<td>" + hfEmployID.Value + "</td>"
                        newPostings.Add("<td>" + lblEmployeeName.Text + "</td>");
                    }
                    else
                    {
                        prevEntry++;
                        //<td>" + hfEmployID.Value + "</td>
                        prevPostings.Add("<td>" + lblEmployeeName.Text + "</td>");
                    }
                }
            }
            

            litSummary.Text = "<table style=\"width:50%;float:left;\"><tr><td style=\"color:Green;font-weight:bold;\">New Postings</td></tr>";
            foreach (string entity in newPostings)
            {
                litSummary.Text += "<tr>"+entity+"</tr>";
            }
            if (newPostings.Count == 0)
                litSummary.Text += "<td>No New Postings</td>";
            litSummary.Text += "</table>";

            litSummary.Text += "<table style=\"width:50%;float:left;\"><tr><td style=\"color:Green;font-weight:bold;\">Posted Before</td></tr>";
            foreach (string entity in prevPostings)
            {
                litSummary.Text += "<tr>" + entity + "</tr>";
            }
            if (prevPostings.Count == 0)
                litSummary.Text += "<td>No Old Postings</td>";
            litSummary.Text += "</table>";
            string scriptText = "alert('New Entry : " + newEntry.ToString() + " Old Entry : " + prevEntry.ToString() + "');";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Summary", scriptText, true);
        }
        catch (Exception ex)
        {
            if (ex != null)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Error", ex.Message, true);
            }
        }
    }
    #endregion Events
    protected void btnSelaryPreview_OnClick(object sender, EventArgs e)
    {
        
        DataTable tblSalaryDetails = new DataTable();
        
        tblSalaryDetails.Columns.Add("EmployeeName");
        tblSalaryDetails.Columns.Add("GrossSalary");
        tblSalaryDetails.Columns.Add("PFAmount");
        tblSalaryDetails.Columns.Add("SecurityAmount");

        tblSalaryDetails.Columns.Add("DepartmentName");
        tblSalaryDetails.Columns.Add("AdvenceSalary");
        tblSalaryDetails.Columns.Add("GrandTotal");

        string totalpackeges = "";

        foreach (GridViewRow row in gvSalaryDetailBreakdown.Rows)
        {
            CheckBox chkBoxSelect = (CheckBox)row.FindControl("chkBoxSelect");

            if (chkBoxSelect.Checked)
            {
                

                DataRow newRow = tblSalaryDetails.NewRow();
               
                Label lblEmployeeName = (Label)row.FindControl("lblEmployeeName");

                Label lblTotalSalary = (Label)row.FindControl("lblTotalSalary");

                Label lblPFAmount = (Label)row.FindControl("lblPFAmount");
                Label lblSecurityAmount = (Label)row.FindControl("lblSecurityAmount");
                Label lblLoanAmount = (Label)row.FindControl("lblLoanAmount");
                Label lblGrandTotal = (Label)row.FindControl("lblGrandTotal");
                Label lblDepartmentName = (Label)row.FindControl("lblDepartmentName");


                newRow["DepartmentName"] = lblDepartmentName.Text;
                newRow["EmployeeName"] = lblEmployeeName.Text;
                newRow["GrossSalary"] = lblTotalSalary.Text;
                newRow["PFAmount"] = lblPFAmount.Text;
                newRow["SecurityAmount"] = lblSecurityAmount.Text;
                newRow["AdvenceSalary"] = lblLoanAmount.Text;
                newRow["GrandTotal"] = lblGrandTotal.Text;

                tblSalaryDetails.Rows.Add(newRow);

                GridView gvSalaryOnly = (GridView)row.FindControl("gvSalaryOnly");

               
                string packeges = "";

                foreach (GridViewRow sr in gvSalaryOnly.Rows)
                {
                   
                    HR_PackageRules packageRule = new HR_PackageRules();

                    Label lblDescription = (Label)sr.FindControl("lblDescription");
                    Label lblSalaryValue = (Label)sr.FindControl("lblSalaryValue");
                    
                    packeges += lblSalaryValue.Text + " ";
                  
                }
                totalpackeges +=packeges+",";
                packeges = "";
              
            }
        }

        string monthYear = ddlMonths.SelectedItem.Text +" "+ "-" +" "+ ddlYears.SelectedItem.Text;
        Session["Date"] = monthYear;
        Session["packeges"] = totalpackeges;
        Session["salaryDetails"] = tblSalaryDetails;

        if (Session["packeges"] != null && Session["salaryDetails"] != null)
        {
            Response.Redirect("SalaryStatement.aspx");
        }
    }
    protected void btnExtraSalary_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlExployeeID.SelectedIndex != 0 && ddlSalaryOfMonth.SelectedIndex != 0)
            {
                ACC_EmployPayRoleSalary employeePayRoleSalay = new ACC_EmployPayRoleSalary();
                employeePayRoleSalay = ACC_EmployPayRoleSalaryManager.GetEmployPayRoleSalaryByEmployeeIDnSalaryOfDate(ddlSalaryOfMonth.SelectedValue, ddlExployeeID.SelectedValue);

                employeePayRoleSalay.SalaryAmount = employeePayRoleSalay.SalaryAmount + decimal.Parse(txtExtraSalary.Text);
                employeePayRoleSalay.UnpaidSalaryAmount = employeePayRoleSalay.UnpaidSalaryAmount + decimal.Parse(txtExtraSalary.Text);
                employeePayRoleSalay.ExtraField1 += "Extra:" + txtExtraSalary.Text;
                employeePayRoleSalay.ExtraField2 = (decimal.Parse(employeePayRoleSalay.ExtraField2) + decimal.Parse(txtExtraSalary.Text)).ToString();
                employeePayRoleSalay.Status = 36;
                ACC_EmployPayRoleSalaryManager.UpdateEmployPayRoleSalary(employeePayRoleSalay);
            }
        }
        catch (Exception ex)
        { 
        }
        
    }
}
