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

public class AttencenceID
{
    public AttencenceID()
    {
    }

    public AttencenceID
        (
        int attencenceIDID, 
        string userID, 
        DateTime inOutTime, 
        string extraField1, 
        string extraFileld2
        )
    {
        this.AttencenceIDID = attencenceIDID;
        this.UserID = userID;
        this.InOutTime = inOutTime;
        this.ExtraField1 = extraField1;
        this.ExtraFileld2 = extraFileld2;
    }


    private int _attencenceIDID;
    public int AttencenceIDID
    {
        get { return _attencenceIDID; }
        set { _attencenceIDID = value; }
    }

    private string _userID;
    public string UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }

    private DateTime _inOutTime;
    public DateTime InOutTime
    {
        get { return _inOutTime; }
        set { _inOutTime = value; }
    }

    private string _extraField1;
    public string ExtraField1
    {
        get { return _extraField1; }
        set { _extraField1 = value; }
    }

    private string _extraFileld2;
    public string ExtraFileld2
    {
        get { return _extraFileld2; }
        set { _extraFileld2 = value; }
    }
}
