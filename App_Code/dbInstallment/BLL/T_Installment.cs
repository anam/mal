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

public class T_Installment
{
    public T_Installment()
    {
    }

    public T_Installment
        (
        int t_InstallmentID, 
        string iD, 
        DateTime date, 
        decimal amount
        )
    {
        this.T_InstallmentID = t_InstallmentID;
        this.ID = iD;
        this.Date = date;
        this.Amount = amount;
    }


    private int _t_InstallmentID;
    public int T_InstallmentID
    {
        get { return _t_InstallmentID; }
        set { _t_InstallmentID = value; }
    }

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private DateTime _date;
    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    private decimal _amount;
    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    private decimal _totalAmount;

    public decimal TotalAmount
    {
        get { return _totalAmount; }
        set { _totalAmount = value; }
    }
    private decimal _paidAmount;

    public decimal PaidAmount
    {
        get { return _paidAmount; }
        set { _paidAmount = value; }
    }
    
}
