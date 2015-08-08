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

public class T_Payment_t
{
    public T_Payment_t()
    {
    }

    public T_Payment_t
        (
        int t_Payment_tID, 
        string iD, 
        string date, 
        string amount
        )
    {
        this.T_Payment_tID = t_Payment_tID;
        this.ID = iD;
        this.Date = date;
        this.Amount = amount;
    }


    private int _t_Payment_tID;
    public int T_Payment_tID
    {
        get { return _t_Payment_tID; }
        set { _t_Payment_tID = value; }
    }

    private string _iD;
    public string ID
    {
        get { return _iD; }
        set { _iD = value; }
    }

    private string _date;
    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }

    private string _amount;
    public string Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
}
