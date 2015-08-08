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
public partial class AdminHR_ProvidentFundProvisionProcess : System.Web.UI.Page
{
    private static DataSet _childDataSet = null;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {            
           
        }
    }    

    #region Events   

    protected void btnPFProvision_OnClick(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        table.Columns.Add("EmployeeNo");
        table.Columns.Add("EmployeeName");
        table.Columns.Add("ServiceLength");
        table.Columns.Add("EPF");
        table.Columns.Add("CPF");
        table.Columns.Add("TotalAmount");
        table.Columns.Add("OwnerOfFund");

        DataSet empDataSet = HR_EmployeeManager.GetAllHR_EmpNoNameJoiningDate();
        List<HR_ProvidentFundSetup> providentFundSetupColl = HR_ProvidentFundSetupManager.GetHR_ProvidentFundSetupColl();
        decimal totalProvisionFund = 0;
        if (empDataSet != null)
        {
            if (empDataSet.Tables.Count > 0)
            {
                foreach (DataRow rowEmp in empDataSet.Tables[0].Rows)
                {
                    decimal provisionFund = 0;

                    DateTime joiningDate = Convert.ToDateTime(rowEmp["JoiningDate"]);
                    DateTime today = DateTime.Today;
                    TimeSpan totalTS = today.Subtract(joiningDate);
                    int totalDay = totalTS.Days;
                    int totalYear = totalDay / 365;
                    totalDay = totalDay % 365;
                    int totalMonth = totalDay / 30;
                    totalDay = totalDay % 30;
                    int andDay = totalDay;
                    string serviceLength =  totalYear.ToString() + " year(s) " + totalMonth.ToString() + " month(s) ";

                    DataSet totalFund = HR_ProvidentFundRegisterManager.GetHR_PFRegisterByEmpIDTotalFund(rowEmp["EmployeeID"].ToString());
                    decimal epfAmount = 0;
                    decimal cpfAmount = 0;
                    decimal totalAmount = 0;
                    decimal withdrawAmount = 0;
                    if (totalFund != null)
                    {
                        if (totalFund.Tables[0].Rows.Count > 0)
                        {
                            DataTable tableTotalFund = totalFund.Tables[0];
                            foreach (DataRow row1 in totalFund.Tables[0].Rows)
                            {
                                if (row1["EPF"] != DBNull.Value)
                                {
                                    epfAmount = Convert.ToDecimal(row1["EPF"]);
                                    //epfAmount = Convert.ToDecimal(row1["EPF"] == null ? "0" : row1["EPF"].ToString());
                                    cpfAmount = Convert.ToDecimal(row1["CPF"]);
                                    totalAmount = Convert.ToDecimal(row1["TotalPFAmount"]);
                                }
                            }
                        }
                    }
                    foreach (HR_ProvidentFundSetup pfSetup in providentFundSetupColl)
                    {
                        if (totalYear > pfSetup.ServiceLenStartYear && totalYear <= pfSetup.ServiceLenEndYear)
                        {
                            if (pfSetup.FundTypeID == 1)  // EPF = 1
                            {
                                provisionFund += epfAmount * ((decimal)pfSetup.FundPercentForEmp / 100);
                            }
                            else
                            {
                                provisionFund += cpfAmount * ((decimal)pfSetup.FundPercentForEmp / 100);
                            }
                        }
                    }
                    totalProvisionFund += provisionFund;
                    if (provisionFund > 0)
                    {
                        DataRow tableRow = table.NewRow();
                        tableRow["EmployeeNo"] = rowEmp["EmployeeNo"].ToString();
                        tableRow["EmployeeName"] = rowEmp["EmployeeName"].ToString();
                        tableRow["ServiceLength"] = serviceLength;
                        tableRow["EPF"] = epfAmount.ToString("N2"); 
                        tableRow["CPF"] = cpfAmount.ToString("N2");
                        tableRow["TotalAmount"] = totalAmount.ToString("N2");
                        tableRow["OwnerOfFund"] = provisionFund.ToString("N2");
                        table.Rows.Add(tableRow);
                    }
                }
            }
        }
        gvPFProvision.DataSource = table;
        gvPFProvision.DataBind();
        //        ((Label)this.gvSalaryDetailBreakdown.FooterRow.FindControl("lblTotalGross")).Text = totalGross.ToString("N2");
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                Label lbProvision = ((Label)this.gvPFProvision.FooterRow.FindControl("lblPFProvisionAmount"));
                //((Label)this.gvPFProvision.FooterRow.FindControl("lblPFProvisionAmount")).Text = totalProvisionFund.ToString("N2");
                lbProvision.Text = totalProvisionFund.ToString("N2");
                //lbProvision.Style.Value = "TextAlign:Right";
                //((Label)this.gvPFProvision.FooterRow.FindControl("lblPFProvisionAmount")).Style = 
            }
        }
    }   
         
    #endregion Events
   
}
