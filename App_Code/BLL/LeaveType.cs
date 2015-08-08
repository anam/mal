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

public class LeaveType
{
    public LeaveType()
    {
    }

    public LeaveType
        (
        int leaveTypeID, 
        string leaveName
        )
    {
        this.LeaveTypeID = leaveTypeID;
        this.LeaveName = leaveName;
    }


    private int _leaveTypeID;
    public int LeaveTypeID
    {
        get { return _leaveTypeID; }
        set { _leaveTypeID = value; }
    }

    private string _leaveName;
    public string LeaveName
    {
        get { return _leaveName; }
        set { _leaveName = value; }
    }
}
