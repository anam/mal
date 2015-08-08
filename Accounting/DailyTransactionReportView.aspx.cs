using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Accounting_DailyTransactionReportView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now;
        try
        {
            startDate = DateTime.Parse(String.Format("{0:MM-dd-yyyy}", DateTime.Now.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()))) + " 12:00:00 AM");
            endDate = DateTime.Parse(String.Format("{0:MM-dd-yyyy}", DateTime.Now.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString()))) + " 11:59:59 PM");
        }
        catch (Exception ex)
        { 
        }

        string UserID = "";
        
        if (Request.QueryString["startDate"] != null && Request.QueryString["endDate"] != null)
        {
            startDate = Convert.ToDateTime(Request.QueryString["startDate"]);
            endDate = Convert.ToDateTime(Request.QueryString["endDate"]);
            UserID= Request.QueryString["UserID"]== null?"": Request.QueryString["UserID"];            
        }

        ltDailyTransaction.Text = getDailyTransactionReport(startDate, endDate, UserID);
    }


    /*
     List<ACC_Journal> lBankDeposit = new List<ACC_Journal>();
            List<ACC_Journal> lBankWithdrow = new List<ACC_Journal>();
            List<ACC_Journal> lOtherAsset = new List<ACC_Journal>();
     */
    public  string loadTable(List<ACC_Journal> lIncome, List<ACC_Journal> lExpence, List<ACC_Journal> lOpening, List<ACC_Journal> lClosing, List<ACC_Journal> lOpeningBankBalance, List<ACC_Journal> lClosingBankBalance, string userID)
    {
        decimal credit = 0, debit = 0;
        string htmlCode = "<table border='1' cellspacing='0' style='width:100%; font-size:13px; float:left'>";

        htmlCode += " <colgroup>";
        htmlCode += "<col width=7%" + "/>";
        htmlCode += "<col width='31%'" + "/>";
        htmlCode += "<col width=2%" + "/>";
        htmlCode += "<col width=7%" + "/>";
        htmlCode += "<col width='31%'" + "/>";
        htmlCode += "<col width=2%" + "/>";
        htmlCode += " </colgroup>";


        //htmlCode += "<tr><td colspan='3' style='text-align:center'>Debit</td><td colspan='3' style='text-align:center'>Credit</td></tr>";
        //htmlCode += "<tr><td>Date</td><td>Particulars</td><td>Amount</td><td>Date</td><td>Particulars</td><td>Amount</td></tr>";


        htmlCode += "<tr  bgcolor='#F0f0f0' bordercolor='#000000' style='font-weight: bold;'><td colspan='3'  style='text-align:center'>Debit</td><td colspan='3'  style='text-align:center'>Credit</td></tr>";
        htmlCode += "<tr  bgcolor='#F0f0f0' bordercolor='#000000' style='font-weight: bold;'><td>Date</td><td>Particulars</td><td>Amount</td><td>Date</td><td>Particulars</td><td>Amount</td></tr>";

        int totalRow = 0;

        //bank deposit will be considered as expence and bankWithdraw considered as income

        // Cash in hand and Check in hand
        
        if (lIncome.Count >= lExpence.Count)
        {
            totalRow = lIncome.Count;
        }
        else
        {
            totalRow = lExpence.Count;
        }


        //Opening balance
        decimal totalOpeningBalance = 0;
        decimal totalOpeningBalanceCash = 0;
        decimal totalOpeningBalanceCheck = 0;

        for (int row = 0; row < lOpening.Count; row++)
        {
            if (lOpening[row].AccountID != 2 && lOpening[row].Balance != decimal.Parse("0"))
            {
                if (lOpening[row].AccountID == 1)
                {
                    totalOpeningBalanceCash += Convert.ToDecimal(lOpening[row].Balance);
                }
                else
                {
                    totalOpeningBalanceCheck += Convert.ToDecimal(lOpening[row].Balance);
                }
                htmlCode += "<tr  bordercolor='#000000'><td>";
                //htmlCode += lOpening[row].AddedDate.ToString("dd MMM, yyyy");
                htmlCode += "</td>";

                htmlCode += "<td>";
                htmlCode += lOpening[row].HeadName;
                htmlCode += "</td>";
                
                htmlCode += "<td style='text-align:right;'>";
                htmlCode += lOpening[row].Balance.ToString("0,0");
                htmlCode += "</td>";

                totalOpeningBalance += Convert.ToDecimal(lOpening[row].Balance);

                credit += Convert.ToDecimal(lOpening[row].Balance);

                htmlCode += "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";
            }            
        }


        #region Opening balance
        string openingbalanceString = @"<table width='650' cellspacing='0' cellpadding='1' border='0' align='center'>
	                                        <tbody><tr>
		                                        <td align='left'>
			                                        <font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bolder;text-decoration:underline'><strong>Opening Balance:</strong></font>
		                                        </td>
		                                        <td width='200' align='center'>&nbsp;
			
		                                        </td>
		                                        <td width='200' align='right'>
			                                        <font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bolder;text-decoration:underline'>Amount (TK.)</font>
		                                        </td>
	                                        </tr>
                                            <tr>
		                                        <td align='left' colspan='3' >
			                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bold;text-decoration:underline'><strong>Cash at Bank :</strong></font>
		                                        </td>
	                                        </tr>";
        decimal openingBankBalance = 0;
        
        for (int row = 0; row < lOpeningBankBalance.Count; row++)
        {
            if (Convert.ToDecimal(lOpeningBankBalance[row].Balance) != Convert.ToDecimal("0"))
            {
                openingbalanceString += "<tr>";
                openingbalanceString += "<td align='left'>";
                openingbalanceString += "    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>" + lOpeningBankBalance[row].HeadName.Replace("Cash at Bank", "") + "</font>";
                openingbalanceString += "</td>";
                openingbalanceString += "<td align='right'>";

                openingbalanceString += "</td>";
                openingbalanceString += "<td align='right'>";
                openingbalanceString += "<font size='2' face='Arial, Helvetica, sans-serif'>" + Convert.ToDecimal(lOpeningBankBalance[row].Balance).ToString("0,0.00") + "</font>";
                openingbalanceString += "</td>";
                openingbalanceString += "    </tr>";

                openingBankBalance += Convert.ToDecimal(lOpeningBankBalance[row].Balance);
            }
           
        }


        //bank
        openingbalanceString += @"<tr>
		                            <td align='left' style='border-top: medium solid;border-bottom: medium solid;'>&nbsp;
			                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Total Cash at Bank</font>
		                            </td>
		                            <td align='right' style='border-top: medium solid;border-bottom: medium solid;'>&nbsp;
			
		                            </td>
		                            <td align='right' style='border-top: medium solid;border-bottom: medium solid;'>
			                            <font size='2' face='Arial, Helvetica, sans-serif'>";
         openingbalanceString += openingBankBalance.ToString("0,0.00")+"</font></td></tr>";

        //Cash
         openingbalanceString += @"<tr>
		                            <td align='left' >
			                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Cash  in Hand</font>
		                            </td>
		                            <td align='right'>&nbsp;
			
		                            </td>
				                            <td align='right'>
			                            <font size='2' face='Arial, Helvetica, sans-serif'>";
         openingbalanceString += totalOpeningBalanceCash.ToString("0,0.00") + "</font></td></tr>";
         
        //Check
         openingbalanceString += @"<tr >
		                            <td align='left'>
			                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Check in Hand</font>
		                            </td>
		                            <td align='right'>&nbsp;
			
		                            </td>
				                            <td align='right' >
			                            <font size='2' face='Arial, Helvetica, sans-serif'>";
         openingbalanceString += totalOpeningBalanceCheck.ToString("0,0.00") + "</font></td></tr>";

         //total Cash and check
         openingbalanceString += @"<tr>
		                            <td align='left' style='border-top: medium solid;border-bottom: medium solid;'>&nbsp;
			                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Total Cash/Check in hand</font>
		                            </td>
		                            <td align='right' style='border-top: medium solid;border-bottom: medium solid;'>&nbsp;
			
		                            </td>
		                            <td align='right' style='border-top: medium solid;border-bottom: medium solid;'>
			                            <font size='2' face='Arial, Helvetica, sans-serif'>";
         openingbalanceString += totalOpeningBalance.ToString("0,0.00") + "</font></td></tr>";


        //total opening balance
         openingbalanceString += @" <tr>
		                                <td align='left'  style='border-bottom: medium solid;'>&nbsp;
			                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Opening Balance
		                                </td>
		                                <td align='right' style='border-bottom: medium solid;'>&nbsp;
			
		                                </td>
		                                <td align='right' style='border-bottom: medium solid;'>
			                                <strong><font size='2' face='Arial, Helvetica, sans-serif'>";

         openingbalanceString += (totalOpeningBalanceCash + totalOpeningBalanceCheck + openingBankBalance).ToString("0,0.00") + "</font></strong></td></tr>";


         /*
          <table width='650' cellspacing='0' cellpadding='1' border='0' align='center'>
     <tbody><tr>
         <td align='left'>
             <font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bolder;text-decoration:underline'><strong>Opening Balance:</strong></font>
         </td>
         <td width='200' align='center'>&nbsp;
			
         </td>
         <td width='200' align='right'>
             <font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bolder;text-decoration:underline'>Amount (TK.)</font>
         </td>
     </tr>
     <tr>
         <td align='left' colspan='3'>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bold;text-decoration:underline'><strong>Cash at Bank :</strong></font>
         </td>
     </tr>
         <tr>
                 <td align='left'>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Brac Bank</font>
         </td>
         <td align='right'>
			
         </td>
         <td align='right'>
             <font size='1' face='Arial, Helvetica, sans-serif'>3,784,614.00</font>
         </td>
             </tr>
         <tr>
                 <td align='left' style='border-bottom: medium solid;'>
             <font size='1' face='Arial, Helvetica, sans-serif'>Dhaka Bank</font>
         </td>
         <td align='right' style='border-bottom: medium solid;'>
			
         </td>
         <td align='right' style='border-bottom: medium solid;'>
             <font size='1' face='Arial, Helvetica, sans-serif'>5,000.00</font>
         </td>
             </tr>
         <tr>
         <td align='left'>&nbsp;
			
         </td>
         <td align='right'>&nbsp;
			
         </td>
         <td align='right'>
             <font size='2' face='Arial, Helvetica, sans-serif'>3,789,614.00</font>
         </td>
     </tr>
     <tr>
         <td align='left' style='border-bottom: medium solid;'>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Cash in Hand</font>
         </td>
         <td align='right' style='border-bottom: medium solid;'>&nbsp;
			
         </td>
                 <td align='right' style='border-bottom: medium solid;'>
             <font size='2' face='Arial, Helvetica, sans-serif'>6,100.00</font>
         </td>
     </tr>
     <tr>
         <td align='left' style='border-bottom: medium solid;'>&nbsp;
			
         </td>
         <td align='right' style='border-bottom: medium solid;'>&nbsp;
			
         </td>
         <td align='right' style='border-bottom: medium solid;'>
             <strong><font size='2' face='Arial, Helvetica, sans-serif'>3,795,714.00</font></strong>
         </td>
     </tr>
     <tr> <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
 </tbody></table>
          */


        #endregion
         htmlCode = openingbalanceString + "<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr></tbody></table>" + htmlCode;

        //htmlCode += "<tr bgcolor='#F0f0f0' bordercolor='#000000'><td>&nbsp;</td><td style='font-weight:bold'>Total Opening Balance b/f<br/>(Cash in hand)</td><td style='text-align:right;'>" + totalOpeningBalanceCash.ToString("0,0") + "</td>";
        //htmlCode += "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";

        //htmlCode += "<tr bgcolor='#F0f0f0' bordercolor='#000000'><td>&nbsp;</td><td style='font-weight:bold'>Total Opening Balance b/f<br/>(Check in hand)</td><td style='text-align:right;'>" + totalOpeningBalanceCheck.ToString("0,0") + "</td>";
        //htmlCode += "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";

        htmlCode += "<tr bgcolor='#F0f0f0' bordercolor='#000000'><td>&nbsp;</td><td style='font-weight:bold'>Total Opening Balance b/f</td><td style='text-align:right;'>" + totalOpeningBalance.ToString("0,0") + "</td>";
        htmlCode += "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";


        htmlCode += "<tr bordercolor='#000000'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";
        htmlCode += "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";

        //Daily Transactions excluding the opining and closing balance
        for (int row = 0; row < totalRow; row++)
        {
            if (lIncome.Count > row)
            {
                if (lIncome[row].HeadName.Contains("Cash at Bank"))
                {
                    lIncome[row].HeadName = lIncome[row].HeadName.Replace("Cash at Bank", "Bank Withdraw");
                }

                htmlCode += "<tr  bordercolor='#000000'><td>";
                if (!this.Page.User.IsInRole("SuperAdmin") &&  !this.Page.User.IsInRole("SoftwareEngineer"))
                {
                    htmlCode += lIncome[row].AddedDate.ToString("dd MMM, yyyy");
                }
                else
                {
                    htmlCode += "<a href='JournalDoubleEntryCommonEdit.aspx?JournalMasterID=" + lIncome[row].JournalMasterID.ToString() + "' target='_blank'>" + lIncome[row].AddedDate.ToString("dd MMM, yyyy") + "</a>";
                }
                htmlCode += "</td>";

                htmlCode += "<td>";
                htmlCode += lIncome[row].HeadName;
                htmlCode+="</td>";
                htmlCode+="<td style='text-align:right;'>";
                htmlCode += lIncome[row].Credit.ToString("0,0");
                htmlCode+="</td>";
                credit += Convert.ToDecimal(lIncome[row].Credit);
            }
            else
            {
                htmlCode += "<tr  bordercolor='#000000'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";
            }

            if (lExpence.Count > row)
            {
                if (lExpence[row].HeadName.Contains("Cash at Bank"))
                {
                    lExpence[row].HeadName = lExpence[row].HeadName.Replace("Cash at Bank", "Bank Deposit");
                }
                else
                if (lExpence[row].HeadName.Contains("Bank Withdraw"))
                {
                    lExpence[row].HeadName = lExpence[row].HeadName.Replace("Bank Withdraw", "Bank Deposit");
                }

                htmlCode += "<td>";
                htmlCode += "<a href='JournalDoubleEntryCommonEdit.aspx?JournalMasterID=" + lExpence[row].JournalMasterID.ToString() + "' target='_blank'>" + lExpence[row].AddedDate.ToString("dd MMM, yyyy") + "</a>";
                htmlCode += "</td>";

                htmlCode += "<td>";
                htmlCode += lExpence[row].HeadName;
                htmlCode += "</td>";
                htmlCode += "<td style='text-align:right;'>";
                htmlCode += lExpence[row].Debit.ToString("0,0");
                htmlCode += "</td></tr>";

                debit += Convert.ToDecimal(lExpence[row].Debit);
            }
            else
            {
                htmlCode += "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";
            }
        }

        htmlCode += "<tr bordercolor='#000000'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";
        htmlCode += "<td  bordercolor='#000000'>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";

        decimal totalClosingBalance = 0;
        //Opening balance
        decimal totalClosingBalanceCash = 0;
        decimal totalClosingBalanceCheck = 0;

        for (int row = 0; row < lClosing.Count; row++)
        {
            if (lClosing[row].AccountID != 2 && lClosing[row].Balance != decimal.Parse("0"))
            {
                if (lClosing[row].AccountID == 1)
                {
                    totalClosingBalanceCash += Convert.ToDecimal(lClosing[row].Balance);
                }
                else
                {
                    totalClosingBalanceCheck += Convert.ToDecimal(lClosing[row].Balance);
                }
                htmlCode += "<tr bordercolor='#000000'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";

                htmlCode += "<td>";
                //htmlCode += lClosing[row].AddedDate.ToString("dd MMM, yyyy");
                htmlCode += "</td>";

                htmlCode += "<td>";
                htmlCode += lClosing[row].HeadName;
                htmlCode += "</td>";

                htmlCode += "<td style='text-align:right;'>";
                htmlCode += lClosing[row].Balance.ToString("0,0");
                htmlCode += "</td></tr>";
                totalClosingBalance += Convert.ToDecimal(lClosing[row].Balance);
                debit += Convert.ToDecimal(lClosing[row].Balance);
            }
        }



        //htmlCode += "<tr  bgcolor='#F0f0f0' bordercolor='#000000'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";
        //htmlCode += "<td>&nbsp;</td><td style='font-weight:bold'>Total Closing Balance b/f<br/>(Cash in hand)</td><td style='text-align:right;'>" + totalClosingBalanceCash.ToString("0,0") + "</td></tr>";

        //htmlCode += "<tr  bgcolor='#F0f0f0' bordercolor='#000000'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";
        //htmlCode += "<td>&nbsp;</td><td style='font-weight:bold'>Total Closing Balance b/f<br/>(Check in hand)</td><td style='text-align:right;'>" + totalClosingBalanceCheck.ToString("0,0") + "</td></tr>";

        htmlCode += "<tr  bgcolor='#F0f0f0' bordercolor='#000000'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";
        htmlCode += "<td>&nbsp;</td><td style='font-weight:bold'>Total Closing Balance b/f</td><td style='text-align:right;'>" + totalClosingBalance.ToString("0,0") + "</td></tr>";



        htmlCode += "<tr   bordercolor='#000000'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";
        htmlCode += "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";

        htmlCode += "<tr  bgcolor='#F0f0f0' bordercolor='#000000'>";
        htmlCode += "<td align=center colspan=2>";
        htmlCode += "Total";
        htmlCode += "</td>";

        htmlCode += "<td style='text-align:right;'>";
        htmlCode += credit.ToString("0,0");
        htmlCode += "</td>";
        htmlCode += "<td align=center colspan=2>";
        htmlCode += "Total";
        htmlCode += "</td>";
        htmlCode += "<td style='text-align:right;'>";
        htmlCode += debit.ToString("0,0");
        htmlCode += "</td>";
        htmlCode += "</tr>";

        htmlCode += "</table>";

        #region Closing balance
        string closingBalanceString = @"<table width='650' cellspacing='0' cellpadding='1' border='0' align='center'>
	                                        <tbody><tr>
		                                        <td align='left'>
			                                        <font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bolder;text-decoration:underline'><strong>Closing Balance:</strong></font>
		                                        </td>
		                                        <td width='200' align='center'>&nbsp;
			
		                                        </td>
		                                        <td width='200' align='right'>
			                                        <font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bolder;text-decoration:underline'>Amount (TK.)</font>
		                                        </td>
	                                        </tr>
                                            <tr>
		                                        <td align='left' colspan='3' >
			                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bold;text-decoration:underline'><strong>Cash at Bank :</strong></font>
		                                        </td>
	                                        </tr>";
        decimal ClosingBankBalance = 0;

        for (int row = 0; row < lClosingBankBalance.Count; row++)
        {
            if (Convert.ToDecimal(lClosingBankBalance[row].Balance) != 0)
            {
                closingBalanceString += "<tr>";
                closingBalanceString += "<td align='left'>";
                closingBalanceString += "    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>" + lClosingBankBalance[row].HeadName.Replace("Cash at Bank", "") + "</font>";
                closingBalanceString += "</td>";
                closingBalanceString += "<td align='right'>";

                closingBalanceString += "</td>";
                closingBalanceString += "<td align='right'>";
                closingBalanceString += "<font size='2' face='Arial, Helvetica, sans-serif'>" + Convert.ToDecimal(lClosingBankBalance[row].Balance).ToString("0,0.00") + "</font>";
                closingBalanceString += "</td>";
                closingBalanceString += "    </tr>";

                ClosingBankBalance += Convert.ToDecimal(lClosingBankBalance[row].Balance);
            }
        }


        //bank
        closingBalanceString += @"<tr>
		                            <td align='left' style='border-top: medium solid;border-bottom: medium solid;'>&nbsp;
			                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Total Cash at Bank</font>
		                            </td>
		                            <td align='right' style='border-top: medium solid;border-bottom: medium solid;'>&nbsp;
			
		                            </td>
		                            <td align='right' style='border-top: medium solid;border-bottom: medium solid;'>
			                            <font size='2' face='Arial, Helvetica, sans-serif'>";
        closingBalanceString += ClosingBankBalance.ToString("0,0.00") + "</font></td></tr>";

        //Cash
        closingBalanceString += @"<tr>
		                            <td align='left' >
			                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Cash  in Hand</font>
		                            </td>
		                            <td align='right'>&nbsp;
			
		                            </td>
				                            <td align='right'>
			                            <font size='2' face='Arial, Helvetica, sans-serif'>";
        closingBalanceString += totalClosingBalanceCash.ToString("0,0.00") + "</font></td></tr>";

        //Check
        closingBalanceString += @"<tr >
		                            <td align='left'>
			                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Check in Hand</font>
		                            </td>
		                            <td align='right'>&nbsp;
			
		                            </td>
				                            <td align='right' >
			                            <font size='2' face='Arial, Helvetica, sans-serif'>";
        closingBalanceString += totalClosingBalanceCheck.ToString("0,0.00") + "</font></td></tr>";

        //total Cash and check
        closingBalanceString += @"<tr>
		                            <td align='left' style='border-top: medium solid;border-bottom: medium solid;'>&nbsp;
			                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Total Cash/Check in hand</font>
		                            </td>
		                            <td align='right' style='border-top: medium solid;border-bottom: medium solid;'>&nbsp;
			
		                            </td>
		                            <td align='right' style='border-top: medium solid;border-bottom: medium solid;'>
			                            <font size='2' face='Arial, Helvetica, sans-serif'>";
        closingBalanceString += totalClosingBalance.ToString("0,0.00") + "</font></td></tr>";

        //total Closing balance
        closingBalanceString += @" <tr>
		                                <td align='left'  style='border-bottom: medium solid;'>&nbsp;
			                                    Total Closing Balance
		                                </td>
		                                <td align='right' style='border-bottom: medium solid;'>&nbsp;
			
		                                </td>
		                                <td align='right' style='border-bottom: medium solid;'>
			                                <strong><font size='2' face='Arial, Helvetica, sans-serif'>";

        closingBalanceString += (totalClosingBalanceCash + totalClosingBalanceCheck + ClosingBankBalance).ToString("0,0.00") + "</font></strong></td></tr>";


        /*
         <table width='650' cellspacing='0' cellpadding='1' border='0' align='center'>
            <tbody><tr>
        <td align='left'>
            <font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bolder;text-decoration:underline'><strong>Closing Balance:</strong></font>
        </td>
        <td width='200' align='center'>&nbsp;
			
        </td>
        <td width='200' align='right'>
            <font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bolder;text-decoration:underline'>Amount (TK.)</font>
        </td>
    </tr>
    <tr>
        <td align='left' colspan='3'>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='2' face='Arial, Helvetica, sans-serif' style='font-weight:bold;text-decoration:underline'><strong>Cash at Bank :</strong></font>
        </td>
    </tr>
        <tr>
                <td align='left'>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Brac Bank</font>
        </td>
        <td align='right'>
			
        </td>
        <td align='right'>
            <font size='1' face='Arial, Helvetica, sans-serif'>3,784,614.00</font>
        </td>
            </tr>
        <tr>
                <td align='left' style='border-bottom: medium solid;'>
            <font size='1' face='Arial, Helvetica, sans-serif'>Dhaka Bank</font>
        </td>
        <td align='right' style='border-bottom: medium solid;'>
			
        </td>
        <td align='right' style='border-bottom: medium solid;'>
            <font size='1' face='Arial, Helvetica, sans-serif'>5,000.00</font>
        </td>
            </tr>
        <tr>
        <td align='left'>&nbsp;
			
        </td>
        <td align='right'>&nbsp;
			
        </td>
        <td align='right'>
            <font size='2' face='Arial, Helvetica, sans-serif'>3,789,614.00</font>
        </td>
    </tr>
    <tr>
        <td align='left' style='border-bottom: medium solid;'>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size='1' face='Arial, Helvetica, sans-serif'>Cash in Hand</font>
        </td>
        <td align='right' style='border-bottom: medium solid;'>&nbsp;
			
        </td>
                <td align='right' style='border-bottom: medium solid;'>
            <font size='2' face='Arial, Helvetica, sans-serif'>6,100.00</font>
        </td>
    </tr>
    <tr>
        <td align='left' style='border-bottom: medium solid;'>&nbsp;
			
        </td>
        <td align='right' style='border-bottom: medium solid;'>&nbsp;
			
        </td>
        <td align='right' style='border-bottom: medium solid;'>
            <strong><font size='2' face='Arial, Helvetica, sans-serif'>3,795,714.00</font></strong>
        </td>
    </tr>
    <tr> <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
</tbody></table>
         */


        #endregion

        htmlCode = htmlCode + closingBalanceString + "<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr></tbody></table>" ;


        return htmlCode;
    }

    public  String getDailyTransactionReportOpeningNClossing(DateTime startDate, DateTime endDate)
    {
        

        return "";
    }


    public  String getDailyTransactionReport(DateTime startDate, DateTime endDate,string userID)
    {

        try
        {
            List<ACC_Journal> lIncome = new List<ACC_Journal>();
            List<ACC_Journal> lExpence = new List<ACC_Journal>();
            List<ACC_Journal> lAsset = new List<ACC_Journal>();
            List<ACC_Journal> lBankDeposit = new List<ACC_Journal>();
            List<ACC_Journal> lBankWithdrow = new List<ACC_Journal>();
            List<ACC_Journal> lOtherAsset = new List<ACC_Journal>();



            DataSet journals = ACC_JournalManager.GetACC_JournalForTransactionByDateRange(startDate, endDate, userID);

            foreach (DataRow dr in journals.Tables[0].Rows)
            {
                ACC_Journal lc = new ACC_Journal();
                ACC_Journal ld = new ACC_Journal();

                lc.JournalMasterID = int.Parse(dr["JournalMasterID"].ToString());
                ld.JournalMasterID = int.Parse(dr["JournalMasterID"].ToString());

                if (dr["BasicAccountID"].ToString() == "2")
                {
                    lc.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
                    lc.HeadName = dr["HeadName"].ToString();
                    lc.Debit = Convert.ToDecimal(dr["DebitSum"]) - Convert.ToDecimal(dr["CreditSum"]);
                    lExpence.Add(lc);
                }
               else if (dr["BasicAccountID"].ToString() == "3")
                {
                    ld.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
                    if (dr["JournalVoucherNo"].ToString()=="0" && dr["HeadName"].ToString().Contains("Admission &"))
                    {
                        ld.HeadName = dr["HeadName"].ToString().Replace("Admission & ","");
                    }
                   else
                    {
                    ld.HeadName = dr["HeadName"].ToString();
                    }
                    ld.Credit = Convert.ToDecimal(dr["CreditSum"]) - Convert.ToDecimal(dr["DebitSum"]);
                    lIncome.Add(ld);
                }
                else if (dr["BasicAccountID"].ToString() == "4")
                {
                    if (dr["UserTypeID"].ToString() == "2" && dr["JournalVoucherNo"].ToString() == "2")
                    {
                        if (decimal.Parse(dr["DebitSum"].ToString()) != decimal.Parse("0.0"))
                        {
                            ld.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
                            ld.HeadName = dr["HeadName"].ToString();
                            ld.Debit = Convert.ToDecimal(dr["DebitSum"]);
                            ld.Credit = Convert.ToDecimal(dr["CreditSum"]);
                            lExpence.Add(ld);
                        }
                    }
                }
                else if (dr["BasicAccountID"].ToString() == "1")
                {
                    ld.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
                    ld.HeadName = dr["HeadName"].ToString();
                    ld.Debit = Convert.ToDecimal(dr["DebitSum"]);
                    ld.Credit = Convert.ToDecimal(dr["CreditSum"]);
                    
                    lAsset.Add(ld);

                    if (dr["UserTypeID"].ToString() == "3")
                    {
                        if (decimal.Parse(dr["DebitSum"].ToString()) != decimal.Parse("0.0"))
                        {
                            lBankDeposit.Add(ld);
                            lExpence.Add(ld);
                        }
                        if (decimal.Parse(dr["CreditSum"].ToString()) != decimal.Parse("0.0"))
                        {
                            lBankWithdrow.Add(ld);
                            lIncome.Add(ld);
                        }
                    }
                    else
                    {
                        lOtherAsset.Add(ld);
                    }


                }
            }



            #region OpeningNClosingBalance
            DataSet dsOpeningNClossing = ACC_AccountingCommonManager.GetACC_DailyAssetOpeningNClosingBalance(startDate, endDate, userID);

            List<ACC_Journal> lOpening = new List<ACC_Journal>();
            List<ACC_Journal> lClosing = new List<ACC_Journal>();
            List<ACC_Journal> lOpeningBankBalance = new List<ACC_Journal>();
            List<ACC_Journal> lClosingBankBalance = new List<ACC_Journal>();

            foreach (DataRow dr in dsOpeningNClossing.Tables[0].Rows)
            {
                ACC_Journal lc = new ACC_Journal();

                lc.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
                lc.HeadName = dr["HeadName"].ToString();
                lc.AccountID = int.Parse(dr["AccountID"].ToString());
                lc.Balance = Convert.ToDecimal(dr["Balance"]);
                lOpening.Add(lc);
            }

            foreach (DataRow dr in dsOpeningNClossing.Tables[1].Rows)
            {
                ACC_Journal lc = new ACC_Journal();

                lc.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
                lc.HeadName = dr["HeadName"].ToString();
                lc.AccountID = int.Parse(dr["AccountID"].ToString());
                lc.Balance = Convert.ToDecimal(dr["Balance"]);
                lClosing.Add(lc);
            }

            foreach (DataRow dr in dsOpeningNClossing.Tables[2].Rows)
            {
                ACC_Journal lc = new ACC_Journal();

                lc.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
                lc.HeadName = dr["HeadName"].ToString();
                lc.AccountID = int.Parse(dr["AccountID"].ToString());
                lc.Balance = Convert.ToDecimal(dr["Balance"]);
                lOpeningBankBalance.Add(lc);
            }

            foreach (DataRow dr in dsOpeningNClossing.Tables[3].Rows)
            {
                ACC_Journal lc = new ACC_Journal();

                lc.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
                lc.HeadName = dr["HeadName"].ToString();
                lc.AccountID = int.Parse(dr["AccountID"].ToString());
                lc.Balance = Convert.ToDecimal(dr["Balance"]);
                lClosingBankBalance.Add(lc);
            }
            #endregion

            return loadTable(lIncome, lExpence,lOpening,lClosing,lOpeningBankBalance,lClosingBankBalance,userID);
        }
        catch (Exception ex)
        {
            return "";
        }
    }
}