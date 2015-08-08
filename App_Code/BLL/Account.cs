using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class Account
{
    public Account()
    {
    }

    public Account
        (
        string s_id, 
        int received_date, 
        decimal received_amount, 
        string bank_acc_no, 
        string bank_name, 
        int issue_date, 
        int honour_date
        )
    {
        this.S_id = s_id;
        this.Received_date = received_date;
        this.Received_amount = received_amount;
        this.Bank_acc_no = bank_acc_no;
        this.Bank_name = bank_name;
        this.Issue_date = issue_date;
        this.Honour_date = honour_date;
    }


   

    private string _s_id;
    public string S_id
    {
        get { return _s_id; }
        set { _s_id = value; }
    }

    private int _received_date;
    public int Received_date
    {
        get { return _received_date; }
        set { _received_date = value; }
    }

    private decimal _received_amount;
    public decimal Received_amount
    {
        get { return _received_amount; }
        set { _received_amount = value; }
    }

    private string _bank_acc_no;
    public string Bank_acc_no
    {
        get { return _bank_acc_no; }
        set { _bank_acc_no = value; }
    }

    private string _bank_name;
    public string Bank_name
    {
        get { return _bank_name; }
        set { _bank_name = value; }
    }

    private int _issue_date;
    public int Issue_date
    {
        get { return _issue_date; }
        set { _issue_date = value; }
    }

    private int _honour_date;
    public int Honour_date
    {
        get { return _honour_date; }
        set { _honour_date = value; }
    }
}
