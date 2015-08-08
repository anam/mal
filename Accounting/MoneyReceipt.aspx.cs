using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class MoneyReceipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Accounting/MoneyReceipt.aspx?StudentID=660ff051-06fa-4483-be43-0c55ad31659f&Amount=8000
            //if (Request.QueryString["StudentID"] != null && Request.QueryString["Amount"] != null && Request.QueryString["Remark"] != null)
            //{
            //    lblTotalAmount.Text = Request.QueryString["Amount"];
            //    lblfees.Text = Request.QueryString["Remark"];
            //    lblamount1.Text = Request.QueryString["Amount"];
            //    lblTaka.Text = NumberToWords(Convert.ToInt32(lblamount1.Text)) + " " + "Only";

            //    _loadSudentData(42,4000);
            //}
            if (Request.QueryString["FeesMasterID"] != null && Request.QueryString["Amount"] != null)
            {
                _loadSudentData(int.Parse(Request.QueryString["FeesMasterID"]), decimal.Parse(Request.QueryString["Amount"]));
            }
        }
    }

    private void _loadSudentData(int masterFeesID, decimal amount)
    {
        DataSet fees = STD_FeesMasterManager.GetSTD_FeesAmountByFeesMasterID(Request.QueryString["FeesMasterID"]);
        lblID.Text = fees.Tables[0].Rows[0]["StudentCode"].ToString() ;
        lbltag.Text = Request.QueryString["JournalMasterID"] != null ? Request.QueryString["JournalMasterID"] : lbltag.Text;
        try
        {
            if (fees.Tables[0].Rows[0]["BatchNo"].ToString() != "12007")
                lblID.Text +="   | Batch No: "+ fees.Tables[0].Rows[0]["BatchNo"].ToString().Substring(2,3);
        }
        catch (Exception ex)
        { }


        if (Request.QueryString["Remark"] != null)
        {
            lblReceivedMoney.Text = Request.QueryString["Remark"].ToString();
        }

        lblAddress.Text = fees.Tables[0].Rows[0]["PresentAddress"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cell: " + fees.Tables[0].Rows[0]["Mobile"].ToString();
        lblDate.Text = DateTime.Now.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString())).ToString("dd MMM yyyy");
        lblclass.Text = fees.Tables[0].Rows[0]["CourseName"].ToString();
        lblfees.Text = fees.Tables[0].Rows[0]["AccountName"].ToString();
        lblName.Text = fees.Tables[0].Rows[0]["StudentName"].ToString();
        string totalPayment = "Total Payment(" + Convert.ToDecimal(fees.Tables[0].Rows[0]["TotalPayment"].ToString()).ToString("0,0") + ") - Discount(" + Convert.ToDecimal(fees.Tables[0].Rows[0]["Discount"].ToString()).ToString("0,0") + ")";
        lblTotalPay.Text = totalPayment.ToString();
        lblAdmissionFees.Text =Convert.ToDecimal(fees.Tables[0].Rows[0]["TotalPaymentNeedToPay"].ToString()).ToString("0,0");
        if ((Convert.ToDecimal(fees.Tables[0].Rows[0]["ExtraField1"]) - amount) > 0)
        {
            //lblPrev.Text = "(" + fees.Tables[0].Rows[0]["ExtraField1"].ToString() + "-" + amount.ToString() + ")";
           
            lblPrevioulyReceiveMoney.Text = "(-)" + (Convert.ToDecimal(fees.Tables[0].Rows[0]["ExtraField1"]) - amount).ToString("0,0");
        }
        else
        {
            lblPrevioulyReceiveMoney.Text ="(-)"+ "0.00";
        }
        lblTotalAmount.Text = (Convert.ToDecimal(fees.Tables[0].Rows[0]["ExtraField2"]) + amount).ToString("0,0");
        lblPaidAmount.Text = amount.ToString("0,0");
        lblDueAmount.Text = Convert.ToDecimal(fees.Tables[0].Rows[0]["ExtraField2"].ToString()).ToString("0,0");

        lblTaka.Text = NumberToWords(Convert.ToInt32(amount)) + " " + "Only";
        
        trPaymentStatus.Visible = false;
        trInstallment.Visible = false;
        
        if (Request.QueryString["IsAdmissionFees"] != null)
        {
            if (Request.QueryString["IsAdmissionFees"] == "1")
            {
                ltInstallment.Text = getInstallment();
                trPaymentStatus.Visible = true;
                trInstallment.Visible = true;
            }
        }
    }


    private string getInstallment()
    {
        //List<STD_Fees> fees = new List<STD_Fees>();
        DataSet std_fees = STD_FeesManager.GetSTD_FeesInstallmentByFeesMasterID(Request.QueryString["FeesMasterID"]);

        //foreach (DataRow dr in std_fees.Tables[0].Rows)
        //    {
        //        STD_Fees fee = new STD_Fees();
               
        //        if (dr["IsPaid"].ToString() == "False")
        //        {
        //            fee.Amount = Convert.ToDecimal(dr["Amount"]);
        //            fee.AddedDate =Convert.ToDateTime(dr["AddedDate"]);

        //            fees.Add(fee);
        //        }
        //    }
        string htmlCode = "<table border='1' style='width:100%; float:left'>";
        htmlCode += "<tr><td>&nbsp;</td><td>Amount</td><td>Paid Amount</td><td>Unpaid Amount</td><td>Date</td><td>Payment Status</td></tr>";
        int i = -1;
        decimal totalAll = 0;
        decimal totalPaid = 0;
        decimal totalUnpaid = 0;


        for (int row = 0; row < std_fees.Tables[0].Rows.Count; row++)
        {
            
            decimal amount = Convert.ToDecimal(std_fees.Tables[0].Rows[row]["Amount"]);
            decimal remarks = Convert.ToDecimal(std_fees.Tables[0].Rows[row]["Remarks"]);
            decimal unpaid = amount - remarks;
            DateTime date = Convert.ToDateTime(std_fees.Tables[0].Rows[row]["SubmissionDate"]);
            string paymentStatus="";
            if (std_fees.Tables[0].Rows[row]["IsPaid"].ToString() == "True")
            {
                if(amount == remarks)
                {
                   htmlCode += "<tr style=' color:Green'>";
                    paymentStatus="Paid";
                }
                else
                {
                    if(date <= DateTime.Today)
                    {
                        htmlCode += "<tr style=' color:Red'>";
                       paymentStatus="Partially Due";
                    }            
                    else
                    {
                        htmlCode += "<tr style=' color:Blue'>";
                        paymentStatus="Partially Due";
                    } 
                }
            }
            else if (std_fees.Tables[0].Rows[row]["IsPaid"].ToString() == "False")
            {
                if(date <= DateTime.Today)
                {
                    htmlCode += "<tr style=' color:Red'>";
                    paymentStatus="Unpaid";
                }            
                else
                {
                    htmlCode += "<tr style=' color:Blue'>";
                    paymentStatus="Unpaid";
                } 
            }
            
            htmlCode += "<td style='width: 960px;'>";
            if (std_fees.Tables[0].Rows[row]["AccountID"].ToString() == "31")//for Installation fee only
            {
                htmlCode += ++i == 0 ? "Admission Fee" : "Installment #" + i;
            }
            else
            {
                ++i;
                htmlCode += "Fees # " + (i + 1);
            }
            
            htmlCode += "</td>";
            htmlCode += "<td style='width: 960px; text-align: right'>";
            htmlCode += amount.ToString("0,0");
            totalAll += amount;
            htmlCode += "</td>";
            htmlCode += "<td style='width: 960px; text-align: right'>";
            htmlCode += remarks.ToString("0,0");
            totalPaid += remarks;
            htmlCode += "</td>";
            htmlCode += "<td style='width: 960px; text-align: right'>";
            htmlCode += unpaid.ToString("0,0");
            totalUnpaid += unpaid;
            htmlCode += "</td>";
            htmlCode += "<td style='width: 960px;'>";
            htmlCode += date.ToString("dd MMM,yyyy");
            htmlCode += "</td>";
            htmlCode += "<td style='width: 960px;'>";
            htmlCode += paymentStatus;
            htmlCode += "</td></tr>";
            
        }

        htmlCode += "<tr><td>Total:</td><td style='text-align: right'>" + totalAll.ToString("0,000") + "</td><td style='text-align: right'>" + totalPaid.ToString("0,000") + "</td><td style='text-align: right'>" + totalUnpaid.ToString("0,000") + "</td><td></td><td></td></tr>";
        htmlCode += "</table>";
        return htmlCode;
    }

    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " Million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words;
    }

}