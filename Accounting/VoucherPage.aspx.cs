using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Accounting_VoucherPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["sP"] = null;
            Session["sumdebit"] = null;
            lblPayTo.Text = "...............................................................................";
            lblPurpose.Text = ".................................................................. A/C";
            if (Request.QueryString["Payto"] != null)
            {
                lblPayTo.Text = "  : " + Request.QueryString["Payto"];
            }

            if (Request.QueryString["Purpose"] != null)
            {
                lblPurpose.Text = "  : " + Request.QueryString["Purpose"];
            }

            if (Request.QueryString["JournalMasterID"] != null)
            {
                int i = 0;

                //lblDate.Text = DateTime.Now.ToShortDateString();
                lblVoucherNo.Text = Request.QueryString["JournalMasterID"];
                List<ACC_Journal> voucher = new  List<ACC_Journal>();
                int id = Convert.ToInt32(Request.QueryString["JournalMasterID"]);
                DataSet journals = ACC_JournalManager.GetACC_VoucherByJournalMasterID(id);
                foreach (DataRow dr in journals.Tables[0].Rows)
                {
                    ACC_Journal journal = new ACC_Journal();
                    
                    if (dr["BasicAccountID"].ToString() == "1")
                    {
                        i = 1;
                        break;
                    }
                }
                if (i == 1)
                {
                    bool IsAllAsset = true;

                    foreach (DataRow dr in journals.Tables[0].Rows)
                    {
                        ACC_Journal journal = new ACC_Journal();

                        if (dr["BasicAccountID"].ToString() != "1")
                        {
                            if (dr["Credit"].ToString() != "0.00")
                            {
                                lblVoucherName.Text = "Credit";
                                lblVoucher.Text = "Credit";
                            }
                            else
                            {
                                lblVoucherName.Text = "Debit";
                                lblVoucher.Text = "Debit";
                            }
                            lblDate.Text = DateTime.Parse(dr["UpdateDate"].ToString()).ToString("dd MMM yyyy");
                            journal.HeadName = dr["HeadName"].ToString();
                            journal.Debit = Convert.ToDecimal(dr["Debit"].ToString()) + Convert.ToDecimal(dr["Credit"].ToString());
                            voucher.Add(journal);
                            IsAllAsset = false;
                        }
                    }

                    if (IsAllAsset)
                    {
                        foreach (DataRow dr in journals.Tables[0].Rows)
                        {
                            ACC_Journal journal = new ACC_Journal();

                            if (Convert.ToDecimal(dr["Credit"].ToString()) != decimal.Parse("0"))
                            {
                                lblVoucherName.Text = "Transaction";
                                lblVoucher.Text = "Transaction";

                                journal.HeadName = dr["HeadName"].ToString();
                                journal.Debit = Convert.ToDecimal(dr["Credit"].ToString());
                                voucher.Add(journal);                                
                            }
                        } 
                    }

                    if (voucher.Count > 0)
                    {
                        gvACC_Journal.DataSource = voucher;
                        gvACC_Journal.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Voucher is not avaiable')", true);
                    }
                   
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('Voucher is not avaiable')", true);
                }

            }
        }
    }

    protected void gvACC_Journal_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        double sumdebit = 0;
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDebit = (Label)e.Row.FindControl("lblDebit");
            Label lblPs = (Label)e.Row.FindControl("lblPs");

            string debit = lblDebit.Text;
            string[] spDebit = debit.Split('.');
            if (spDebit.Length >= 2)
            {
                lblPs.Text = spDebit[1].ToString();
            }

            else
            {
                lblPs.Text = "00";
            }
            double dc = Convert.ToDouble(spDebit[0]);
            lblDebit.Text = dc.ToString("0,0");

            sumdebit = Convert.ToDouble(Session["sumdebit"]) + Convert.ToDouble(debit);
            Session["sumdebit"] = sumdebit;
        }


        if (e.Row.RowType == DataControlRowType.Footer)
        {

            if (Session["sumdebit"] != null)
            {
                string[] sSum = Session["sumdebit"].ToString().Split('.');

                Session["sumdebit"] = sSum[0].ToString();

                if (sSum.Length >= 2)
                {
                    Session["sP"] = sSum[1];
                }
                else
                {
                    Session["sP"] = "00";
                }
            }

            Label lblTotalDebit = (Label)e.Row.FindControl("lblTotalDebit");
            Label lblTotalPs = (Label)e.Row.FindControl("lblTotalPs");

            if (Session["sP"] != null)
            {
                lblTotalPs.Text = Session["sP"].ToString();
                Session["sP"] = null;
            }
            if (Session["sumdebit"] != null)
            {
               
                double dc = Convert.ToDouble(Session["sumdebit"]);
                lblTotalDebit.Text = dc.ToString("0,0");

                lblTake.Text = NumberToWords(Convert.ToInt32(Session["sumdebit"])) + " " + "Only";
                Session["sumdebit"] = null;
            }
        }
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